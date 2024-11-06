using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerManager.Client2
{
    public partial class ClientForm2Dashboard : Form
    {
        private SqlConnection connection;
        private string studentID;

        public ClientForm2Dashboard(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            ConnectToDatabase(); // Initialize the database connection

            c2_userlogLabel.Text = $"User currently logged in: {studentID}";
        }

        private void ConnectToDatabase()
        {
            // Use your connection string here
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

        private void clientpc2logoutButton_Click(object sender, EventArgs e)
        {
            string checkActiveSessionQuery = "SELECT COUNT(*) FROM dbo.ClientSessions2 WHERE StudentID = @StudentID AND LogoutTime IS NULL";
            string updateLogoutQuery = "UPDATE dbo.ClientSessions2 SET LogoutTime = @LogoutTime WHERE StudentID = @StudentID AND LogoutTime IS NULL";

            if (connection.State == System.Data.ConnectionState.Open)
            {
                using (SqlCommand checkCommand = new SqlCommand(checkActiveSessionQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@StudentID", studentID);

                    int activeSessionCount = (int)checkCommand.ExecuteScalar();

                    if (activeSessionCount > 0)
                    {
                        // Only proceed to logout if there is an active session
                        using (SqlCommand updateCommand = new SqlCommand(updateLogoutQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@LogoutTime", DateTime.Now);
                            updateCommand.Parameters.AddWithValue("@StudentID", studentID);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Logout successful.");
                                ClientForm2 clientForm2 = new ClientForm2();
                                clientForm2.Show();
                            }
                            else
                            {
                                MessageBox.Show("Error logging out. Please try again.");
                            }
                        }
                    }
                    else
                    {
                        // No active session found for the student
                        MessageBox.Show("No active session found to log out from.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Database connection is not open. Cannot update logout time.");
            }

            this.Close(); // Close the dashboard after logout
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Ensure the connection is closed when the form is closing
            connection?.Close();
            base.OnFormClosing(e);
        }
    }
}
