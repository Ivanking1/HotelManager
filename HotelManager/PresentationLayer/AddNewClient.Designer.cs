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
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(336, 42);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(474, 81);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Add New Client";
            // 
            // bnAddClient
            // 
            bnAddClient.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnAddClient.Location = new Point(424, 616);
            bnAddClient.Name = "bnAddClient";
            bnAddClient.Size = new Size(302, 70);
            bnAddClient.TabIndex = 1;
            bnAddClient.Text = "Add Client";
            bnAddClient.UseVisualStyleBackColor = true;
            bnAddClient.Click += bnAddClient_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(172, 207);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(193, 38);
            txtFirstName.TabIndex = 6;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(172, 333);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(193, 38);
            txtLastName.TabIndex = 8;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNumber.Location = new Point(668, 207);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(193, 38);
            txtPhoneNumber.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(678, 342);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(193, 38);
            txtEmail.TabIndex = 11;
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAge.Location = new Point(172, 432);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(193, 38);
            txtAge.TabIndex = 12;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // bnClientsView
            // 
            bnClientsView.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnClientsView.Location = new Point(804, 634);
            bnClientsView.Name = "bnClientsView";
            bnClientsView.RightToLeft = RightToLeft.No;
            bnClientsView.Size = new Size(300, 52);
            bnClientsView.TabIndex = 13;
            bnClientsView.Text = "Return to clients";
            bnClientsView.UseVisualStyleBackColor = true;
            bnClientsView.Click += bnClientsView_Click;
            // 
            // AddNewClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 715);
            Controls.Add(bnClientsView);
            Controls.Add(txtAge);
            Controls.Add(txtEmail);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(bnAddClient);
            Controls.Add(lbTitle);
            Name = "AddNewClientForm";
            Text = "Add New Client";
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
    }
}