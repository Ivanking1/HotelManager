namespace PresentationLayer
{
    partial class AddNewRoomForm
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
            txtRoomNumber = new TextBox();
            lbTitle = new Label();
            bnAddRoom = new Button();
            txtChildPrice = new TextBox();
            txtAdultPrice = new TextBox();
            cmbRoomType = new ComboBox();
            lbRoomNumber = new Label();
            lbRoomType = new Label();
            lbChieldPrice = new Label();
            lbAdultPrice = new Label();
            lbPrices = new Label();
            bnRoomsView = new Button();
            bnUpdateRoom = new Button();
            SuspendLayout();
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomNumber.Location = new Point(198, 259);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(306, 38);
            txtRoomNumber.TabIndex = 7;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(465, 54);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(324, 81);
            lbTitle.TabIndex = 8;
            lbTitle.Text = "Нова стая";
            // 
            // bnAddRoom
            // 
            bnAddRoom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bnAddRoom.BackColor = Color.Teal;
            bnAddRoom.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnAddRoom.Location = new Point(475, 562);
            bnAddRoom.Name = "bnAddRoom";
            bnAddRoom.Size = new Size(392, 138);
            bnAddRoom.TabIndex = 9;
            bnAddRoom.Text = "Добави\n стая";
            bnAddRoom.UseVisualStyleBackColor = false;
            bnAddRoom.Click += bnAddRoom_Click;
            // 
            // txtChildPrice
            // 
            txtChildPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtChildPrice.Location = new Point(768, 259);
            txtChildPrice.Name = "txtChildPrice";
            txtChildPrice.Size = new Size(260, 38);
            txtChildPrice.TabIndex = 11;
            // 
            // txtAdultPrice
            // 
            txtAdultPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdultPrice.Location = new Point(768, 374);
            txtAdultPrice.Name = "txtAdultPrice";
            txtAdultPrice.Size = new Size(260, 38);
            txtAdultPrice.TabIndex = 12;
            // 
            // cmbRoomType
            // 
            cmbRoomType.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(198, 373);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(306, 39);
            cmbRoomType.TabIndex = 13;
            // 
            // lbRoomNumber
            // 
            lbRoomNumber.AutoSize = true;
            lbRoomNumber.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRoomNumber.Location = new Point(198, 225);
            lbRoomNumber.Name = "lbRoomNumber";
            lbRoomNumber.Size = new Size(180, 31);
            lbRoomNumber.TabIndex = 19;
            lbRoomNumber.Text = "Номер на стая:";
            // 
            // lbRoomType
            // 
            lbRoomType.AutoSize = true;
            lbRoomType.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRoomType.Location = new Point(198, 340);
            lbRoomType.Name = "lbRoomType";
            lbRoomType.Size = new Size(147, 31);
            lbRoomType.TabIndex = 20;
            lbRoomType.Text = "Вид на стая:";
            // 
            // lbChieldPrice
            // 
            lbChieldPrice.AutoSize = true;
            lbChieldPrice.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbChieldPrice.Location = new Point(768, 225);
            lbChieldPrice.Name = "lbChieldPrice";
            lbChieldPrice.Size = new Size(99, 31);
            lbChieldPrice.TabIndex = 21;
            lbChieldPrice.Text = "За дете:";
            // 
            // lbAdultPrice
            // 
            lbAdultPrice.AutoSize = true;
            lbAdultPrice.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbAdultPrice.Location = new Point(768, 340);
            lbAdultPrice.Name = "lbAdultPrice";
            lbAdultPrice.Size = new Size(163, 31);
            lbAdultPrice.TabIndex = 22;
            lbAdultPrice.Text = "За възрастен:";
            // 
            // lbPrices
            // 
            lbPrices.AutoSize = true;
            lbPrices.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPrices.Location = new Point(768, 162);
            lbPrices.Name = "lbPrices";
            lbPrices.Size = new Size(260, 38);
            lbPrices.TabIndex = 23;
            lbPrices.Text = "Цена за нощувка:";
            // 
            // bnRoomsView
            // 
            bnRoomsView.BackColor = Color.Teal;
            bnRoomsView.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnRoomsView.Location = new Point(949, 595);
            bnRoomsView.Name = "bnRoomsView";
            bnRoomsView.RightToLeft = RightToLeft.No;
            bnRoomsView.Size = new Size(300, 105);
            bnRoomsView.TabIndex = 24;
            bnRoomsView.Text = "База даннни\n с клиенти";
            bnRoomsView.UseVisualStyleBackColor = false;
            bnRoomsView.Click += bnRoomsView_Click;
            // 
            // bnUpdateRoom
            // 
            bnUpdateRoom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bnUpdateRoom.BackColor = Color.Teal;
            bnUpdateRoom.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnUpdateRoom.Location = new Point(475, 562);
            bnUpdateRoom.Name = "bnUpdateRoom";
            bnUpdateRoom.Size = new Size(392, 138);
            bnUpdateRoom.TabIndex = 9;
            bnUpdateRoom.Text = "Редактирай\n стая";
            bnUpdateRoom.UseVisualStyleBackColor = false;
            bnUpdateRoom.Click += bnUpdateRoom_Click;
            // 
            // AddNewRoomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(bnUpdateRoom);
            Controls.Add(bnRoomsView);
            Controls.Add(lbPrices);
            Controls.Add(lbAdultPrice);
            Controls.Add(lbChieldPrice);
            Controls.Add(lbRoomType);
            Controls.Add(lbRoomNumber);
            Controls.Add(cmbRoomType);
            Controls.Add(txtAdultPrice);
            Controls.Add(txtChildPrice);
            Controls.Add(bnAddRoom);
            Controls.Add(lbTitle);
            Controls.Add(txtRoomNumber);
            Name = "AddNewRoomForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelManager";
            Load += AddNewRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRoomNumber;
        private Label lbTitle;
        private Button bnAddRoom;
        private DomainUpDown RoomTypeScroll;
        private TextBox txtChildPrice;
        private TextBox txtAdultPrice;
        private ComboBox cmbRoomType;
        private Label lbRoomNumber;
        private Label lbRoomType;
        private Label lbChieldPrice;
        private Label lbAdultPrice;
        private Label lbPrices;
        private Button bnRoomsView;
        private Button bnUpdateRoom;
    }
}