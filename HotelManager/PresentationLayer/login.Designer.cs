namespace PresentationLayer
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbTitleLogin = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            bnLogin = new Button();
            lbUsername = new Label();
            lbPassword = new Label();
            bnPasswordVisibility = new Button();
            SuspendLayout();
            // 
            // lbTitleLogin
            // 
            lbTitleLogin.AutoSize = true;
            lbTitleLogin.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitleLogin.Location = new Point(81, 51);
            lbTitleLogin.Name = "lbTitleLogin";
            lbTitleLogin.Size = new Size(440, 81);
            lbTitleLogin.TabIndex = 0;
            lbTitleLogin.Text = "HotelManager";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(176, 222);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(248, 38);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(176, 333);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(248, 38);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += TxtPassword_TextChanged;
            // 
            // bnLogin
            // 
            bnLogin.BackColor = Color.Teal;
            bnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnLogin.Location = new Point(166, 459);
            bnLogin.Name = "bnLogin";
            bnLogin.Size = new Size(272, 90);
            bnLogin.TabIndex = 3;
            bnLogin.Text = "Вход";
            bnLogin.UseVisualStyleBackColor = false;
            bnLogin.Click += bnLogin_ClickAsync;
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUsername.Location = new Point(176, 188);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(246, 31);
            lbUsername.TabIndex = 4;
            lbUsername.Text = "Потребителско име: ";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPassword.Location = new Point(176, 299);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(110, 31);
            lbPassword.TabIndex = 5;
            lbPassword.Text = "Парола: ";
            // 
            // bnPasswordVisibility
            // 
            bnPasswordVisibility.BackColor = SystemColors.Control;
            bnPasswordVisibility.BackgroundImageLayout = ImageLayout.Stretch;
            bnPasswordVisibility.Cursor = Cursors.Hand;
            bnPasswordVisibility.FlatAppearance.BorderSize = 0;
            bnPasswordVisibility.FlatStyle = FlatStyle.Flat;
            bnPasswordVisibility.Image = Properties.Resources.eye_open;
            bnPasswordVisibility.Location = new Point(424, 333);
            bnPasswordVisibility.Name = "bnPasswordVisibility";
            bnPasswordVisibility.Size = new Size(32, 38);
            bnPasswordVisibility.TabIndex = 6;
            bnPasswordVisibility.UseVisualStyleBackColor = false;
            bnPasswordVisibility.Visible = false;
            bnPasswordVisibility.Click += bnPasswordVisibility_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 590);
            Controls.Add(bnPasswordVisibility);
            Controls.Add(lbPassword);
            Controls.Add(lbUsername);
            Controls.Add(bnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lbTitleLogin);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelManager";
            Load += login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitleLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button bnLogin;
        private Label lbUsername;
        private Label lbPassword;
        private Button bnPasswordVisibility;
    }
}
