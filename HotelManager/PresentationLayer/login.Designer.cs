﻿namespace PresentationLayer
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
            SuspendLayout();
            // 
            // lbTitleLogin
            // 
            lbTitleLogin.AutoSize = true;
            lbTitleLogin.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitleLogin.Location = new Point(499, 27);
            lbTitleLogin.Name = "lbTitleLogin";
            lbTitleLogin.Size = new Size(193, 81);
            lbTitleLogin.TabIndex = 0;
            lbTitleLogin.Text = "Login";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(499, 159);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(193, 38);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(499, 259);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(193, 38);
            txtPassword.TabIndex = 2;
            // 
            // bnLogin
            // 
            bnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bnLogin.Location = new Point(467, 474);
            bnLogin.Name = "bnLogin";
            bnLogin.Size = new Size(248, 74);
            bnLogin.TabIndex = 3;
            bnLogin.Text = "Login";
            bnLogin.UseVisualStyleBackColor = true;
            bnLogin.Click += bnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 668);
            Controls.Add(bnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lbTitleLogin);
            Name = "LoginForm";
            Text = "LoginPage";
            Load += login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitleLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button bnLogin;
    }
}
