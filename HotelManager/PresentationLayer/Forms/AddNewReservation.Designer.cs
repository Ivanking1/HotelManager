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
            cmbMealPlan = new ComboBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            lbTotalPrice = new Label();
            lbClients = new Label();
            lbRoom = new Label();
            lbMealsType = new Label();
            lbStartingDate = new Label();
            lbEndingDate = new Label();
            cmbRoom = new ComboBox();
            txtTotalPrice = new TextBox();
            bnReservationsView = new Button();
            bnUpdateReservation = new Button();
            bnSearch = new Button();
            txtSearch = new TextBox();
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
            bnAddReservation.Location = new Point(382, 576);
            bnAddReservation.Name = "bnAddReservation";
            bnAddReservation.Size = new Size(500, 132);
            bnAddReservation.TabIndex = 10;
            bnAddReservation.Text = "Добави \nрезервация";
            bnAddReservation.UseVisualStyleBackColor = false;
            bnAddReservation.Click += bnAddReservation_Click;
            // 
            // clbClients
            // 
            clbClients.CheckOnClick = true;
            clbClients.FormattingEnabled = true;
            clbClients.Location = new Point(92, 207);
            clbClients.Name = "clbClients";
            clbClients.Size = new Size(542, 202);
            clbClients.TabIndex = 12;
            clbClients.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbClients_ItemCheck);//
            // 
            // cmbMealPlan
            // 
            cmbMealPlan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMealPlan.FormattingEnabled = true;
            cmbMealPlan.Location = new Point(760, 207);
            cmbMealPlan.Name = "cmbMealPlan";
            cmbMealPlan.Size = new Size(347, 39);
            cmbMealPlan.TabIndex = 14;
            cmbMealPlan.SelectedIndexChanged += new System.EventHandler(this.cmbMealPlan_SelectedIndexChanged);//
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(760, 309);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(347, 27);
            dtpStartDate.TabIndex = 15;
            dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);//
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(760, 390);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(347, 27);
            dtpEndDate.TabIndex = 16;
            dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // lbTotalPrice
            // 
            lbTotalPrice.AutoSize = true;
            lbTotalPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTotalPrice.Location = new Point(760, 455);
            lbTotalPrice.Name = "lbTotalPrice";
            lbTotalPrice.Size = new Size(153, 31);
            lbTotalPrice.TabIndex = 17;
            lbTotalPrice.Text = "Крайна цена:";
            // 
            // lbClients
            // 
            lbClients.AutoSize = true;
            lbClients.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbClients.Location = new Point(92, 173);
            lbClients.Name = "lbClients";
            lbClients.Size = new Size(182, 31);
            lbClients.TabIndex = 18;
            lbClients.Text = "Списък с гости:";
            // 
            // lbRoom
            // 
            lbRoom.AutoSize = true;
            lbRoom.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRoom.Location = new Point(92, 435);
            lbRoom.Name = "lbRoom";
            lbRoom.Size = new Size(69, 31);
            lbRoom.TabIndex = 19;
            lbRoom.Text = "Стая:";
            // 
            // lbMealsType
            // 
            lbMealsType.AutoSize = true;
            lbMealsType.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMealsType.Location = new Point(760, 173);
            lbMealsType.Name = "lbMealsType";
            lbMealsType.Size = new Size(211, 31);
            lbMealsType.TabIndex = 20;
            lbMealsType.Text = "Хранителен план:";
            // 
            // lbStartingDate
            // 
            lbStartingDate.AutoSize = true;
            lbStartingDate.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbStartingDate.Location = new Point(760, 275);
            lbStartingDate.Name = "lbStartingDate";
            lbStartingDate.Size = new Size(247, 31);
            lbStartingDate.TabIndex = 21;
            lbStartingDate.Text = "Дата на настаняване:";
            // 
            // lbEndingDate
            // 
            lbEndingDate.AutoSize = true;
            lbEndingDate.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEndingDate.Location = new Point(760, 356);
            lbEndingDate.Name = "lbEndingDate";
            lbEndingDate.Size = new Size(287, 31);
            lbEndingDate.TabIndex = 22;
            lbEndingDate.Text = "Дата на освобождаване:";
            // 
            // cmbRoom
            // 
            cmbRoom.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(92, 469);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(396, 39);
            cmbRoom.TabIndex = 23;
            cmbRoom.SelectedIndexChanged += new System.EventHandler(this.cmbRoom_SelectedIndexChanged);//
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(908, 459);
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
            // bnUpdateReservation
            // 
            bnUpdateReservation.BackColor = Color.Teal;
            bnUpdateReservation.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnUpdateReservation.Location = new Point(382, 576);
            bnUpdateReservation.Name = "bnUpdateReservation";
            bnUpdateReservation.Size = new Size(500, 132);
            bnUpdateReservation.TabIndex = 10;
            bnUpdateReservation.Text = "Редактирай\n резервация";
            bnUpdateReservation.UseVisualStyleBackColor = false;
            bnUpdateReservation.Click += bnUpdateReservation_Click;
            // 
            // bnSearch
            // 
            bnSearch.Location = new Point(350, 173);
            bnSearch.Name = "bnSearch";
            bnSearch.Size = new Size(94, 29);
            bnSearch.TabIndex = 26;
            bnSearch.Text = "Търси";
            bnSearch.UseVisualStyleBackColor = true;
            bnSearch.Click += new System.EventHandler(this.btnSearchClients_Click);//
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(475, 173);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(144, 27);
            txtSearch.TabIndex = 27;
            txtSearch.TextChanged += new System.EventHandler(this.txtSearchClients_TextChanged);//
            // 
            // AddNewReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(txtSearch);
            Controls.Add(bnSearch);
            Controls.Add(bnUpdateReservation);
            Controls.Add(bnReservationsView);
            Controls.Add(txtTotalPrice);
            Controls.Add(cmbRoom);
            Controls.Add(lbEndingDate);
            Controls.Add(lbStartingDate);
            Controls.Add(lbMealsType);
            Controls.Add(lbRoom);
            Controls.Add(lbClients);
            Controls.Add(lbTotalPrice);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(cmbMealPlan);
            Controls.Add(clbClients);
            Controls.Add(bnAddReservation);
            Controls.Add(lbTitle);
            Name = "AddNewReservationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelManager";
            Load += AddNewReservation_Load;
            Shown += AddNewReservationForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Button bnAddReservation;
        private CheckedListBox clbClients;
        private ComboBox cmbMealPlan;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lbTotalPrice;
        private Label lbClients;
        private Label lbRoom;
        private Label lbMealsType;
        private Label lbStartingDate;
        private Label lbEndingDate;
        private ComboBox cmbRoom;
        private TextBox txtTotalPrice;
        private Button bnReservationsView;
        private Button bnUpdateReservation;
        private Button bnSearch;
        private TextBox txtSearch;
    }
}