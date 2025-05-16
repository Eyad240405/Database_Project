using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace JobPortalGUI
{
    public partial class JobSeekerDashboard : Form
    {
        private int jobSeekerId;
        private DatabaseHelper dbHelper;
        private string currentCVPath = null;

        public JobSeekerDashboard(int jobSeekerId)
        {
            InitializeComponent();
            this.jobSeekerId = jobSeekerId;
            this.dbHelper = new DatabaseHelper();
            LoadJobSeekerInfo();
            LoadSkills();
            LoadAvailableJobs();
            LoadSavedJobs();
            LoadApplications();
            LoadCurrentCV();
            dgvAvailableJobs.ReadOnly = true;
            dgvAvailableJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            btnApply.Visible = true;
            btnApply.Enabled = true;
        }

        private void LoadJobSeekerInfo()
        {
            string query = "SELECT FName, MName, LName, Email, Bdate FROM JobSeeker WHERE JobSeekerID = @JobSeekerID";
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
                            lblName.Text = $"{reader["FName"]} {reader["MName"]} {reader["LName"]}";
                            lblEmail.Text = reader["Email"].ToString();
                            lblBirthDate.Text = Convert.ToDateTime(reader["Bdate"]).ToShortDateString();
                        }
                    }
                }
            }
        }

        private void LoadSkills()
        {
            string query = "SELECT SkillName, ProficiencyLevel, YearsOfExperience FROM Skill WHERE JobSeekerID = @JobSeekerID";
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
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvSkills.DataSource = dt;
                    }
                }
            }
        }

        private void LoadAvailableJobs()
        {
            string query = @"SELECT v.VacancyID, v.Title, v.Description, e.FName + ' ' + e.LName as EmployerName, 
                           i.Name as Industry, v.PostingDate 
                           FROM Vacancy v 
                           JOIN Employer e ON v.EmployerID = e.EmployerID 
                           JOIN Industry i ON v.IndustryID = i.IndustryID 
                           WHERE v.VacancyID NOT IN (SELECT VacancyID FROM Application WHERE JobSeekerID = @JobSeekerID)";
            
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
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAvailableJobs.DataSource = dt;
                    }
                }
            }
        }

        private void LoadSavedJobs()
        {
            string query = @"SELECT v.VacancyID, v.Title, v.Description, e.FName + ' ' + e.LName as EmployerName, 
                           i.Name as Industry, v.PostingDate 
                           FROM SavedVacancy sv 
                           JOIN Vacancy v ON sv.VacancyID = v.VacancyID 
                           JOIN Employer e ON v.EmployerID = e.EmployerID 
                           JOIN Industry i ON v.IndustryID = i.IndustryID 
                           WHERE sv.JobSeekerID = @JobSeekerID";

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
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvSavedJobs.DataSource = dt;
                    }
                }
            }
        }

        private void LoadApplications()
        {
            string query = @"SELECT v.Title, e.FName + ' ' + e.LName as EmployerName, 
                           a.Date as ApplicationDate, a.Status 
                           FROM Application a 
                           JOIN Vacancy v ON a.VacancyID = v.VacancyID 
                           JOIN Employer e ON v.EmployerID = e.EmployerID 
                           WHERE a.JobSeekerID = @JobSeekerID";

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
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvApplications.DataSource = dt;
                    }
                }
            }
        }

        private void LoadCurrentCV()
        {
            string query = "SELECT TOP 1 FileName, FilePath, UploadDate FROM CV WHERE JobSeekerID = @JobSeekerID ORDER BY UploadDate DESC";
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
                            string fileName = reader["FileName"].ToString();
                            string filePath = reader["FilePath"].ToString();
                            DateTime uploadDate = Convert.ToDateTime(reader["UploadDate"]);

                            lblCurrentCV.Text = $"Current CV: {fileName} (Uploaded: {uploadDate:yyyy-MM-dd HH:mm})";
                            currentCVPath = filePath;
                            btnOpenCV.Enabled = true;
                            btnChangeCV.Enabled = true;
                        }
                        else
                        {
                            lblCurrentCV.Text = "No CV uploaded yet";
                            currentCVPath = null;
                            btnOpenCV.Enabled = false;
                            btnChangeCV.Enabled = false;
                        }
                    }
                }
            }
        }

        private void SaveCV(string sourcePath, string fileName)
        {
            string cvFolder = Path.Combine(Application.StartupPath, "CVs");
            if (!Directory.Exists(cvFolder))
            {
                Directory.CreateDirectory(cvFolder);
            }

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string newFileName = $"{jobSeekerId}_{timestamp}_{fileName}";
            string destinationPath = Path.Combine(cvFolder, newFileName);

            File.Copy(sourcePath, destinationPath, true);

            string query = @"INSERT INTO CV (JobSeekerID, FileName, FilePath, UploadDate) 
                           VALUES (@JobSeekerID, @FileName, @FilePath, @UploadDate)";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@JobSeekerID", jobSeekerId),
                new SqlParameter("@FileName", fileName),
                new SqlParameter("@FilePath", destinationPath),
                new SqlParameter("@UploadDate", DateTime.Now)
            };

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }

            LoadCurrentCV();
        }

        private void btnUploadCV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.Title = "Select your CV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SaveCV(openFileDialog.FileName, Path.GetFileName(openFileDialog.FileName));
                        MessageBox.Show("CV uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error uploading CV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnOpenCV_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentCVPath) && File.Exists(currentCVPath))
            {
                try
                {
                    System.Diagnostics.Process.Start(currentCVPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening CV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("CV file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeCV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.Title = "Select new CV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SaveCV(openFileDialog.FileName, Path.GetFileName(openFileDialog.FileName));
                        MessageBox.Show("CV updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating CV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            string skillName = txtSkillName.Text;
            string proficiencyLevel = cmbProficiencyLevel.Text;
            int yearsOfExperience;

            if (string.IsNullOrEmpty(skillName) || string.IsNullOrEmpty(proficiencyLevel) || !int.TryParse(txtYearsExperience.Text, out yearsOfExperience))
            {
                MessageBox.Show("Please fill in all skill details correctly.");
                return;
            }

            string query = @"INSERT INTO Skill (JobSeekerID, SkillName, ProficiencyLevel, YearsOfExperience)
                             VALUES (@JobSeekerID, @SkillName, @ProficiencyLevel, @YearsOfExperience)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@JobSeekerID", jobSeekerId),
                new SqlParameter("@SkillName", skillName),
                new SqlParameter("@ProficiencyLevel", proficiencyLevel),
                new SqlParameter("@YearsOfExperience", yearsOfExperience)
            };

            try
            {
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Skill added successfully!");
                    LoadSkills();
                    ClearSkillInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding skill: " + ex.Message);
            }
        }

        private void ClearSkillInputs()
        {
            txtSkillName.Text = "";
            cmbProficiencyLevel.Text = "";
            txtYearsExperience.Text = "";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            lblApplyErrorMessage.Text = "";
            
            if (dgvAvailableJobs.SelectedRows.Count == 0)
            {
                lblApplyErrorMessage.Text = "Please select a job to apply for.";
                return;
            }

            if (string.IsNullOrEmpty(currentCVPath))
            {
                lblApplyErrorMessage.Text = "Please upload your CV before applying.";
                return;
            }

            int vacancyId = Convert.ToInt32(dgvAvailableJobs.SelectedRows[0].Cells["VacancyID"].Value);
            DateTime applicationDate = DateTime.Now;

            string checkQuery = "SELECT COUNT(*) FROM Application WHERE JobSeekerID = @JobSeekerID AND VacancyID = @VacancyID";
            SqlParameter[] checkParams = new SqlParameter[]
            {
                new SqlParameter("@JobSeekerID", jobSeekerId),
                new SqlParameter("@VacancyID", vacancyId)
            };

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddRange(checkParams);
                    int existingApplications = Convert.ToInt32(command.ExecuteScalar());
                    if (existingApplications > 0)
                    {
                        lblApplyErrorMessage.Text = "You have already applied for this job.";
                        return;
                    }
                }

                string insertQuery = @"INSERT INTO Application (JobSeekerID, VacancyID, Date, Status) 
                                     VALUES (@JobSeekerID, @VacancyID, @Date, 'Pending')";
                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@JobSeekerID", jobSeekerId),
                    new SqlParameter("@VacancyID", vacancyId),
                    new SqlParameter("@Date", applicationDate)
                };

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddRange(insertParams);
                    command.ExecuteNonQuery();
                }
            }

            lblApplyErrorMessage.Text = "Application submitted successfully!";
            LoadAvailableJobs();
            LoadApplications();
        }

        private void btnSaveJob_Click(object sender, EventArgs e)
        {
            if (dgvAvailableJobs.SelectedRows.Count == 0)
            {
                lblApplyErrorMessage.Text = "Please select a job to save.";
                return;
            }

            int vacancyId = Convert.ToInt32(dgvAvailableJobs.SelectedRows[0].Cells["VacancyID"].Value);

            string checkQuery = "SELECT COUNT(*) FROM SavedVacancy WHERE JobSeekerID = @JobSeekerID AND VacancyID = @VacancyID";
            SqlParameter[] checkParams = new SqlParameter[]
            {
                new SqlParameter("@JobSeekerID", jobSeekerId),
                new SqlParameter("@VacancyID", vacancyId)
            };

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddRange(checkParams);
                    int existingSavedJobs = Convert.ToInt32(command.ExecuteScalar());
                    if (existingSavedJobs > 0)
                    {
                        lblApplyErrorMessage.Text = "This job is already saved.";
                        return;
                    }
                }

                string insertQuery = @"INSERT INTO SavedVacancy (JobSeekerID, VacancyID) 
                                     VALUES (@JobSeekerID, @VacancyID)";
                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@JobSeekerID", jobSeekerId),
                    new SqlParameter("@VacancyID", vacancyId)
                };

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddRange(insertParams);
                    command.ExecuteNonQuery();
                }
            }

            lblApplyErrorMessage.Text = "Job saved successfully!";
            LoadSavedJobs(); 
        }

        private void btnSearchJobs_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchJobs.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadAvailableJobs();
                return;
            }

            string query = @"SELECT v.VacancyID, v.Title, v.Description, e.FName + ' ' + e.LName as EmployerName, 
                           i.Name as Industry, v.PostingDate 
                           FROM Vacancy v 
                           JOIN Employer e ON v.EmployerID = e.EmployerID 
                           JOIN Industry i ON v.IndustryID = i.IndustryID 
                           WHERE (v.Title LIKE @SearchTerm OR i.Name LIKE @SearchTerm) 
                           AND v.VacancyID NOT IN (SELECT VacancyID FROM Application WHERE JobSeekerID = @JobSeekerID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SearchTerm", "%" + searchTerm + "%"),
                new SqlParameter("@JobSeekerID", jobSeekerId)
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
                        dgvAvailableJobs.DataSource = dt;
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close(); // Close RegisterForm when LoginForm is closed
            loginForm.Show();
        }



    }
} 