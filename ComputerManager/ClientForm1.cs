using ComputerManager.ServerForm;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ComputerManager.Client1
{
    public partial class ClientForm1 : Form
    {
        private TcpClient client;
        private SqlConnection connection;
        private int failedLoginAttempts = 0;

        public ClientForm1()
        {
            InitializeComponent();
            ConnectToServer();
            ConnectToDatabase();
        }

        private void ConnectToDatabase()
        {
            string connectionString = "Data Source=10.10.1.80,1433;Initial Catalog=NewComputerManagementDB;User ID=admin1;Password=kitjanbren;";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed: {ex.Message}");
            }
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("10.10.1.80", 5000);
                NetworkStream stream = client.GetStream();

                byte[] identifier = Encoding.ASCII.GetBytes("ClientPC1");
                stream.Write(identifier, 0, identifier.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }

        private void c1_loginButton_Click(object sender, EventArgs e)
        {
            string studentID = C1_studentIDtextbox.Text;
            string password = c1_passwordTextbox.Text;

            // Check if the account exists first
            if (!DoesAccountExist(studentID))
            {
                MessageBox.Show("Account doesn't exist.");
                return;
            }

            // Check if the account is locked
            if (IsAccountLocked(studentID))
            {
                MessageBox.Show("This account is locked. Please contact the server administrator.");
                return;
            }

            // Attempt to validate login
            if (ValidateLogin(studentID, password, out string firstName, out string lastName, out string program))
            {
                // Successful login
                MessageBox.Show("Login successful!");
                UpdateLoginTime(studentID, firstName, lastName, program);
                failedLoginAttempts = 0;

                ClientForm1Dashboard dashboard = new ClientForm1Dashboard(studentID);
                this.Hide();
                dashboard.Show();
            }
            else
            {
                // Incorrect password handling
                failedLoginAttempts++;
                MessageBox.Show($"Incorrect password. Attempt {failedLoginAttempts}/3.");

                // Lock account after 3 failed attempts
                if (failedLoginAttempts >= 3)
                {
                    LockAccount(studentID);
                    MessageBox.Show("Your account has been locked due to multiple failed login attempts.");
                }
            }
        }

        private bool DoesAccountExist(string studentID)
        {
            string checkAccountQuery = "SELECT COUNT(*) FROM dbo.Accounts WHERE StudentID = @StudentID";

            using (SqlCommand command = new SqlCommand(checkAccountQuery, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        private bool IsAccountLocked(string studentID)
        {
            string checkLockedQuery = "SELECT COUNT(*) FROM dbo.LockedAccounts WHERE StudentID = @StudentID";

            using (SqlCommand command = new SqlCommand(checkLockedQuery, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        private bool ValidateLogin(string studentID, string password, out string firstName, out string lastName, out string program)
        {
            firstName = string.Empty;
            lastName = string.Empty;
            program = string.Empty;

            bool isValid = false;

            string query = "SELECT FirstName, LastName, Program, StudentPassword FROM dbo.Accounts WHERE StudentID = @StudentID";

            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database connection is not initialized or open. Attempting to reconnect...");
                ConnectToDatabase();
            }

            if (connection.State == ConnectionState.Open)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Account exists, retrieve information
                                string storedPassword = reader.GetString(3);
                                if (storedPassword == password)
                                {
                                    firstName = reader.GetString(0);
                                    lastName = reader.GetString(1);
                                    program = reader.GetString(2);
                                    isValid = true; // Valid login
                                }
                                else
                                {
                                    // Incorrect password, but account exists
                                    isValid = false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error validating login: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to reconnect to the database. Please check the connection settings.");
            }

            return isValid;
        }

        private void UpdateLoginTime(string studentID, string firstName, string lastName, string program)
        {
            string checkQuery = "SELECT COUNT(*) FROM dbo.ClientSessions1 WHERE StudentID = @StudentID AND LogoutTime IS NULL";

            if (connection.State == ConnectionState.Open)
            {
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@StudentID", studentID);
                    int count = (int)checkCommand.ExecuteScalar();

                    string query;
                    if (count > 0)
                    {
                        query = "UPDATE dbo.ClientSessions1 SET LoginTime = @LoginTime WHERE StudentID = @StudentID AND LogoutTime IS NULL";
                    }
                    else
                    {
                        query = "INSERT INTO dbo.ClientSessions1 (StudentID, LoginTime, FirstName, LastName, Program) VALUES (@StudentID, @LoginTime, @FirstName, @LastName, @Program)";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.Parameters.AddWithValue("@LoginTime", DateTime.Now);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Program", program);
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("Database connection is not open. Cannot update login time.");
            }
        }

        private void LockAccount(string studentID)
        {
            string lockQuery = "UPDATE dbo.Accounts SET isLocked = 1 WHERE StudentID = @StudentID";
            string insertLockedAccount = "INSERT INTO dbo.LockedAccounts (StudentID, FirstName, LastName, Program, Email) " +
                                         "SELECT StudentID, FirstName, LastName, Program, Email FROM dbo.Accounts WHERE StudentID = @StudentID";

            if (connection.State == ConnectionState.Open)
            {
                using (SqlCommand lockCommand = new SqlCommand(lockQuery, connection))
                {
                    lockCommand.Parameters.AddWithValue("@StudentID", studentID);
                    try
                    {
                        int rowsAffected = lockCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your account has been locked due to multiple failed login attempts.");

                            using (SqlCommand insertCommand = new SqlCommand(insertLockedAccount, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@StudentID", studentID);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error locking account: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Database connection is not open. Cannot lock the account.");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            connection?.Close();
            base.OnFormClosing(e);
        }
    }
}
