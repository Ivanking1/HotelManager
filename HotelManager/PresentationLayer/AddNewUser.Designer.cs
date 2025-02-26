namespace PresentationLayer
{
    partial class AddNewUserForm
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
            lbTitle = new Label();
            bnAddUser = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            txtFirstName = new TextBox();
            txtSecondName = new TextBox();
            txtLastName = new TextBox();
            txtSocialSecurity = new TextBox();
            txtPhoneNumber = new TextBox();
            txtEmail = new TextBox();
            checkAdmin = new CheckBox();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(363, 31);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(437, 81);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Add New User";
            // 
            // bnAddUser
            // 
            bnAddUser.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnAddUser.Location = new Point(461, 545);
            bnAddUser.Name = "bnAddUser";
            bnAddUser.RightToLeft = RightToLeft.No;
            bnAddUser.Size = new Size(285, 80);
            bnAddUser.TabIndex = 1;
            bnAddUser.Text = "Add User";
            bnAddUser.UseVisualStyleBackColor = true;
            bnAddUser.Click += bnAddUser_Click;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(148, 162);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(193, 38);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(148, 265);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(193, 38);
            txtPassword.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(148, 346);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(193, 38);
            txtConfirmPassword.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(461, 162);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(193, 38);
            txtFirstName.TabIndex = 5;
            // 
            // txtSecondName
            // 
            txtSecondName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSecondName.Location = new Point(461, 265);
            txtSecondName.Name = "txtSecondName";
            txtSecondName.Size = new Size(193, 38);
            txtSecondName.TabIndex = 6;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(461, 346);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(193, 38);
            txtLastName.TabIndex = 7;
            // 
            // txtSocialSecurity
            // 
            txtSocialSecurity.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSocialSecurity.Location = new Point(762, 162);
            txtSocialSecurity.Name = "txtSocialSecurity";
            txtSocialSecurity.Size = new Size(193, 38);
            txtSocialSecurity.TabIndex = 8;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNumber.Location = new Point(762, 265);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(193, 38);
            txtPhoneNumber.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(762, 346);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(193, 38);
            txtEmail.TabIndex = 10;
            // 
            // checkAdmin
            // 
            checkAdmin.AutoSize = true;
            checkAdmin.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkAdmin.Location = new Point(762, 436);
            checkAdmin.Name = "checkAdmin";
            checkAdmin.Size = new Size(371, 42);
            checkAdmin.TabIndex = 12;
            checkAdmin.Text = "Administration Privileges";
            checkAdmin.UseVisualStyleBackColor = true;
            // 
            // AddNewUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 682);
            Controls.Add(checkAdmin);
            Controls.Add(txtEmail);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtSocialSecurity);
            Controls.Add(txtLastName);
            Controls.Add(txtSecondName);
            Controls.Add(txtFirstName);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(bnAddUser);
            Controls.Add(lbTitle);
            Name = "AddNewUserForm";
            Text = "Add New User";
            Load += AddNewUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Button bnAddUser;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private TextBox txtFirstName;
        private TextBox txtSecondName;
        private TextBox txtLastName;
        private TextBox txtSocialSecurity;
        private TextBox txtPhoneNumber;
        private TextBox txtEmail;
        private CheckBox checkAdmin;
    }
}