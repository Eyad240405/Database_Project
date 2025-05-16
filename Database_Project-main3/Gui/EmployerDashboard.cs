using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace JobPortalGUI
{
    public partial class EmployerDashboard : Form
    {
        private int employerId;
        private DatabaseHelper dbHelper;
        private DataTable vacanciesTable;

        public EmployerDashboard(int employerId)
        {
            InitializeComponent();
            this.employerId = employerId;
            this.dbHelper = new DatabaseHelper();
            LoadEmployerInfo();
            LoadIndustries();
            LoadVacancyIndustries();
            LoadPostedVacancies();
            
            AddApplicationsButtonToVacanciesGrid();
            
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.MultiSelect = false;
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.ReadOnly = true;
            
            FillVacanciesFilter();

            dgvPostedVacancies.CellContentClick += dgvPostedVacancies_CellContentClick;
        }

        private void LoadEmployerInfo()
        {
            string query = @"SELECT e.FName, e.MName, e.LName, e.Email, i.Name 
                           FROM Employer e 
                           LEFT JOIN Industry i ON e.IndustryID = i.IndustryID 
                           WHERE e.EmployerID = @EmployerID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployerID", employerId)
            };

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblName.Text = $"{reader["FName"]} {reader["MName"]} {reader["LName"]}";
                            lblEmail.Text = reader["Email"].ToString();
                            lblIndustry.Text = reader["Name"].ToString();
                        }
                    }
                }
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

        private void LoadVacancyIndustries()
        {
            cmbVacancyIndustry.Items.Clear();
            string query = "SELECT IndustryID, Name FROM Industry";
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbVacancyIndustry.Items.Add(new ComboBoxItem(reader["Name"].ToString(), Convert.ToInt32(reader["IndustryID"])));
                    }
                }
            }
        }

        private void LoadPostedVacancies()
        {
            string query = @"SELECT v.VacancyID, v.Title, i.Name as Industry, v.PostingDate, 
                           (SELECT COUNT(*) FROM Application a WHERE a.VacancyID = v.VacancyID) as ApplicantCount 
                           FROM Vacancy v 
                           LEFT JOIN Industry i ON v.IndustryID = i.IndustryID 
                           WHERE v.EmployerID = @EmployerID 
                           ORDER BY v.PostingDate DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployerID", employerId)
            };

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvPostedVacancies.DataSource = dt;
                    }
                }
            }
        }

        private void FillVacanciesFilter()
        {
            string query = "SELECT VacancyID, Title FROM Vacancy WHERE EmployerID = @EmployerID ORDER BY PostingDate DESC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployerID", employerId)
            };
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        vacanciesTable = new DataTable();
                        adapter.Fill(vacanciesTable);
                        cmbVacanciesFilter.Items.Clear();
                        cmbVacanciesFilter.Items.Add("All jobs");
                        foreach (DataRow row in vacanciesTable.Rows)
                        {
                            cmbVacanciesFilter.Items.Add(row["Title"].ToString());
                        }
                        cmbVacanciesFilter.SelectedIndex = 0;
                    }
                }
            }
        }

        private void cmbVacanciesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVacanciesFilter.SelectedIndex == 0)
            {
                LoadAllApplications();
            }
            else
            {
                int vacancyId = Convert.ToInt32(vacanciesTable.Rows[cmbVacanciesFilter.SelectedIndex - 1]["VacancyID"]);
                LoadApplicationsByVacancy(vacancyId);
            }
        }

        private void LoadAllApplications()
        {
            try
            {
                string query = @"SELECT js.JobSeekerID, v.VacancyID, js.FName + ' ' + js.LName as JobSeekerName, 
                                js.Email, js.Bdate as BirthDate, a.Date as ApplicationDate, a.Status,
                                v.Title as VacancyTitle,
                                cv.FileName as CVFileName, cv.FilePath as CVFilePath,
                                (SELECT COUNT(*) FROM Skill WHERE JobSeekerID = js.JobSeekerID) as SkillsCount
                                FROM Application a 
                                JOIN JobSeeker js ON a.JobSeekerID = js.JobSeekerID 
                                JOIN Vacancy v ON a.VacancyID = v.VacancyID
                                OUTER APPLY (
                                    SELECT TOP 1 FileName, FilePath 
                                    FROM CV 
                                    WHERE JobSeekerID = js.JobSeekerID 
                                    ORDER BY UploadDate DESC
                                ) cv
                                WHERE v.EmployerID = @EmployerID
                                ORDER BY v.Title, a.Date DESC";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@EmployerID", employerId)
                };
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvApplications.DataSource = dt;
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No applicants found for your vacancies.", "No Applicants", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"{dt.Rows.Count} applicants found for your vacancies.", "Applicants Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (dgvApplications.Columns.Contains("JobSeekerID"))
                                dgvApplications.Columns["JobSeekerID"].Visible = false;
                            if (dgvApplications.Columns.Contains("VacancyID"))
                                dgvApplications.Columns["VacancyID"].Visible = false;
                            if (!dgvApplications.Columns.Contains("CVStatus"))
                                dgvApplications.Columns.Add("CVStatus", "CV Status");
                            foreach (DataGridViewRow row in dgvApplications.Rows)
                            {
                                string cvFilePath = row.Cells["CVFilePath"].Value?.ToString();
                                row.Cells["CVStatus"].Value = !string.IsNullOrEmpty(cvFilePath) && System.IO.File.Exists(cvFilePath) ? "Available" : "Not Available";
                                string status = row.Cells["Status"].Value?.ToString();
                                if (!string.IsNullOrEmpty(status))
                                {
                                    switch (status.ToLower())
                                    {
                                        case "pending":
                                            row.Cells["Status"].Style.BackColor = Color.LightYellow;
                                            row.Cells["Status"].Value = "Pending";
                                            break;
                                        case "under review":
                                            row.Cells["Status"].Style.BackColor = Color.LightBlue;
                                            row.Cells["Status"].Value = "Under Review";
                                            break;
                                        case "shortlisted":
                                            row.Cells["Status"].Style.BackColor = Color.LightGreen;
                                            row.Cells["Status"].Value = "Shortlisted";
                                            break;
                                        case "rejected":
                                            row.Cells["Status"].Style.BackColor = Color.LightPink;
                                            row.Cells["Status"].Value = "Rejected";
                                            break;
                                        case "hired":
                                            row.Cells["Status"].Style.BackColor = Color.LightGreen;
                                            row.Cells["Status"].Value = "Hired";
                                            break;
                                    }
                                }
                            }
                            dgvApplications.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading applications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadApplicationsByVacancy(int vacancyId)
        {
            try
            {
                string query = @"SELECT js.JobSeekerID, v.VacancyID, js.FName + ' ' + js.LName as JobSeekerName, 
                                js.Email, js.Bdate as BirthDate, a.Date as ApplicationDate, a.Status,
                                v.Title as VacancyTitle,
                                cv.FileName as CVFileName, cv.FilePath as CVFilePath,
                                (SELECT COUNT(*) FROM Skill WHERE JobSeekerID = js.JobSeekerID) as SkillsCount
                                FROM Application a 
                                JOIN JobSeeker js ON a.JobSeekerID = js.JobSeekerID 
                                JOIN Vacancy v ON a.VacancyID = v.VacancyID
                                OUTER APPLY (
                                    SELECT TOP 1 FileName, FilePath 
                                    FROM CV 
                                    WHERE JobSeekerID = js.JobSeekerID 
                                    ORDER BY UploadDate DESC
                                ) cv
                                WHERE v.EmployerID = @EmployerID AND v.VacancyID = @VacancyID
                                ORDER BY a.Date DESC";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@EmployerID", employerId),
                    new SqlParameter("@VacancyID", vacancyId)
                };
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvApplications.DataSource = dt;
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No applicants found for this vacancy.", "No Applicants", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"{dt.Rows.Count} applicants found for this vacancy.", "Applicants Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (dgvApplications.Columns.Contains("JobSeekerID"))
                                dgvApplications.Columns["JobSeekerID"].Visible = false;
                            if (dgvApplications.Columns.Contains("VacancyID"))
                                dgvApplications.Columns["VacancyID"].Visible = false;
                            if (!dgvApplications.Columns.Contains("CVStatus"))
                                dgvApplications.Columns.Add("CVStatus", "CV Status");
                            foreach (DataGridViewRow row in dgvApplications.Rows)
                            {
                                string cvFilePath = row.Cells["CVFilePath"].Value?.ToString();
                                row.Cells["CVStatus"].Value = !string.IsNullOrEmpty(cvFilePath) && System.IO.File.Exists(cvFilePath) ? "Available" : "Not Available";
                                string status = row.Cells["Status"].Value?.ToString();
                                if (!string.IsNullOrEmpty(status))
                                {
                                    switch (status.ToLower())
                                    {
                                        case "pending":
                                            row.Cells["Status"].Style.BackColor = Color.LightYellow;
                                            row.Cells["Status"].Value = "Pending";
                                            break;
                                        case "under review":
                                            row.Cells["Status"].Style.BackColor = Color.LightBlue;
                                            row.Cells["Status"].Value = "Under Review";
                                            break;
                                        case "shortlisted":
                                            row.Cells["Status"].Style.BackColor = Color.LightGreen;
                                            row.Cells["Status"].Value = "Shortlisted";
                                            break;
                                        case "rejected":
                                            row.Cells["Status"].Style.BackColor = Color.LightPink;
                                            row.Cells["Status"].Value = "Rejected";
                                            break;
                                        case "hired":
                                            row.Cells["Status"].Style.BackColor = Color.LightGreen;
                                            row.Cells["Status"].Value = "Hired";
                                            break;
                                    }
                                }
                            }
                            dgvApplications.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading applicants: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPostVacancy_Click(object sender, EventArgs e)
        {
            string title = txtVacancyTitle.Text;
            string description = txtDescription.Text;
            DateTime postingDate = DateTime.Now;

            if (string.IsNullOrEmpty(title) || cmbVacancyIndustry.SelectedItem == null)
            {
                lblVacancyErrorMessage.Text = "Please fill in all vacancy details (Title and Industry).";
                return;
            }
            lblVacancyErrorMessage.Text = "";

            int industryId = ((ComboBoxItem)cmbVacancyIndustry.SelectedItem).Value;

            string query = @"INSERT INTO Vacancy (EmployerID, Title, IndustryID, Description, PostingDate) 
                           VALUES (@EmployerID, @Title, @IndustryID, @Description, @PostingDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployerID", employerId),
                new SqlParameter("@Title", title),
                new SqlParameter("@IndustryID", industryId),
                new SqlParameter("@Description", description),
                new SqlParameter("@PostingDate", postingDate)
            };

            try
            {
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Vacancy posted successfully!");
                    LoadPostedVacancies();
                    ClearVacancyInputs();
                    lblVacancyErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblVacancyErrorMessage.Text = "Error posting vacancy: " + ex.Message;
            }
        }

        private void ClearVacancyInputs()
        {
            txtVacancyTitle.Text = "";
            txtDescription.Text = "";
        }

        private void btnViewApplications_Click(object sender, EventArgs e)
        {
            if (dgvPostedVacancies.SelectedRows.Count > 0)
            {
                int vacancyId = Convert.ToInt32(dgvPostedVacancies.SelectedRows[0].Cells["VacancyID"].Value);
                string vacancyTitle = dgvPostedVacancies.SelectedRows[0].Cells["Title"].Value.ToString();
                LoadApplicationsByVacancy(vacancyId);
                tabControl1.SelectedTab = tabApplications;
                this.Text = $"Employer Dashboard - Applications for: {vacancyTitle}";
            }
            else
            {
                MessageBox.Show("Please select a vacancy to view applications.",
                               "No Selection",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an application to update its status.",
                               "No Application Selected",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(cmbStatus.Text))
            {
                MessageBox.Show("Please select a new status.",
                               "No Status Selected",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int jobSeekerId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["JobSeekerID"].Value);
                int vacancyId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["VacancyID"].Value);
                string newStatus = cmbStatus.Text;
                string applicantName = dgvApplications.SelectedRows[0].Cells["JobSeekerName"].Value.ToString();
                string vacancyTitle = dgvApplications.SelectedRows[0].Cells["VacancyTitle"].Value.ToString();

                string query = "UPDATE Application SET Status = @Status WHERE JobSeekerID = @JobSeekerID AND VacancyID = @VacancyID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Status", newStatus),
                    new SqlParameter("@JobSeekerID", jobSeekerId),
                    new SqlParameter("@VacancyID", vacancyId)
                };

                int result = dbHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    string statusMessage;
                    switch (newStatus.ToLower())
                    {
                        case "hired":
                            statusMessage = "Congratulations! The applicant has been hired.";
                            break;
                        case "rejected":
                            statusMessage = "The application has been rejected.";
                            break;
                        case "shortlisted":
                            statusMessage = "The applicant has been shortlisted.";
                            break;
                        case "under review":
                            statusMessage = "The application is under review.";
                            break;
                        default:
                            statusMessage = "The application status has been updated.";
                            break;
                    }

                    MessageBox.Show($"Application status updated successfully!\n\n" +
                                  $"Applicant: {applicantName}\n" +
                                  $"Vacancy: {vacancyTitle}\n" +
                                  $"New Status: {newStatus}\n\n" +
                                  $"{statusMessage}",
                                  "Status Updated",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    
                    LoadAllApplications();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the application status: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnViewCV_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count > 0)
            {
                string cvFilePath = dgvApplications.SelectedRows[0].Cells["CVFilePath"].Value?.ToString();
                string cvFileName = dgvApplications.SelectedRows[0].Cells["CVFileName"].Value?.ToString();
                
                if (string.IsNullOrEmpty(cvFilePath) || !System.IO.File.Exists(cvFilePath))
                {
                    MessageBox.Show($"No CV available for this applicant.\n\nApplicant: {dgvApplications.SelectedRows[0].Cells["JobSeekerName"].Value}", 
                                  "CV Not Available", 
                                  MessageBoxButtons.OK, 
                                  MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    System.Diagnostics.Process.Start(cvFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening CV: {ex.Message}\n\nFile: {cvFileName}", 
                                  "Error", 
                                  MessageBoxButtons.OK, 
                                  MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an application to view the CV.", 
                               "No Selection", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Information);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close(); // Close RegisterForm when LoginForm is closed
            loginForm.Show();
        }

        private void btnSaveIndustry_Click(object sender, EventArgs e)
        {
            if (cmbIndustry.SelectedItem is ComboBoxItem selectedIndustry)
            {
                string query = "UPDATE Employer SET IndustryID = @IndustryID WHERE EmployerID = @EmployerID";
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IndustryID", selectedIndustry.Value);
                        command.Parameters.AddWithValue("@EmployerID", employerId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Industry updated successfully!");
                LoadEmployerInfo();
            }
            else
            {
                MessageBox.Show("Please select an industry.");
            }
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count > 0)
            {
                int jobSeekerId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["JobSeekerID"].Value);
                string jobSeekerName = dgvApplications.SelectedRows[0].Cells["JobSeekerName"].Value.ToString();
                string vacancyTitle = dgvApplications.SelectedRows[0].Cells["VacancyTitle"].Value.ToString();
                string currentStatus = dgvApplications.SelectedRows[0].Cells["Status"].Value.ToString();

                string query = @"SELECT js.FName + ' ' + js.LName as Name, js.Email, js.Bdate as BirthDate,
                                (SELECT COUNT(*) FROM Skill WHERE JobSeekerID = js.JobSeekerID) as SkillsCount,
                                (SELECT STRING_AGG(SkillName + ' (' + ProficiencyLevel + ')', ', ') 
                                 FROM Skill WHERE JobSeekerID = js.JobSeekerID) as Skills
                                FROM JobSeeker js
                                WHERE js.JobSeekerID = @JobSeekerID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@JobSeekerID", jobSeekerId)
                };

                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string message = $"Applicant Profile for: {jobSeekerName}\n" +
                                               $"Applied for: {vacancyTitle}\n" +
                                               $"Current Status: {currentStatus}\n\n" +
                                               $"Email: {reader["Email"]}\n" +
                                               $"Birth Date: {Convert.ToDateTime(reader["BirthDate"]).ToShortDateString()}\n" +
                                               $"Number of Skills: {reader["SkillsCount"]}\n\n" +
                                               $"Skills:\n{reader["Skills"]}";

                                MessageBox.Show(message,
                                                "Job Seeker Profile",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an application to view the job seeker's profile.",
                               "No Selection",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

        private void AddApplicationsButtonToVacanciesGrid()
        {
            if (dgvPostedVacancies.Columns["ApplicationsButton"] == null)
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "ApplicationsButton";
                btnCol.HeaderText = "Applications";
                btnCol.Text = "Applications";
                btnCol.UseColumnTextForButtonValue = true;
                btnCol.Width = 100;
                dgvPostedVacancies.Columns.Add(btnCol);
            }
        }

        private void dgvPostedVacancies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPostedVacancies.Columns[e.ColumnIndex].Name == "ApplicationsButton")
            {
                int vacancyId = Convert.ToInt32(dgvPostedVacancies.Rows[e.RowIndex].Cells["VacancyID"].Value);
                tabControl1.SelectedTab = tabApplications;
                if (vacanciesTable != null)
                {
                    for (int i = 0; i < vacanciesTable.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(vacanciesTable.Rows[i]["VacancyID"]) == vacancyId)
                        {
                            cmbVacanciesFilter.SelectedIndex = i + 1; 
                            break;
                        }
                    }
                }
            }
        }

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }
            public override string ToString() => Text;
        }

        
    }
} 