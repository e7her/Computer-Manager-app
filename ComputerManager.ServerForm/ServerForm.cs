using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ComputerManager.ServerForm
{
    public partial class SF_dashboardForm : Form
    {
        private TcpListener listener;
        private Thread listenerThread;
        private bool isRunning;
        private SqlConnection connection; // SQL connection object
        private readonly ManualResetEvent shutdownEvent = new ManualResetEvent(false);

        public SF_dashboardForm()
        {
            InitializeComponent();
            ConnectToDatabase(); // Connect to the SQL database on load
            StartServer(); // Start listening for TCP connections
        }

        private void ConnectToDatabase()
        {
            string connectionString = "Data Source=10.10.1.80,1433;Initial Catalog=NewComputerManagementDB;User ID=admin1;Password=kitjanbren;";

            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                UpdateStatusTextBox("Server is now connected to the SQL Database.");
            }
            catch (Exception ex)
            {
                UpdateStatusTextBox($"Server connection to SQL Database failed: {ex.Message}");
            }
        }

        private void StartServer()
        {
            isRunning = true;
            listener = new TcpListener(IPAddress.Any, 5000); // Listening on port 5000
            listener.Start();
            UpdateStatusTextBox("TCP Connection is established. Welcome to MCM COMPUTER MANAGER...");

            listenerThread = new Thread(ListenForClients)
            {
                IsBackground = true // Allows thread to close when the application exits
            };
            listenerThread.Start();
        }

        private void ListenForClients()
        {
            while (isRunning)
            {
                try
                {
                    // Check if shutdown is requested, wait briefly to allow shutdown to proceed
                    if (shutdownEvent.WaitOne(100))
                    {
                        break; // Exit if shutdown is requested
                    }

                    // Accept an incoming client connection
                    TcpClient client = listener.AcceptTcpClient();
                    HandleClientConnection(client); // Process the connected client
                }
                catch (SocketException ex)
                {
                    if (isRunning)
                    {
                        UpdateStatusTextBox($"SocketException: {ex.Message}");
                    }
                    break; // Break the loop if the listener is stopped unexpectedly
                }
                catch (Exception ex)
                {
                    UpdateStatusTextBox($"Error in ListenForClients: {ex.Message}");
                }
            }
        }

        private void HandleClientConnection(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[256]; // Buffer to read identifier message
                int bytesRead = stream.Read(buffer, 0, buffer.Length); // Blocking read

                string clientIdentifier = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                UpdateStatusTextBox($"{clientIdentifier} is now connected to the ADMIN DASHBOARD.");

                // Send a welcome message after identifying the client
                byte[] message = Encoding.ASCII.GetBytes($"Welcome {clientIdentifier}");
                stream.Write(message, 0, message.Length);
            }
            catch (Exception ex)
            {
                UpdateStatusTextBox($"Error in HandleClientConnection: {ex.Message}");
            }
            finally
            {
                client.Close(); // Ensure the client connection is closed
            }
        }
        private void UpdateStatusTextBox(string message)
        {
            if (SF_statusTextBox.InvokeRequired)
            {
                SF_statusTextBox.Invoke((MethodInvoker)delegate
                {
                    SF_statusTextBox.AppendText($"{message}{Environment.NewLine}");
                });
            }
            else
            {
                SF_statusTextBox.AppendText($"{message}{Environment.NewLine}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Signal the listener thread to exit and set the event
            isRunning = false;
            shutdownEvent.Set();

            try
            {
                // Stop the listener if it’s initialized
                listener?.Stop();

                // Wait for the listener thread to finish, if it's alive
                if (listenerThread != null && listenerThread.IsAlive)
                {
                    listenerThread.Join(); // Wait for the thread to finish
                }
            }
            catch (SocketException ex)
            {
                UpdateStatusTextBox($"SocketException during form closing: {ex.Message}");
            }
            catch (Exception ex)
            {
                UpdateStatusTextBox($"Error during server form closing: {ex.Message}");
            }
            finally
            {
                // Ensure the database connection and other resources are closed
                connection?.Close();
                shutdownEvent.Dispose();
               
            }

            base.OnFormClosing(e); // Call the base method to ensure proper form closing
        }
        private void SF_createaccountButton_Click_1(object sender, EventArgs e)
        {
            CreateAccount createAccountForm = new CreateAccount();
            createAccountForm.Show();
        }

        private void SF_lockedaccountsButton_Click_1(object sender, EventArgs e)
        {
            LockedAccounts lockedAccountsForm = new LockedAccounts();
            lockedAccountsForm.Show();
        }
        private void SF_pc1StatusButton_Click(object sender, EventArgs e)
        {
            string studentID = GetCurrentStudentID();
            ClientPC1Details clientPC1Details = new ClientPC1Details();
            clientPC1Details.Show();
        }

        private void SF_pc2StatusButton_Click(object sender, EventArgs e)
        {
            ClientPC2Details clientPC2Details = new ClientPC2Details();
            clientPC2Details.Show();
        }
        public static class UserSession
        {
            public static string CurrentStudentID { get; set; } // This property will be set upon successful login
        }

        private string GetCurrentStudentID()
        {
            // Access the Student ID from the UserSession
            return UserSession.CurrentStudentID; // This will return the currently logged-in Student ID
        }
    }
}
