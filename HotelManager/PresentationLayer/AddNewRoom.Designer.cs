namespace PresentationLayer
{
    partial class AddNewRoom
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
            SuspendLayout();
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomNumber.Location = new Point(198, 227);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(227, 38);
            txtRoomNumber.TabIndex = 7;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(370, 49);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(479, 81);
            lbTitle.TabIndex = 8;
            lbTitle.Text = "Add New Room";
            // 
            // bnAddRoom
            // 
            bnAddRoom.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnAddRoom.Location = new Point(454, 577);
            bnAddRoom.Name = "bnAddRoom";
            bnAddRoom.Size = new Size(302, 70);
            bnAddRoom.TabIndex = 9;
            bnAddRoom.Text = "Add Room";
            bnAddRoom.UseVisualStyleBackColor = true;
            bnAddRoom.Click += bnAddRoom_Click;
            // 
            // txtChildPrice
            // 
            txtChildPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtChildPrice.Location = new Point(768, 227);
            txtChildPrice.Name = "txtChildPrice";
            txtChildPrice.Size = new Size(215, 38);
            txtChildPrice.TabIndex = 11;
            // 
            // txtAdultPrice
            // 
            txtAdultPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdultPrice.Location = new Point(768, 351);
            txtAdultPrice.Name = "txtAdultPrice";
            txtAdultPrice.Size = new Size(215, 38);
            txtAdultPrice.TabIndex = 12;
            // 
            // cmbRoomType
            // 
            cmbRoomType.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(198, 350);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(227, 39);
            cmbRoomType.TabIndex = 13;
            // 
            // AddNewRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 693);
            Controls.Add(cmbRoomType);
            Controls.Add(txtAdultPrice);
            Controls.Add(txtChildPrice);
            Controls.Add(bnAddRoom);
            Controls.Add(lbTitle);
            Controls.Add(txtRoomNumber);
            Name = "AddNewRoom";
            Text = "AddNewRoom";
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
    }
}