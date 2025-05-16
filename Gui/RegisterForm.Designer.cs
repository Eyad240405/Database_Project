using System.Drawing;
using System.Windows.Forms;

namespace JobPortalGUI
{
    partial class RegisterForm
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
        /// 


        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.TextBox txtMname;
        private System.Windows.Forms.Label lblMname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.TextBox IndustryId;
        private System.Windows.Forms.Label comname;
        private void InitializeComponent()
        {
            this.AutoScaleMode = AutoScaleMode.Font;

            // Ensure the form starts maximized (optional)
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Prevent the form from being resized too small
            this.MinimumSize = new Size(1024, 600); // Adjust to suit your form's content


            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.lblFname = new System.Windows.Forms.Label();
            this.txtMname = new System.Windows.Forms.TextBox();
            this.lblMname = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.birthdate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.IndustryId = new System.Windows.Forms.TextBox();
            this.comname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbIndustry = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(528, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 20);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Employer";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(375, 48);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 20);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "JobSeeker";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(375, 188);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(239, 22);
            this.textPassword.TabIndex = 13;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(375, 116);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(239, 22);
            this.txtEmail.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(375, 258);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 22);
            this.textBox1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Confirm Password";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(409, 381);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(176, 23);
            this.btnRegister.TabIndex = 16;
            this.btnRegister.Text = "Submit";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(844, 117);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(100, 22);
            this.txtFname.TabIndex = 9;
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Location = new System.Drawing.Point(707, 123);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(75, 16);
            this.lblFname.TabIndex = 0;
            this.lblFname.Text = "First Name:";
            // 
            // txtMname
            // 
            this.txtMname.Location = new System.Drawing.Point(844, 157);
            this.txtMname.Name = "txtMname";
            this.txtMname.Size = new System.Drawing.Size(100, 22);
            this.txtMname.TabIndex = 1;
            // 
            // lblMname
            // 
            this.lblMname.AutoSize = true;
            this.lblMname.Location = new System.Drawing.Point(707, 160);
            this.lblMname.Name = "lblMname";
            this.lblMname.Size = new System.Drawing.Size(91, 16);
            this.lblMname.TabIndex = 2;
            this.lblMname.Text = "Middle Name:";
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(844, 197);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(100, 22);
            this.txtLname.TabIndex = 3;
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Location = new System.Drawing.Point(707, 200);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(75, 16);
            this.lblLname.TabIndex = 4;
            this.lblLname.Text = "Last Name:";
            // 
            // birthdate
            // 
            this.birthdate.Location = new System.Drawing.Point(844, 237);
            this.birthdate.Name = "birthdate";
            this.birthdate.Size = new System.Drawing.Size(100, 22);
            this.birthdate.TabIndex = 5;
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Location = new System.Drawing.Point(707, 240);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(63, 16);
            this.lblBirthdate.TabIndex = 6;
            this.lblBirthdate.Text = "Birthdate:";
            // 
            // IndustryId
            // 
            this.IndustryId.Location = new System.Drawing.Point(844, 277);
            this.IndustryId.Name = "IndustryId";
            this.IndustryId.Size = new System.Drawing.Size(100, 22);
            this.IndustryId.TabIndex = 7;
            // 
            // comname
            // 
            this.comname.AutoSize = true;
            this.comname.Location = new System.Drawing.Point(707, 280);
            this.comname.Name = "comname";
            this.comname.Size = new System.Drawing.Size(108, 16);
            this.comname.TabIndex = 8;
            this.comname.Text = "Company Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(707, 317);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Industry:";
            // 
            // cmbIndustry
            // 
            this.cmbIndustry.Location = new System.Drawing.Point(844, 314);
            this.cmbIndustry.Margin = new System.Windows.Forms.Padding(4);
            this.cmbIndustry.Name = "cmbIndustry";
            this.cmbIndustry.Size = new System.Drawing.Size(183, 24);
            this.cmbIndustry.TabIndex = 18;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbIndustry);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.lblFname);
            this.Controls.Add(this.txtMname);
            this.Controls.Add(this.lblMname);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.lblLname);
            this.Controls.Add(this.birthdate);
            this.Controls.Add(this.lblBirthdate);
            this.Controls.Add(this.IndustryId);
            this.Controls.Add(this.comname);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbIndustry;
        // Declare controls here
        /*private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtMname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.TextBox IndustryId;
        */
    }
}