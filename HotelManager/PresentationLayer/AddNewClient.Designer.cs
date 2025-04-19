namespace PresentationLayer
{
    partial class AddNewClientForm
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
            components = new System.ComponentModel.Container();
            lbTitle = new Label();
            bnAddClient = new Button();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtEmail = new TextBox();
            txtAge = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            bnClientsView = new Button();
            lbFirstName = new Label();
            lbLastName = new Label();
            lbAge = new Label();
            lbPhoneNumber = new Label();
            lbEmail = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.None;
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(485, 59);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(287, 81);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Нов гост";
            // 
            // bnAddClient
            // 
            bnAddClient.BackColor = Color.Teal;
            bnAddClient.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnAddClient.Location = new Point(485, 585);
            bnAddClient.Name = "bnAddClient";
            bnAddClient.Size = new Size(344, 70);
            bnAddClient.TabIndex = 1;
            bnAddClient.Text = "Добави гост";
            bnAddClient.UseVisualStyleBackColor = false;
            bnAddClient.Click += bnAddClient_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(198, 207);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(280, 38);
            txtFirstName.TabIndex = 6;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(198, 333);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(280, 38);
            txtLastName.TabIndex = 8;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNumber.Location = new Point(716, 218);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(304, 38);
            txtPhoneNumber.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(716, 342);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(304, 38);
            txtEmail.TabIndex = 11;
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAge.Location = new Point(198, 457);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(280, 38);
            txtAge.TabIndex = 12;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // bnClientsView
            // 
            bnClientsView.BackColor = Color.Teal;
            bnClientsView.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnClientsView.Location = new Point(953, 603);
            bnClientsView.Name = "bnClientsView";
            bnClientsView.RightToLeft = RightToLeft.No;
            bnClientsView.Size = new Size(300, 105);
            bnClientsView.TabIndex = 13;
            bnClientsView.Text = "База даннни\n с клиенти";
            bnClientsView.UseVisualStyleBackColor = false;
            bnClientsView.Click += bnClientsView_Click;
            // 
            // lbFirstName
            // 
            lbFirstName.AutoSize = true;
            lbFirstName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbFirstName.Location = new Point(198, 173);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(144, 31);
            lbFirstName.TabIndex = 14;
            lbFirstName.Text = "Първо име:";
            // 
            // lbLastName
            // 
            lbLastName.AutoSize = true;
            lbLastName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLastName.Location = new Point(198, 299);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(181, 31);
            lbLastName.TabIndex = 15;
            lbLastName.Text = "Последно име:";
            // 
            // lbAge
            // 
            lbAge.AutoSize = true;
            lbAge.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbAge.Location = new Point(198, 423);
            lbAge.Name = "lbAge";
            lbAge.Size = new Size(108, 31);
            lbAge.TabIndex = 16;
            lbAge.Text = "Възраст:";
            // 
            // lbPhoneNumber
            // 
            lbPhoneNumber.AutoSize = true;
            lbPhoneNumber.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPhoneNumber.Location = new Point(716, 184);
            lbPhoneNumber.Name = "lbPhoneNumber";
            lbPhoneNumber.Size = new Size(219, 31);
            lbPhoneNumber.TabIndex = 17;
            lbPhoneNumber.Text = "Телефонен номер:";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(716, 308);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(96, 31);
            lbEmail.TabIndex = 18;
            lbEmail.Text = "Имейл:";
            // 
            // AddNewClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(lbEmail);
            Controls.Add(lbPhoneNumber);
            Controls.Add(lbAge);
            Controls.Add(lbLastName);
            Controls.Add(lbFirstName);
            Controls.Add(bnClientsView);
            Controls.Add(txtAge);
            Controls.Add(txtEmail);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(bnAddClient);
            Controls.Add(lbTitle);
            Name = "AddNewClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelManager";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Button bnAddClient;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtPhoneNumber;
        private TextBox txtEmail;
        private TextBox txtAge;
        private ErrorProvider errorProvider1;
        private Button bnClientsView;
        private Label lbFirstName;
        private Label lbEmail;
        private Label lbPhoneNumber;
        private Label lbAge;
        private Label lbLastName;
    }
}