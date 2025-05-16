using System.Drawing;
using System.Windows.Forms;

namespace JobPortalGUI
{
    partial class EmployerDashboard
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
            this.lblIndustry = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIndustry = new System.Windows.Forms.ComboBox();
            this.btnSaveIndustry = new System.Windows.Forms.Button();
            this.tabVacancies = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVacancyTitle = new System.Windows.Forms.TextBox();
            this.cmbVacancyIndustry = new System.Windows.Forms.ComboBox();
            this.btnPostVacancy = new System.Windows.Forms.Button();
            this.lblVacancyErrorMessage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvPostedVacancies = new System.Windows.Forms.DataGridView();
            this.btnViewApplications = new System.Windows.Forms.Button();
            this.tabApplications = new System.Windows.Forms.TabPage();
            this.cmbVacanciesFilter = new System.Windows.Forms.ComboBox();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnViewProfile = new System.Windows.Forms.Button();
            this.btnViewCV = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.txtIndustry = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabVacancies.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostedVacancies)).BeginInit();
            this.tabApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProfile);
            this.tabControl1.Controls.Add(this.tabVacancies);
            this.tabControl1.Controls.Add(this.tabApplications);
            this.tabControl1.Location = new System.Drawing.Point(24, 23);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1552, 769);
            this.tabControl1.TabIndex = 0;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.lblIndustry);
            this.tabProfile.Controls.Add(this.lblEmail);
            this.tabProfile.Controls.Add(this.lblName);
            this.tabProfile.Controls.Add(this.label3);
            this.tabProfile.Controls.Add(this.label2);
            this.tabProfile.Controls.Add(this.label1);
            this.tabProfile.Controls.Add(this.cmbIndustry);
            this.tabProfile.Controls.Add(this.btnSaveIndustry);
            this.tabProfile.Location = new System.Drawing.Point(4, 34);
            this.tabProfile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabProfile.Size = new System.Drawing.Size(1544, 731);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // lblIndustry
            // 
            this.lblIndustry.AutoSize = true;
            this.lblIndustry.Location = new System.Drawing.Point(240, 192);
            this.lblIndustry.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblIndustry.Name = "lblIndustry";
            this.lblIndustry.Size = new System.Drawing.Size(64, 25);
            this.lblIndustry.TabIndex = 5;
            this.lblIndustry.Text = "label6";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(240, 116);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(64, 25);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "label5";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(240, 39);
            this.lblName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 25);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Industry:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // cmbIndustry
            // 
            this.cmbIndustry.Location = new System.Drawing.Point(240, 231);
            this.cmbIndustry.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmbIndustry.Name = "cmbIndustry";
            this.cmbIndustry.Size = new System.Drawing.Size(396, 33);
            this.cmbIndustry.TabIndex = 6;
            // 
            // btnSaveIndustry
            // 
            this.btnSaveIndustry.Location = new System.Drawing.Point(660, 231);
            this.btnSaveIndustry.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSaveIndustry.Name = "btnSaveIndustry";
            this.btnSaveIndustry.Size = new System.Drawing.Size(200, 44);
            this.btnSaveIndustry.TabIndex = 7;
            this.btnSaveIndustry.Text = "Save Industry";
            this.btnSaveIndustry.UseVisualStyleBackColor = true;
            this.btnSaveIndustry.Click += new System.EventHandler(this.btnSaveIndustry_Click);
            // 
            // tabVacancies
            // 
            this.tabVacancies.Controls.Add(this.groupBox1);
            this.tabVacancies.Controls.Add(this.dgvPostedVacancies);
            this.tabVacancies.Controls.Add(this.btnViewApplications);
            this.tabVacancies.Location = new System.Drawing.Point(4, 34);
            this.tabVacancies.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabVacancies.Name = "tabVacancies";
            this.tabVacancies.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabVacancies.Size = new System.Drawing.Size(1544, 731);
            this.tabVacancies.TabIndex = 1;
            this.tabVacancies.Text = "Vacancies";
            this.tabVacancies.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVacancyTitle);
            this.groupBox1.Controls.Add(this.cmbVacancyIndustry);
            this.groupBox1.Controls.Add(this.btnPostVacancy);
            this.groupBox1.Controls.Add(this.lblVacancyErrorMessage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(1512, 289);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Post New Vacancy";
            // 
            // txtVacancyTitle
            // 
            this.txtVacancyTitle.Location = new System.Drawing.Point(200, 38);
            this.txtVacancyTitle.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtVacancyTitle.Name = "txtVacancyTitle";
            this.txtVacancyTitle.Size = new System.Drawing.Size(396, 30);
            this.txtVacancyTitle.TabIndex = 2;
            // 
            // cmbVacancyIndustry
            // 
            this.cmbVacancyIndustry.Location = new System.Drawing.Point(972, 38);
            this.cmbVacancyIndustry.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmbVacancyIndustry.Name = "cmbVacancyIndustry";
            this.cmbVacancyIndustry.Size = new System.Drawing.Size(396, 33);
            this.cmbVacancyIndustry.TabIndex = 4;
            // 
            // btnPostVacancy
            // 
            this.btnPostVacancy.Location = new System.Drawing.Point(1298, 228);
            this.btnPostVacancy.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPostVacancy.Name = "btnPostVacancy";
            this.btnPostVacancy.Size = new System.Drawing.Size(200, 44);
            this.btnPostVacancy.TabIndex = 0;
            this.btnPostVacancy.Text = "Post Vacancy";
            this.btnPostVacancy.UseVisualStyleBackColor = true;
            this.btnPostVacancy.Click += new System.EventHandler(this.btnPostVacancy_Click);
            // 
            // lblVacancyErrorMessage
            // 
            this.lblVacancyErrorMessage.AutoSize = true;
            this.lblVacancyErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblVacancyErrorMessage.Location = new System.Drawing.Point(440, 250);
            this.lblVacancyErrorMessage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblVacancyErrorMessage.Name = "lblVacancyErrorMessage";
            this.lblVacancyErrorMessage.Size = new System.Drawing.Size(0, 25);
            this.lblVacancyErrorMessage.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Title:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(816, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Industry:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(200, 100);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(1168, 93);
            this.txtDescription.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Description:";
            // 
            // dgvPostedVacancies
            // 
            this.dgvPostedVacancies.AllowUserToAddRows = false;
            this.dgvPostedVacancies.AllowUserToDeleteRows = false;
            this.dgvPostedVacancies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPostedVacancies.Location = new System.Drawing.Point(12, 311);
            this.dgvPostedVacancies.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvPostedVacancies.Name = "dgvPostedVacancies";
            this.dgvPostedVacancies.ReadOnly = true;
            this.dgvPostedVacancies.RowHeadersWidth = 51;
            this.dgvPostedVacancies.Size = new System.Drawing.Size(1512, 348);
            this.dgvPostedVacancies.TabIndex = 1;
            // 
            // btnViewApplications
            // 
            this.btnViewApplications.Location = new System.Drawing.Point(1284, 673);
            this.btnViewApplications.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnViewApplications.Name = "btnViewApplications";
            this.btnViewApplications.Size = new System.Drawing.Size(240, 44);
            this.btnViewApplications.TabIndex = 0;
            this.btnViewApplications.Text = "View Applications";
            this.btnViewApplications.UseVisualStyleBackColor = true;
            this.btnViewApplications.Click += new System.EventHandler(this.btnViewApplications_Click);
            // 
            // tabApplications
            // 
            this.tabApplications.Controls.Add(this.cmbVacanciesFilter);
            this.tabApplications.Controls.Add(this.dgvApplications);
            this.tabApplications.Controls.Add(this.groupBox2);
            this.tabApplications.Location = new System.Drawing.Point(4, 34);
            this.tabApplications.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabApplications.Name = "tabApplications";
            this.tabApplications.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabApplications.Size = new System.Drawing.Size(1544, 731);
            this.tabApplications.TabIndex = 2;
            this.tabApplications.Text = "Applications";
            this.tabApplications.UseVisualStyleBackColor = true;
            // 
            // cmbVacanciesFilter
            // 
            this.cmbVacanciesFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVacanciesFilter.Location = new System.Drawing.Point(932, 6);
            this.cmbVacanciesFilter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmbVacanciesFilter.Name = "cmbVacanciesFilter";
            this.cmbVacanciesFilter.Size = new System.Drawing.Size(596, 33);
            this.cmbVacanciesFilter.TabIndex = 0;
            this.cmbVacanciesFilter.SelectedIndexChanged += new System.EventHandler(this.cmbVacanciesFilter_SelectedIndexChanged);
            // 
            // dgvApplications
            // 
            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.Location = new System.Drawing.Point(16, 42);
            this.dgvApplications.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.RowHeadersWidth = 51;
            this.dgvApplications.Size = new System.Drawing.Size(1512, 533);
            this.dgvApplications.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewProfile);
            this.groupBox2.Controls.Add(this.btnViewCV);
            this.groupBox2.Controls.Add(this.cmbStatus);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnUpdateStatus);
            this.groupBox2.Location = new System.Drawing.Point(12, 600);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(1512, 108);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Actions";
            // 
            // btnViewProfile
            // 
            this.btnViewProfile.Location = new System.Drawing.Point(1020, 39);
            this.btnViewProfile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnViewProfile.Name = "btnViewProfile";
            this.btnViewProfile.Size = new System.Drawing.Size(200, 44);
            this.btnViewProfile.TabIndex = 4;
            this.btnViewProfile.Text = "View Profile";
            this.btnViewProfile.UseVisualStyleBackColor = true;
            this.btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);
            // 
            // btnViewCV
            // 
            this.btnViewCV.Location = new System.Drawing.Point(800, 39);
            this.btnViewCV.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnViewCV.Name = "btnViewCV";
            this.btnViewCV.Size = new System.Drawing.Size(200, 44);
            this.btnViewCV.TabIndex = 3;
            this.btnViewCV.Text = "View CV";
            this.btnViewCV.UseVisualStyleBackColor = true;
            this.btnViewCV.Click += new System.EventHandler(this.btnViewCV_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Under Review",
            "Shortlisted",
            "Rejected",
            "Hired"});
            this.cmbStatus.Location = new System.Drawing.Point(200, 39);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(396, 33);
            this.cmbStatus.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Status:";
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(620, 39);
            this.btnUpdateStatus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(160, 44);
            this.btnUpdateStatus.TabIndex = 0;
            this.btnUpdateStatus.Text = "Update";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // txtIndustry
            // 
            this.txtIndustry.Location = new System.Drawing.Point(100, 40);
            this.txtIndustry.Name = "txtIndustry";
            this.txtIndustry.Size = new System.Drawing.Size(200, 22);
            this.txtIndustry.TabIndex = 4;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1336, 803);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(240, 44);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // EmployerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 866);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "EmployerDashboard";
            this.Text = "Employer Dashboard";
            this.tabControl1.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            this.tabVacancies.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostedVacancies)).EndInit();
            this.tabApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabVacancies;
        private System.Windows.Forms.TabPage tabApplications;
        private System.Windows.Forms.Label lblIndustry;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIndustry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVacancyTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPostVacancy;
        private System.Windows.Forms.DataGridView dgvPostedVacancies;
        private System.Windows.Forms.Button btnViewApplications;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnViewProfile;
        private System.Windows.Forms.Button btnViewCV;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cmbIndustry;
        private System.Windows.Forms.Button btnSaveIndustry;
        private System.Windows.Forms.ComboBox cmbVacancyIndustry;
        private System.Windows.Forms.Label lblVacancyErrorMessage;
        private System.Windows.Forms.ComboBox cmbVacanciesFilter;
    }
} 