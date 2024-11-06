using ComputerManager.Client2;
using ComputerManager.ServerForm;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static ComputerManager.ServerForm.SF_dashboardForm;


namespace ComputerManager.Client2
{
    public partial class ClientForm2 : Form
    {
        private TcpClient client;
        private SqlConnection connection;
        private int failedLoginAttempts = 0; // Counter for failed login attempts

        public ClientForm2()
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

                byte[] identifier = Encoding.ASCII.GetBytes("ClientPC2");
                stream.Write(identifier, 0, identifier.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }

        private void c2_loginButton_Click(object sender, EventArgs e)
        {
            string studentID = C2_studentIDTextbox.Text;
            string password = C2_passwordTextbox.Text;

            if (AccountExists(studentID, out bool isLocked, out string firstName, out string lastName, out string program))
            {
                if (isLocked)
                {
                    MessageBox.Show("This account is locked. Please contact the server administrator.");
                }
                else if (ValidatePassword(studentID, password))
                {
                    MessageBox.Show("Login successful!");
                    UpdateLoginTime(studentID, firstName, lastName, program);
                    failedLoginAttempts = 0; // Reset failed attempts on successful login
                    ClientForm2Dashboard dashboard = new ClientForm2Dashboard(studentID);
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    failedLoginAttempts++;
                    if (failedLoginAttempts >= 3)
                    {
                        LockAccount(studentID);
                    }
                    else
                    {
                        MessageBox.Show($"Failed login. Attempt {failedLoginAttempts}/3.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Account doesn't exist.");
            }
        }

        private bool AccountExists(string studentID, out bool isLocked, out string firstName, out string lastName, out string program)
        {
            isLocked = false;
            firstName = lastName = program = string.Empty;
            string query = "SELECT FirstName, LastName, Program, isLocked FROM dbo.Accounts WHERE StudentID = @StudentID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        firstName = reader.GetString(0);
                        lastName = reader.GetString(1);
                        program = reader.GetString(2);
                        isLocked = reader.GetBoolean(3);
                        return true; // Account exists
                    }
                }
            }
            return false; // Account does not exist
        }

        private bool ValidatePassword(string studentID, string password)
        {
            string query = "SELECT COUNT(*) FROM dbo.Accounts WHERE StudentID = @StudentID AND StudentPassword = @Password";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@Password", password);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        private void UpdateLoginTime(string studentID, string firstName, string lastName, string program)
        {
            string checkQuery = "SELECT COUNT(*) FROM dbo.ClientSessions2 WHERE StudentID = @StudentID AND LogoutTime IS NULL";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@StudentID", studentID);
                int count = (int)checkCommand.ExecuteScalar();

                string query = count > 0
                    ? "UPDATE dbo.ClientSessions2 SET LoginTime = @LoginTime WHERE StudentID = @StudentID AND LogoutTime IS NULL"
                    : "INSERT INTO dbo.ClientSessions2 (StudentID, LoginTime, FirstName, LastName, Program) VALUES (@StudentID, @LoginTime, @FirstName, @LastName, @Program)";

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

        private void LockAccount(string studentID)
        {
            string lockQuery = "UPDATE dbo.Accounts SET isLocked = 1 WHERE StudentID = @StudentID";
            string insertLockedAccount = "INSERT INTO dbo.LockedAccounts (StudentID, FirstName, LastName, Program, Email) " +
                                         "SELECT StudentID, FirstName, LastName, Program, Email FROM dbo.Accounts WHERE StudentID = @StudentID";

            using (SqlCommand lockCommand = new SqlCommand(lockQuery, connection))
            {
                lockCommand.Parameters.AddWithValue("@StudentID", studentID);
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
                else
                {
                    MessageBox.Show("Failed to lock the account.");
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            connection?.Close();
            base.OnFormClosing(e);
        }
    }
}
