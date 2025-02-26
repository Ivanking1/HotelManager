namespace PresentationLayer
{
    partial class AddNewReservation
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
            bnAddClient = new Button();
            RoomTypeScroll = new DomainUpDown();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(357, 63);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(479, 81);
            lbTitle.TabIndex = 9;
            lbTitle.Text = "Add New Room";
            // 
            // bnAddClient
            // 
            bnAddClient.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnAddClient.Location = new Point(448, 578);
            bnAddClient.Name = "bnAddClient";
            bnAddClient.Size = new Size(302, 70);
            bnAddClient.TabIndex = 10;
            bnAddClient.Text = "Add Client";
            bnAddClient.UseVisualStyleBackColor = true;
            // 
            // RoomTypeScroll
            // 
            RoomTypeScroll.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoomTypeScroll.Location = new Point(184, 192);
            RoomTypeScroll.Name = "RoomTypeScroll";
            RoomTypeScroll.Size = new Size(252, 38);
            RoomTypeScroll.TabIndex = 11;
            RoomTypeScroll.Text = "TwoSingleBeds";
            // 
            // AddNewReservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 691);
            Controls.Add(RoomTypeScroll);
            Controls.Add(bnAddClient);
            Controls.Add(lbTitle);
            Name = "AddNewReservation";
            Text = "AddNewReservation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Button bnAddClient;
        private DomainUpDown RoomTypeScroll;
    }
}