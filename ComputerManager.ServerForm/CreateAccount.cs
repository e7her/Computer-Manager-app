using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerManager.ServerForm
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void createaccountButton_Click(object sender, EventArgs e)
        {
            // 1. Retrieve and validate form data
            string studentID = studentidTextbox.Text.Trim();
            string firstName = firstnameTextbox.Text.Trim();
            string lastName = lastnameTextbox.Text.Trim();
            string program = programTextbox.Text.Trim();
            string email = emailTextbox.Text.Trim();
            string password = desiredpasswordTextbox.Text.Trim();
            string confirmPassword = confirmpasswordTextbox.Text.Trim();

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(studentID) || string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(program) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter the passwords.");
                return;
            }

            // 2. Connect to SQL and check if the StudentID already exists
            string connectionString = "Data Source=10.10.1.80,1433;Initial Catalog=NewComputerManagementDB;User ID=admin1;Password=kitjanbren;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL SELECT command to check for existing StudentID
                    string checkQuery = "SELECT COUNT(*) FROM Accounts WHERE StudentID = @StudentID";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@StudentID", studentID);

                        int existingCount = (int)checkCommand.ExecuteScalar();
                        if (existingCount > 0)
                        {
                            MessageBox.Show("An account with this StudentID already exists. Cannot creaate account.");
                            return; // Exit the method to prevent account creation
                        }
                    }

                    // SQL INSERT command
                    string insertQuery = "INSERT INTO Accounts (StudentID, StudentPassword, FirstName, LastName, Program, Email, isLocked) " +
                                         "VALUES (@StudentID, @StudentPassword, @FirstName, @LastName, @Program, @Email, 0)";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@StudentID", studentID);
                        insertCommand.Parameters.AddWithValue("@StudentPassword", password);
                        insertCommand.Parameters.AddWithValue("@FirstName", firstName);
                        insertCommand.Parameters.AddWithValue("@LastName", lastName);
                        insertCommand.Parameters.AddWithValue("@Program", program);
                        insertCommand.Parameters.AddWithValue("@Email", email);

                        // Execute the insert command
                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account created successfully!");
                            ClearFields(); // Optional: Clear the form fields after success
                        }
                        else
                        {
                            MessageBox.Show("Account creation failed. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating account: {ex.Message}");
                }
            }
        }

        // Helper method to clear form fields after successful account creation
        private void ClearFields()
        {
            studentidTextbox.Clear();
            firstnameTextbox.Clear();
            lastnameTextbox.Clear();
            programTextbox.Clear();
            emailTextbox.Clear();
            desiredpasswordTextbox.Clear();
            confirmpasswordTextbox.Clear();
        }
    }
}
