using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerManager.ServerForm
{
    public partial class LockedAccounts : Form
    {
        private SqlConnection connection;


        public LockedAccounts()
        {
            InitializeComponent();
            LoadLockedAccountsData();
        }

        public DataGridView LockedAccountsGridView
        {
            get { return lockedAccountsGridView; }
        }

        private void LoadLockedAccountsData()
        {
            string connectionString = "Data Source=10.10.1.80,1433;Initial Catalog=NewComputerManagementDB;User ID=admin1;Password=kitjanbren;";
            string query = "SELECT * FROM dbo.LockedAccounts";

            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    lockedAccountsGridView.DataSource = dataTable; // Bind data to DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        public void RefreshLockedAccounts()
        {
            // Reload the data from the database
            LoadLockedAccountsData();
        }

        private void LA_unlockaccountButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (lockedAccountsGridView.SelectedRows.Count > 0)
            {
                string studentID = lockedAccountsGridView.SelectedRows[0].Cells["StudentID"].Value.ToString();

                string unlockQuery = "UPDATE Accounts SET isLocked = 0 WHERE StudentID = @StudentID";
                string deleteQuery = "DELETE FROM LockedAccounts WHERE StudentID = @StudentID";

                // Use the same connection string here as in LoadLockedAccountsData
                using (SqlConnection connection = new SqlConnection("Data Source=10.10.1.80,1433;Initial Catalog=NewComputerManagementDB;User ID=admin1;Password=kitjanbren;"))
                {
                    try
                    {
                        connection.Open();

                        // Unlock the account in the Accounts table
                        using (SqlCommand unlockCommand = new SqlCommand(unlockQuery, connection))
                        {
                            unlockCommand.Parameters.AddWithValue("@StudentID", studentID);
                            unlockCommand.ExecuteNonQuery();
                        }

                        // Remove the account from LockedAccounts table
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@StudentID", studentID);
                            deleteCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Account unlocked successfully.");
                        RefreshLockedAccounts(); // Refresh the data grid to reflect changes
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error unlocking account: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an account to unlock.");
            }
        }
    }
}
