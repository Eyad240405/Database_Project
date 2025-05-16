using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JobPortalGUI
{
    public partial class RegisterForm : Form
    {
        private int employerId;
        private DatabaseHelper dbHelper;

        public RegisterForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();  // Initialize here
            LoadIndustries();
        }

        public class ComboBoxItem
        {
            public string Name { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string name, int value)
            {
                Name = name;
                Value = value;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadIndustries()
        {
            cmbIndustry.Items.Clear();
            string query = "SELECT IndustryID, Name FROM Industry";
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbIndustry.Items.Add(new ComboBoxItem(reader["Name"].ToString(), Convert.ToInt32(reader["IndustryID"])));
                    }
                }
            }

            // Check if an Industry is already assigned to the Employer (if applicable)
            if (employerId > 0)
            {
                string currentIndustryQuery = "SELECT IndustryID FROM Employer WHERE EmployerID = @EmployerID";
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(currentIndustryQuery, connection))
                    {
                        command.Parameters.AddWithValue("@EmployerID", employerId);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int currentIndustryId = Convert.ToInt32(result);
                            foreach (ComboBoxItem item in cmbIndustry.Items)
                            {
                                if (item.Value == currentIndustryId)
                                {
                                    cmbIndustry.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrEmpty(txtFname.Text) || string.IsNullOrEmpty(txtLname.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(textPassword.Text) ||
                    string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                // Check if passwords match
                if (textPassword.Text != textBox1.Text)
                {
                    MessageBox.Show("Passwords do not match!");
                    return;
                }

                string fname = txtFname.Text;
                string lname = txtLname.Text;
                string email = txtEmail.Text;
                string password = textPassword.Text;
                string companyname = comname.Text;  // Company name text box
                DateTime selectedBirthdate = this.birthdate.Value.Date;

                string tableName = "";
                string query = "";
                string mname = ""; // Default

                // Determine the user type and construct the query
                if (radioButton1.Checked)  // JobSeeker
                {
                    mname = txtMname.Text;
                    tableName = "JobSeeker";
                    query = "INSERT INTO JobSeeker (FName, MName, LName, Email, Password, Bdate) VALUES (@FName, @MName, @LName, @Email, @Password, @Bdate)";
                }
                else if (radioButton2.Checked)  // Employer
                {
                    if (string.IsNullOrEmpty(companyname))
                    {
                        MessageBox.Show("Please enter Company name for Employer registration.");
                        return;
                    }
                    tableName = "Employer";
                    query = "INSERT INTO Employer (FName, LName, Email, Password, CompanyName) VALUES (@FName, @LName, @Email, @Password, @CompanyName)";
                }
                else
                {
                    MessageBox.Show("Please select a user type.");
                    return;
                }

                // Execute the insert query
                SqlParameter[] parameters;

                if (tableName == "JobSeeker")
                {
                    parameters = new SqlParameter[]
                    {
                new SqlParameter("@FName", SqlDbType.NVarChar) { Value = fname },
                new SqlParameter("@MName", SqlDbType.NVarChar) { Value = mname },
                new SqlParameter("@LName", SqlDbType.NVarChar) { Value = lname },
                new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email },
                new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password },
                new SqlParameter("@Bdate", SqlDbType.Date) { Value = selectedBirthdate }
                    };
                }
                else  // Employer
                {
                    parameters = new SqlParameter[]
                    {
                new SqlParameter("@FName", SqlDbType.NVarChar) { Value = fname },
                new SqlParameter("@LName", SqlDbType.NVarChar) { Value = lname },
                new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email },
                new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password },
                new SqlParameter("@CompanyName", SqlDbType.NVarChar) { Value = companyname }
                    };
                }

                // First check if email already exists
                string checkEmailQuery = $"SELECT COUNT(*) FROM {tableName} WHERE Email = @Email";
                SqlParameter[] checkParams = new SqlParameter[] { new SqlParameter("@Email", email) };

                using (SqlDataReader reader = dbHelper.ExecuteQuery(checkEmailQuery, checkParams))
                {
                    if (reader.Read() && Convert.ToInt32(reader[0]) > 0)
                    {
                        MessageBox.Show("This email is already registered. Please use a different email address.");
                        return;
                    }
                }

                int result = dbHelper.ExecuteNonQuery(query, parameters);

                // Check if the insertion was successful
                if (result > 0)
                {
                    MessageBox.Show("Registration successful as " + tableName + "!");

                    // After registration, associate the Employer with the selected Industry
                    if (radioButton2.Checked)  // Employer
                    {
                        // Get the selected industry ID from the ComboBox
                        int industryId = ((ComboBoxItem)cmbIndustry.SelectedItem)?.Value ?? 0;

                        // Ensure an industry is selected
                        if (industryId == 0)
                        {
                            MessageBox.Show("Please select an Industry.");
                            return;
                        }

                        // Get the last inserted Employer's ID
                        string getEmployerIdQuery = "SELECT MAX(EmployerID) FROM Employer";
                        //int employerId = Convert.ToInt32(dbHelper.ExecuteScalar(getEmployerIdQuery));

                        // Now associate this Employer with the selected Industry
                        string updateIndustryQuery = "UPDATE Employer SET IndustryID = @IndustryID WHERE EmployerID = @EmployerID";
                        SqlParameter[] updateParams = new SqlParameter[]
                        {
                    new SqlParameter("@IndustryID", SqlDbType.Int) { Value = industryId },
                    new SqlParameter("@EmployerID", SqlDbType.Int) { Value = employerId }
                        };

                        dbHelper.ExecuteNonQuery(updateIndustryQuery, updateParams);
                    }

                    this.Close(); // Close the registration form
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Industry ID format. Please enter a valid number.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\nStack Trace: " + ex.StackTrace);
            }
        }

    }


}
