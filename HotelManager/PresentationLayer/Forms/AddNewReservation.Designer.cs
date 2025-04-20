namespace PresentationLayer
{
    partial class AddNewReservationForm
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
            bnAddReservation = new Button();
            clbClients = new CheckedListBox();
            cmbMealsType = new ComboBox();
            dtpStartingDate = new DateTimePicker();
            dtpEndingDate = new DateTimePicker();
            lbTotalPrice = new Label();
            lbClients = new Label();
            lbRoom = new Label();
            lbMealsType = new Label();
            lbStartingDate = new Label();
            lbEndingDate = new Label();
            cmbRoom = new ComboBox();
            txtTotalPrice = new TextBox();
            bnReservationsView = new Button();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(362, 48);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(547, 81);
            lbTitle.TabIndex = 9;
            lbTitle.Text = "Нова резервация";
            // 
            // bnAddReservation
            // 
            bnAddReservation.BackColor = Color.Teal;
            bnAddReservation.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnAddReservation.Location = new Point(382, 590);
            bnAddReservation.Name = "bnAddReservation";
            bnAddReservation.Size = new Size(500, 70);
            bnAddReservation.TabIndex = 10;
            bnAddReservation.Text = "Добави резервация";
            bnAddReservation.UseVisualStyleBackColor = false;
            bnAddReservation.Click += bnAddReservation_Click;
            // 
            // clbClients
            // 
            clbClients.CheckOnClick = true;
            clbClients.FormattingEnabled = true;
            clbClients.Location = new Point(140, 207);
            clbClients.Name = "clbClients";
            clbClients.Size = new Size(396, 158);
            clbClients.TabIndex = 12;
            // 
            // cmbMealsType
            // 
            cmbMealsType.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMealsType.FormattingEnabled = true;
            cmbMealsType.Location = new Point(717, 207);
            cmbMealsType.Name = "cmbMealsType";
            cmbMealsType.Size = new Size(347, 39);
            cmbMealsType.TabIndex = 14;
            // 
            // dtpStartingDate
            // 
            dtpStartingDate.Location = new Point(717, 309);
            dtpStartingDate.Name = "dtpStartingDate";
            dtpStartingDate.Size = new Size(347, 27);
            dtpStartingDate.TabIndex = 15;
            // 
            // dtpEndingDate
            // 
            dtpEndingDate.Location = new Point(717, 390);
            dtpEndingDate.Name = "dtpEndingDate";
            dtpEndingDate.Size = new Size(347, 27);
            dtpEndingDate.TabIndex = 16;
            // 
            // lbTotalPrice
            // 
            lbTotalPrice.AutoSize = true;
            lbTotalPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTotalPrice.Location = new Point(717, 451);
            lbTotalPrice.Name = "lbTotalPrice";
            lbTotalPrice.Size = new Size(153, 31);
            lbTotalPrice.TabIndex = 17;
            lbTotalPrice.Text = "Крайна цена:";
            // 
            // lbClients
            // 
            lbClients.AutoSize = true;
            lbClients.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbClients.Location = new Point(140, 173);
            lbClients.Name = "lbClients";
            lbClients.Size = new Size(182, 31);
            lbClients.TabIndex = 18;
            lbClients.Text = "Списък с гости:";
            // 
            // lbRoom
            // 
            lbRoom.AutoSize = true;
            lbRoom.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRoom.Location = new Point(140, 409);
            lbRoom.Name = "lbRoom";
            lbRoom.Size = new Size(69, 31);
            lbRoom.TabIndex = 19;
            lbRoom.Text = "Стая:";
            // 
            // lbMealsType
            // 
            lbMealsType.AutoSize = true;
            lbMealsType.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMealsType.Location = new Point(717, 173);
            lbMealsType.Name = "lbMealsType";
            lbMealsType.Size = new Size(211, 31);
            lbMealsType.TabIndex = 20;
            lbMealsType.Text = "Хранителен план:";
            // 
            // lbStartingDate
            // 
            lbStartingDate.AutoSize = true;
            lbStartingDate.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbStartingDate.Location = new Point(717, 275);
            lbStartingDate.Name = "lbStartingDate";
            lbStartingDate.Size = new Size(247, 31);
            lbStartingDate.TabIndex = 21;
            lbStartingDate.Text = "Дата на настаняване:";
            // 
            // lbEndingDate
            // 
            lbEndingDate.AutoSize = true;
            lbEndingDate.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEndingDate.Location = new Point(717, 356);
            lbEndingDate.Name = "lbEndingDate";
            lbEndingDate.Size = new Size(287, 31);
            lbEndingDate.TabIndex = 22;
            lbEndingDate.Text = "Дата на освобождаване:";
            // 
            // cmbRoom
            // 
            cmbRoom.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(140, 443);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(396, 39);
            cmbRoom.TabIndex = 23;
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(865, 457);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.ReadOnly = true;
            txtTotalPrice.Size = new Size(199, 27);
            txtTotalPrice.TabIndex = 24;
            txtTotalPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // bnReservationsView
            // 
            bnReservationsView.BackColor = Color.Teal;
            bnReservationsView.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnReservationsView.Location = new Point(968, 603);
            bnReservationsView.Name = "bnReservationsView";
            bnReservationsView.RightToLeft = RightToLeft.No;
            bnReservationsView.Size = new Size(300, 105);
            bnReservationsView.TabIndex = 25;
            bnReservationsView.Text = "База даннни\n с клиенти";
            bnReservationsView.UseVisualStyleBackColor = false;
            bnReservationsView.Click += bnReservationsView_Click;
            // 
            // AddNewReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(bnReservationsView);
            Controls.Add(txtTotalPrice);
            Controls.Add(cmbRoom);
            Controls.Add(lbEndingDate);
            Controls.Add(lbStartingDate);
            Controls.Add(lbMealsType);
            Controls.Add(lbRoom);
            Controls.Add(lbClients);
            Controls.Add(lbTotalPrice);
            Controls.Add(dtpEndingDate);
            Controls.Add(dtpStartingDate);
            Controls.Add(cmbMealsType);
            Controls.Add(clbClients);
            Controls.Add(bnAddReservation);
            Controls.Add(lbTitle);
            Name = "AddNewReservationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelManager";
            Load += AddNewReservation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Button bnAddReservation;
        private CheckedListBox clbClients;
        private ComboBox cmbMealsType;
        private DateTimePicker dtpStartingDate;
        private DateTimePicker dtpEndingDate;
        private Label lbTotalPrice;
        private Label lbClients;
        private Label lbRoom;
        private Label lbMealsType;
        private Label lbStartingDate;
        private Label lbEndingDate;
        private ComboBox cmbRoom;
        private TextBox txtTotalPrice;
        private Button bnReservationsView;
    }
}