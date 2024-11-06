using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerManager.ServerForm
{
    public partial class ClientPC1Details : Form
    {
        private SqlConnection connection;
        private System.Windows.Forms.Timer refreshTimer; // Specify System.Windows.Forms.Timer

        public ClientPC1Details()
        {
            InitializeComponent();
            ConnectToDatabase();    // Initialize the database connection when the form loads
            LoadSessionData();      // Load all session data on form load
            SetupAutoRefresh();     // Set up the auto-refresh timer
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

        private void LoadSessionData()
        {
            // Query to fetch logout history
            string query = @"
                SELECT 
                    cs.SessionID,
                    cs.StudentID, 
                    a.FirstName, 
                    a.LastName, 
                    a.Program, 
                    cs.LoginTime, 
                    cs.LogoutTime
                FROM 
                    dbo.ClientSessions1 cs
                INNER JOIN 
                    dbo.Accounts a ON cs.StudentID = a.StudentID
                WHERE 
                    cs.LogoutTime IS NOT NULL -- Show only logged-out sessions
                ORDER BY 
                    cs.LogoutTime DESC"; // Order by logout time

            if (connection.State == ConnectionState.Open)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        clientPC1Datagridview.DataSource = dataTable; // Bind the data to the DataGridView
                    }
                }
            }
            else
            {
                MessageBox.Show("Database connection is not open. Cannot load data.");
            }
        }

        private void SetupAutoRefresh()
        {
            // Initialize the timer
            refreshTimer = new System.Windows.Forms.Timer // Specify System.Windows.Forms.Timer
            {
                Interval = 5000 // Set interval to 5 seconds (5000 ms)
            };
            refreshTimer.Tick += (s, e) => LoadCurrentUserData(); // Call LoadCurrentUserData on each tick
            refreshTimer.Start(); // Start the timer
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                // Stop and dispose of the timer to prevent it from running after form closes
                refreshTimer?.Stop();
                refreshTimer?.Dispose();

                // Close the SQL connection if open
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during form closing: {ex.Message}");
            }

            base.OnFormClosing(e); // Ensure base method is called for standard closing behavior
        }

        private void LoadCurrentUserData()
        {
            // Query to get the current user's data for the logged-in session
            string query = @"
                SELECT 
                    cs.SessionID,
                    cs.StudentID, 
                    a.FirstName, 
                    a.LastName, 
                    a.Program, 
                    cs.LoginTime, 
                    cs.LogoutTime
                FROM 
                    dbo.ClientSessions1 cs
                INNER JOIN 
                    dbo.Accounts a ON cs.StudentID = a.StudentID
                WHERE 
                    cs.LogoutTime IS NULL"; // Filter for currently logged-in user (no logout time)

            if (connection.State == ConnectionState.Open)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        clientPC1Datagridview2.DataSource = dataTable; // Bind the data to the second DataGridView
                    }
                }
            }
            else
            {
                MessageBox.Show("Database connection is not open. Cannot load user data.");
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {

        }
    }
}