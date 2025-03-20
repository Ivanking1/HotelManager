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
            cmbRooms = new DomainUpDown();
            clbClients = new CheckedListBox();
            cmbMealsType = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            lbReservationPrice = new Label();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(241, 68);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(643, 81);
            lbTitle.TabIndex = 9;
            lbTitle.Text = "Add New Reservation";
            // 
            // bnAddReservation
            // 
            bnAddReservation.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnAddReservation.Location = new Point(367, 585);
            bnAddReservation.Name = "bnAddReservation";
            bnAddReservation.Size = new Size(431, 70);
            bnAddReservation.TabIndex = 10;
            bnAddReservation.Text = "Add Reservation";
            bnAddReservation.UseVisualStyleBackColor = true;
            // 
            // cmbRooms
            // 
            cmbRooms.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRooms.Location = new Point(140, 375);
            cmbRooms.Name = "cmbRooms";
            cmbRooms.Size = new Size(260, 38);
            cmbRooms.TabIndex = 11;
            // 
            // clbClients
            // 
            clbClients.CheckOnClick = true;
            clbClients.FormattingEnabled = true;
            clbClients.Location = new Point(149, 184);
            clbClients.Name = "clbClients";
            clbClients.Size = new Size(251, 158);
            clbClients.TabIndex = 12;
            // 
            // cmbMealsType
            // 
            cmbMealsType.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMealsType.FormattingEnabled = true;
            cmbMealsType.Location = new Point(717, 207);
            cmbMealsType.Name = "cmbMealsType";
            cmbMealsType.Size = new Size(227, 39);
            cmbMealsType.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(717, 290);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 15;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(717, 353);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 16;
            // 
            // lbReservationPrice
            // 
            lbReservationPrice.AutoSize = true;
            lbReservationPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbReservationPrice.Location = new Point(755, 445);
            lbReservationPrice.Name = "lbReservationPrice";
            lbReservationPrice.Size = new Size(64, 31);
            lbReservationPrice.TabIndex = 17;
            lbReservationPrice.Text = "Price";
            // 
            // AddNewReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 718);
            Controls.Add(lbReservationPrice);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(cmbMealsType);
            Controls.Add(clbClients);
            Controls.Add(cmbRooms);
            Controls.Add(bnAddReservation);
            Controls.Add(lbTitle);
            Name = "AddNewReservationForm";
            Text = "AddNewReservation";
            Load += AddNewReservation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Button bnAddReservation;
        private DomainUpDown cmbRooms;
        private CheckedListBox clbClients;
        private ComboBox cmbMealsType;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label lbReservationPrice;
    }
}