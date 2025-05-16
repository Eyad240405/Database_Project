using System.Drawing;
using System.Windows.Forms;

namespace JobPortalGUI
{
    partial class JobSeekerDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AutoScaleMode = AutoScaleMode.Font;

            // Makes form size adjust automatically to content (optional)
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Optional: center and maximize on open
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUploadCV = new System.Windows.Forms.Button();
            this.btnOpenCV = new System.Windows.Forms.Button();
            this.btnChangeCV = new System.Windows.Forms.Button();
            this.lblCurrentCV = new System.Windows.Forms.Label();
            this.tabSkills = new System.Windows.Forms.TabPage();
            this.dgvSkills = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.txtYearsExperience = new System.Windows.Forms.TextBox();
            this.cmbProficiencyLevel = new System.Windows.Forms.ComboBox();
            this.txtSkillName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabJobs = new System.Windows.Forms.TabPage();
            this.dgvAvailableJobs = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSaveJob = new System.Windows.Forms.Button();
            this.btnSearchJobs = new System.Windows.Forms.Button();
            this.txtSearchJobs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabSavedJobs = new System.Windows.Forms.TabPage();
            this.dgvSavedJobs = new System.Windows.Forms.DataGridView();
            this.tabApplications = new System.Windows.Forms.TabPage();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.lblApplyErrorMessage = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkills)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableJobs)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabSavedJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavedJobs)).BeginInit();
            this.tabApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProfile);
            this.tabControl1.Controls.Add(this.tabSkills);
            this.tabControl1.Controls.Add(this.tabJobs);
            this.tabControl1.Controls.Add(this.tabSavedJobs);
            this.tabControl1.Controls.Add(this.tabApplications);
            this.tabControl1.Location = new System.Drawing.Point(18, 19);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1173, 692);
            this.tabControl1.TabIndex = 0;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.lblBirthDate);
            this.tabProfile.Controls.Add(this.lblEmail);
            this.tabProfile.Controls.Add(this.lblName);
            this.tabProfile.Controls.Add(this.label3);
            this.tabProfile.Controls.Add(this.label2);
            this.tabProfile.Controls.Add(this.label1);
            this.tabProfile.Controls.Add(this.btnUploadCV);
            this.tabProfile.Controls.Add(this.btnOpenCV);
            this.tabProfile.Controls.Add(this.btnChangeCV);
            this.tabProfile.Controls.Add(this.lblCurrentCV);
            this.tabProfile.Location = new System.Drawing.Point(4, 34);
            this.tabProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabProfile.Size = new System.Drawing.Size(1165, 654);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(225, 156);
            this.lblBirthDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(0, 25);
            this.lblBirthDate.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(225, 94);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(0, 25);
            this.lblEmail.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(225, 31);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 25);
            this.lblName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Birth Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // btnUploadCV
            // 
            this.btnUploadCV.Location = new System.Drawing.Point(30, 234);
            this.btnUploadCV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUploadCV.Name = "btnUploadCV";
            this.btnUploadCV.Size = new System.Drawing.Size(180, 47);
            this.btnUploadCV.TabIndex = 1;
            this.btnUploadCV.Text = "Upload CV";
            this.btnUploadCV.UseVisualStyleBackColor = true;
            this.btnUploadCV.Click += new System.EventHandler(this.btnUploadCV_Click);
            // 
            // btnOpenCV
            // 
            this.btnOpenCV.Location = new System.Drawing.Point(225, 234);
            this.btnOpenCV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenCV.Name = "btnOpenCV";
            this.btnOpenCV.Size = new System.Drawing.Size(180, 47);
            this.btnOpenCV.TabIndex = 8;
            this.btnOpenCV.Text = "Open CV";
            this.btnOpenCV.UseVisualStyleBackColor = true;
            this.btnOpenCV.Click += new System.EventHandler(this.btnOpenCV_Click);
            // 
            // btnChangeCV
            // 
            this.btnChangeCV.Location = new System.Drawing.Point(420, 234);
            this.btnChangeCV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnChangeCV.Name = "btnChangeCV";
            this.btnChangeCV.Size = new System.Drawing.Size(180, 47);
            this.btnChangeCV.TabIndex = 9;
            this.btnChangeCV.Text = "Change CV";
            this.btnChangeCV.UseVisualStyleBackColor = true;
            this.btnChangeCV.Click += new System.EventHandler(this.btnUploadCV_Click);
            // 
            // lblCurrentCV
            // 
            this.lblCurrentCV.AutoSize = true;
            this.lblCurrentCV.Location = new System.Drawing.Point(30, 312);
            this.lblCurrentCV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentCV.Name = "lblCurrentCV";
            this.lblCurrentCV.Size = new System.Drawing.Size(0, 25);
            this.lblCurrentCV.TabIndex = 0;
            // 
            // tabSkills
            // 
            this.tabSkills.Controls.Add(this.dgvSkills);
            this.tabSkills.Controls.Add(this.groupBox1);
            this.tabSkills.Location = new System.Drawing.Point(4, 34);
            this.tabSkills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSkills.Size = new System.Drawing.Size(1165, 654);
            this.tabSkills.TabIndex = 1;
            this.tabSkills.Text = "Skills";
            this.tabSkills.UseVisualStyleBackColor = true;
            // 
            // dgvSkills
            // 
            this.dgvSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSkills.Location = new System.Drawing.Point(14, 16);
            this.dgvSkills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSkills.Name = "dgvSkills";
            this.dgvSkills.RowHeadersWidth = 51;
            this.dgvSkills.RowTemplate.Height = 24;
            this.dgvSkills.Size = new System.Drawing.Size(1134, 312);
            this.dgvSkills.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddSkill);
            this.groupBox1.Controls.Add(this.txtYearsExperience);
            this.groupBox1.Controls.Add(this.cmbProficiencyLevel);
            this.groupBox1.Controls.Add(this.txtSkillName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(14, 359);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1134, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Skill";
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Location = new System.Drawing.Point(932, 211);
            this.btnAddSkill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(180, 47);
            this.btnAddSkill.TabIndex = 6;
            this.btnAddSkill.Text = "Add Skill";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.btnAddSkill_Click);
            // 
            // txtYearsExperience
            // 
            this.txtYearsExperience.Location = new System.Drawing.Point(213, 191);
            this.txtYearsExperience.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtYearsExperience.Name = "txtYearsExperience";
            this.txtYearsExperience.Size = new System.Drawing.Size(298, 30);
            this.txtYearsExperience.TabIndex = 5;
            // 
            // cmbProficiencyLevel
            // 
            this.cmbProficiencyLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProficiencyLevel.FormattingEnabled = true;
            this.cmbProficiencyLevel.Items.AddRange(new object[] {
            "Beginner",
            "Intermediate",
            "Advanced",
            "Expert"});
            this.cmbProficiencyLevel.Location = new System.Drawing.Point(213, 128);
            this.cmbProficiencyLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbProficiencyLevel.Name = "cmbProficiencyLevel";
            this.cmbProficiencyLevel.Size = new System.Drawing.Size(298, 33);
            this.cmbProficiencyLevel.TabIndex = 4;
            // 
            // txtSkillName
            // 
            this.txtSkillName.Location = new System.Drawing.Point(213, 66);
            this.txtSkillName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSkillName.Name = "txtSkillName";
            this.txtSkillName.Size = new System.Drawing.Size(298, 30);
            this.txtSkillName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 191);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Years Experience:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Proficiency Level:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Skill Name:";
            // 
            // tabJobs
            // 
            this.tabJobs.Controls.Add(this.dgvAvailableJobs);
            this.tabJobs.Controls.Add(this.groupBox2);
            this.tabJobs.Location = new System.Drawing.Point(4, 34);
            this.tabJobs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabJobs.Name = "tabJobs";
            this.tabJobs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabJobs.Size = new System.Drawing.Size(1165, 654);
            this.tabJobs.TabIndex = 2;
            this.tabJobs.Text = "Available Jobs";
            this.tabJobs.UseVisualStyleBackColor = true;
            // 
            // dgvAvailableJobs
            // 
            this.dgvAvailableJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableJobs.Location = new System.Drawing.Point(9, 156);
            this.dgvAvailableJobs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvAvailableJobs.Name = "dgvAvailableJobs";
            this.dgvAvailableJobs.RowHeadersWidth = 51;
            this.dgvAvailableJobs.RowTemplate.Height = 24;
            this.dgvAvailableJobs.Size = new System.Drawing.Size(1134, 455);
            this.dgvAvailableJobs.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Controls.Add(this.btnSaveJob);
            this.groupBox2.Controls.Add(this.btnSearchJobs);
            this.groupBox2.Controls.Add(this.txtSearchJobs);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(9, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1134, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Jobs";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(783, 47);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(180, 47);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnSaveJob
            // 
            this.btnSaveJob.Location = new System.Drawing.Point(965, 47);
            this.btnSaveJob.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveJob.Name = "btnSaveJob";
            this.btnSaveJob.Size = new System.Drawing.Size(166, 47);
            this.btnSaveJob.TabIndex = 4;
            this.btnSaveJob.Text = "Save Job";
            this.btnSaveJob.UseVisualStyleBackColor = true;
            this.btnSaveJob.Click += new System.EventHandler(this.btnSaveJob_Click);
            // 
            // btnSearchJobs
            // 
            this.btnSearchJobs.Location = new System.Drawing.Point(600, 47);
            this.btnSearchJobs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearchJobs.Name = "btnSearchJobs";
            this.btnSearchJobs.Size = new System.Drawing.Size(180, 47);
            this.btnSearchJobs.TabIndex = 2;
            this.btnSearchJobs.Text = "Search";
            this.btnSearchJobs.UseVisualStyleBackColor = true;
            this.btnSearchJobs.Click += new System.EventHandler(this.btnSearchJobs_Click);
            // 
            // txtSearchJobs
            // 
            this.txtSearchJobs.Location = new System.Drawing.Point(283, 52);
            this.txtSearchJobs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchJobs.Name = "txtSearchJobs";
            this.txtSearchJobs.Size = new System.Drawing.Size(298, 30);
            this.txtSearchJobs.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Search by Title or Industry:";
            // 
            // tabSavedJobs
            // 
            this.tabSavedJobs.Controls.Add(this.dgvSavedJobs);
            this.tabSavedJobs.Location = new System.Drawing.Point(4, 34);
            this.tabSavedJobs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSavedJobs.Name = "tabSavedJobs";
            this.tabSavedJobs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSavedJobs.Size = new System.Drawing.Size(1165, 654);
            this.tabSavedJobs.TabIndex = 3;
            this.tabSavedJobs.Text = "Saved Jobs";
            this.tabSavedJobs.UseVisualStyleBackColor = true;
            // 
            // dgvSavedJobs
            // 
            this.dgvSavedJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSavedJobs.Location = new System.Drawing.Point(9, 9);
            this.dgvSavedJobs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSavedJobs.Name = "dgvSavedJobs";
            this.dgvSavedJobs.RowHeadersWidth = 51;
            this.dgvSavedJobs.RowTemplate.Height = 24;
            this.dgvSavedJobs.Size = new System.Drawing.Size(1134, 602);
            this.dgvSavedJobs.TabIndex = 0;
            // 
            // tabApplications
            // 
            this.tabApplications.Controls.Add(this.dgvApplications);
            this.tabApplications.Location = new System.Drawing.Point(4, 34);
            this.tabApplications.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabApplications.Name = "tabApplications";
            this.tabApplications.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabApplications.Size = new System.Drawing.Size(1165, 654);
            this.tabApplications.TabIndex = 4;
            this.tabApplications.Text = "Applications";
            this.tabApplications.UseVisualStyleBackColor = true;
            // 
            // dgvApplications
            // 
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.Location = new System.Drawing.Point(9, 9);
            this.dgvApplications.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.RowHeadersWidth = 51;
            this.dgvApplications.RowTemplate.Height = 24;
            this.dgvApplications.Size = new System.Drawing.Size(1134, 602);
            this.dgvApplications.TabIndex = 0;
            // 
            // lblApplyErrorMessage
            // 
            this.lblApplyErrorMessage.AutoSize = true;
            this.lblApplyErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblApplyErrorMessage.Location = new System.Drawing.Point(990, 86);
            this.lblApplyErrorMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplyErrorMessage.Name = "lblApplyErrorMessage";
            this.lblApplyErrorMessage.Size = new System.Drawing.Size(0, 25);
            this.lblApplyErrorMessage.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1074, 766);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 47);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // JobSeekerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 866);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblApplyErrorMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "JobSeekerDashboard";
            this.Text = "Job Seeker Dashboard";
            this.tabControl1.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            this.tabSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkills)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableJobs)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabSavedJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavedJobs)).EndInit();
            this.tabApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabSkills;
        private System.Windows.Forms.TabPage tabJobs;
        private System.Windows.Forms.TabPage tabSavedJobs;
        private System.Windows.Forms.TabPage tabApplications;
        private System.Windows.Forms.DataGridView dgvAvailableJobs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearchJobs;
        private System.Windows.Forms.TextBox txtSearchJobs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnSaveJob;
        private System.Windows.Forms.Label lblApplyErrorMessage;
        private System.Windows.Forms.Label lblCurrentCV;
        private System.Windows.Forms.Button btnUploadCV;
        private System.Windows.Forms.Button btnOpenCV;
        private System.Windows.Forms.Button btnChangeCV;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSkills;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddSkill;
        private System.Windows.Forms.TextBox txtYearsExperience;
        private System.Windows.Forms.ComboBox cmbProficiencyLevel;
        private System.Windows.Forms.TextBox txtSkillName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvSavedJobs;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.Button btnLogout;
    }
} 