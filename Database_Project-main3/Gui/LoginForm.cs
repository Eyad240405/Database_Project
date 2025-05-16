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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(textPassword.Text))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            string email = txtEmail.Text;
            string password = textPassword.Text;

            string tableName = "";
            string idColumn = "";

            // Determine which user type is selected
            if (radioButton1.Checked)  // JobSeeker
            {
                tableName = "JobSeeker";
                idColumn = "JobSeekerID";
            }
            else if (radioButton2.Checked)  // Employer
            {
                tableName = "Employer";
                idColumn = "EmployerID";
            }
            else
            {
                MessageBox.Show("Please select a user type.");
                return;
            }

            // SQL query to check if email and password exist for the selected user type
            string query = $"SELECT {idColumn} FROM {tableName} WHERE Email = @Email AND Password = @Password";

            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Password", password)
                };

                using (SqlDataReader reader = dbHelper.ExecuteQuery(query, parameters))
                {
                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader[idColumn]);
                        MessageBox.Show("Login successful!");

                        // Open the appropriate dashboard
                        if (tableName == "JobSeeker")
                        {
                            JobSeekerDashboard jobSeekerDashboard = new JobSeekerDashboard(userId);
                            this.Hide();
                            jobSeekerDashboard.FormClosed += (s, args) => this.Close();
                            jobSeekerDashboard.Show();
                        }
                        else // Employer
                        {
                            EmployerDashboard employerDashboard = new EmployerDashboard(userId);
                            this.Hide();
                            employerDashboard.FormClosed += (s, args) => this.Close();
                            employerDashboard.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the current form
            RegisterForm registerForm = new RegisterForm();
            registerForm.FormClosed += (s, args) => this.Show(); // Show the original form when RegisterForm is closed
            registerForm.Show(); // Show the RegisterForm
        }
    }
}
