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
            txtPhoneNumber = new TextBox();
            txtEmail = new TextBox();
            cmbUserRole = new ComboBox();
            dtpDateOfBirth = new DateTimePicker();
            lbUsername = new Label();
            lbPassword = new Label();
            lbConfirmPassword = new Label();
            lbFirstName = new Label();
            lbSecondName = new Label();
            lbLastName = new Label();
            lbPhoneNumber = new Label();
            lbEmail = new Label();
            lbDateOfBirth = new Label();
            lbRole = new Label();
            bnUsersView = new Button();
            bnUpdUser = new Button();
            chkIsActive = new CheckBox();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(389, 31);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(508, 81);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Нов потребител";
            // 
            // bnAddUser
            // 
            bnAddUser.BackColor = Color.Teal;
            bnAddUser.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnAddUser.Location = new Point(399, 591);
            bnAddUser.Name = "bnAddUser";
            bnAddUser.RightToLeft = RightToLeft.No;
            bnAddUser.Size = new Size(512, 80);
            bnAddUser.TabIndex = 1;
            bnAddUser.Text = "Добави потребител";
            bnAddUser.UseVisualStyleBackColor = false;
            bnAddUser.Click += bnAddUser_Click;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(88, 162);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(290, 38);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(88, 265);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(290, 38);
            txtPassword.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(88, 377);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(290, 38);
            txtConfirmPassword.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(495, 162);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(270, 38);
            txtFirstName.TabIndex = 5;
            // 
            // txtSecondName
            // 
            txtSecondName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSecondName.Location = new Point(495, 265);
            txtSecondName.Name = "txtSecondName";
            txtSecondName.Size = new Size(270, 38);
            txtSecondName.TabIndex = 6;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(495, 377);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(270, 38);
            txtLastName.TabIndex = 7;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNumber.Location = new Point(872, 162);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(303, 38);
            txtPhoneNumber.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(872, 265);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(303, 38);
            txtEmail.TabIndex = 10;
            // 
            // cmbUserRole
            // 
            cmbUserRole.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUserRole.FormattingEnabled = true;
            cmbUserRole.Location = new Point(872, 481);
            cmbUserRole.Name = "cmbUserRole";
            cmbUserRole.Size = new Size(303, 39);
            cmbUserRole.TabIndex = 14;
            cmbUserRole.SelectedIndexChanged += CmbUserRole_SelectedIndexChanged;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(872, 384);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(303, 27);
            dtpDateOfBirth.TabIndex = 16;
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUsername.Location = new Point(88, 128);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(240, 31);
            lbUsername.TabIndex = 22;
            lbUsername.Text = "Потребителско име:";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPassword.Location = new Point(88, 231);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(104, 31);
            lbPassword.TabIndex = 23;
            lbPassword.Text = "Парола:";
            // 
            // lbConfirmPassword
            // 
            lbConfirmPassword.AutoSize = true;
            lbConfirmPassword.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbConfirmPassword.Location = new Point(88, 343);
            lbConfirmPassword.Name = "lbConfirmPassword";
            lbConfirmPassword.Size = new Size(218, 31);
            lbConfirmPassword.TabIndex = 24;
            lbConfirmPassword.Text = "Потвърди парола:";
            // 
            // lbFirstName
            // 
            lbFirstName.AutoSize = true;
            lbFirstName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbFirstName.Location = new Point(495, 128);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(144, 31);
            lbFirstName.TabIndex = 25;
            lbFirstName.Text = "Първо име:";
            // 
            // lbSecondName
            // 
            lbSecondName.AutoSize = true;
            lbSecondName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSecondName.Location = new Point(495, 231);
            lbSecondName.Name = "lbSecondName";
            lbSecondName.Size = new Size(137, 31);
            lbSecondName.TabIndex = 26;
            lbSecondName.Text = "Второ име:";
            // 
            // lbLastName
            // 
            lbLastName.AutoSize = true;
            lbLastName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLastName.Location = new Point(495, 343);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(181, 31);
            lbLastName.TabIndex = 27;
            lbLastName.Text = "Последно име:";
            // 
            // lbPhoneNumber
            // 
            lbPhoneNumber.AutoSize = true;
            lbPhoneNumber.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPhoneNumber.Location = new Point(872, 128);
            lbPhoneNumber.Name = "lbPhoneNumber";
            lbPhoneNumber.Size = new Size(219, 31);
            lbPhoneNumber.TabIndex = 28;
            lbPhoneNumber.Text = "Телефонен номер:";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(872, 231);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(96, 31);
            lbEmail.TabIndex = 29;
            lbEmail.Text = "Имейл:";
            // 
            // lbDateOfBirth
            // 
            lbDateOfBirth.AutoSize = true;
            lbDateOfBirth.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDateOfBirth.Location = new Point(872, 350);
            lbDateOfBirth.Name = "lbDateOfBirth";
            lbDateOfBirth.Size = new Size(208, 31);
            lbDateOfBirth.TabIndex = 30;
            lbDateOfBirth.Text = "Дата на раждане:";
            // 
            // lbRole
            // 
            lbRole.AutoSize = true;
            lbRole.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRole.Location = new Point(872, 447);
            lbRole.Name = "lbRole";
            lbRole.Size = new Size(74, 31);
            lbRole.TabIndex = 31;
            lbRole.Text = "Роля:";
            // 
            // bnUsersView
            // 
            bnUsersView.BackColor = Color.Teal;
            bnUsersView.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnUsersView.Location = new Point(968, 603);
            bnUsersView.Name = "bnUsersView";
            bnUsersView.RightToLeft = RightToLeft.No;
            bnUsersView.Size = new Size(300, 105);
            bnUsersView.TabIndex = 32;
            bnUsersView.Text = "База даннни\n с клиенти";
            bnUsersView.UseVisualStyleBackColor = false;
            bnUsersView.Click += bnUsersView_Click;
            // 
            // bnUpdUser
            // 
            bnUpdUser.BackColor = Color.Teal;
            bnUpdUser.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnUpdUser.Location = new Point(399, 591);
            bnUpdUser.Name = "bnUpdUser";
            bnUpdUser.RightToLeft = RightToLeft.No;
            bnUpdUser.Size = new Size(512, 80);
            bnUpdUser.TabIndex = 33;
            bnUpdUser.Text = "Редактирай потребител";
            bnUpdUser.UseVisualStyleBackColor = false;
            bnUpdUser.Click += bnUpdUser_Click;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkIsActive.Location = new Point(495, 481);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(128, 35);
            chkIsActive.TabIndex = 34;
            chkIsActive.Text = "Активен";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // AddNewUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(chkIsActive);
            Controls.Add(bnUpdUser);
            Controls.Add(bnUsersView);
            Controls.Add(lbRole);
            Controls.Add(lbDateOfBirth);
            Controls.Add(lbEmail);
            Controls.Add(lbPhoneNumber);
            Controls.Add(lbLastName);
            Controls.Add(lbSecondName);
            Controls.Add(lbFirstName);
            Controls.Add(lbConfirmPassword);
            Controls.Add(lbPassword);
            Controls.Add(lbUsername);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(cmbUserRole);
            Controls.Add(txtEmail);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtLastName);
            Controls.Add(txtSecondName);
            Controls.Add(txtFirstName);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(bnAddUser);
            Controls.Add(lbTitle);
            Name = "AddNewUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelManager";
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
        private TextBox txtPhoneNumber;
        private TextBox txtEmail;
        private ComboBox cmbUserRole;
        private DateTimePicker dtpDateOfBirth;
        private Label lbUsername;
        private Label lbPassword;
        private Label lbConfirmPassword;
        private Label lbFirstName;
        private Label lbSecondName;
        private Label lbLastName;
        private Label lbPhoneNumber;
        private Label lbEmail;
        private Label lbDateOfBirth;
        private Label lbRole;
        private Button bnUsersView;
        private Button bnUpdUser;
        private CheckBox chkIsActive;
    }
}