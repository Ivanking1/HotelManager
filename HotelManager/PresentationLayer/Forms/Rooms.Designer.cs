namespace PresentationLayer
{
    partial class RoomsForm
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
            navigationBarMenuStrip = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            reservationsToolStripMenuItem = new ToolStripMenuItem();
            clientsToolStripMenuItem = new ToolStripMenuItem();
            roomsToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            bnDeleteRoom = new Button();
            bnEditRoom = new Button();
            bnNewRoom = new Button();
            dgvRooms = new DataGridView();
            lbTitle = new Label();
            lbSort = new Label();
            cmbSort = new ComboBox();
            bnGenerateRoom = new Button();
            navigationBarMenuStrip.SuspendLayout();
            ((ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // navigationBarMenuStrip
            // 
            navigationBarMenuStrip.BackColor = Color.Teal;
            navigationBarMenuStrip.Font = new Font("Segoe UI", 15.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            navigationBarMenuStrip.ImageScalingSize = new Size(20, 20);
            navigationBarMenuStrip.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, reservationsToolStripMenuItem, clientsToolStripMenuItem, roomsToolStripMenuItem, usersToolStripMenuItem, logOutToolStripMenuItem });
            navigationBarMenuStrip.Location = new Point(0, 0);
            navigationBarMenuStrip.Margin = new Padding(5);
            navigationBarMenuStrip.Name = "navigationBarMenuStrip";
            navigationBarMenuStrip.Size = new Size(1280, 45);
            navigationBarMenuStrip.TabIndex = 1;
            navigationBarMenuStrip.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.BackColor = Color.Teal;
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(131, 41);
            homeToolStripMenuItem.Text = "Начало";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            // 
            // reservationsToolStripMenuItem
            // 
            reservationsToolStripMenuItem.Name = "reservationsToolStripMenuItem";
            reservationsToolStripMenuItem.Size = new Size(190, 41);
            reservationsToolStripMenuItem.Text = "Резервации";
            reservationsToolStripMenuItem.Click += reservationsToolStripMenuItem_Click;
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(102, 41);
            clientsToolStripMenuItem.Text = "Гости";
            clientsToolStripMenuItem.Click += clientsToolStripMenuItem_Click;
            // 
            // roomsToolStripMenuItem
            // 
            roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            roomsToolStripMenuItem.Size = new Size(92, 41);
            roomsToolStripMenuItem.Text = "Стаи";
            roomsToolStripMenuItem.Click += roomsToolStripMenuItem_Click;
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(179, 41);
            usersToolStripMenuItem.Text = "Служители";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(290, 41);
            logOutToolStripMenuItem.Text = "Излизане от акаунт";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // bnDeleteRoom
            // 
            bnDeleteRoom.BackColor = Color.Teal;
            bnDeleteRoom.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnDeleteRoom.Location = new Point(907, 116);
            bnDeleteRoom.Name = "bnDeleteRoom";
            bnDeleteRoom.RightToLeft = RightToLeft.No;
            bnDeleteRoom.Size = new Size(335, 116);
            bnDeleteRoom.TabIndex = 6;
            bnDeleteRoom.Text = "Изтрий \nстая";
            bnDeleteRoom.UseVisualStyleBackColor = false;
            bnDeleteRoom.Click += bnDeleteRoom_Click;
            // 
            // bnEditRoom
            // 
            bnEditRoom.BackColor = Color.Teal;
            bnEditRoom.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnEditRoom.Location = new Point(907, 272);
            bnEditRoom.Name = "bnEditRoom";
            bnEditRoom.RightToLeft = RightToLeft.No;
            bnEditRoom.Size = new Size(335, 116);
            bnEditRoom.TabIndex = 7;
            bnEditRoom.Text = "Редактирай \nстая";
            bnEditRoom.UseVisualStyleBackColor = false;
            bnEditRoom.Click += bnEditRoom_Click;
            // 
            // bnNewRoom
            // 
            bnNewRoom.BackColor = Color.Teal;
            bnNewRoom.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnNewRoom.Location = new Point(907, 589);
            bnNewRoom.Name = "bnNewRoom";
            bnNewRoom.RightToLeft = RightToLeft.No;
            bnNewRoom.Size = new Size(335, 119);
            bnNewRoom.TabIndex = 8;
            bnNewRoom.Text = "Добави нова\n стая";
            bnNewRoom.UseVisualStyleBackColor = false;
            bnNewRoom.Click += bnNewRoom_Click;
            // 
            // dgvRooms
            // 
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Location = new Point(26, 127);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.Size = new Size(774, 581);
            dgvRooms.TabIndex = 2;
            dgvRooms.AutoGenerateColumns = false;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(61, 55);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(112, 54);
            lbTitle.TabIndex = 3;
            lbTitle.Text = "Стаи";
            // 
            // lbSort
            // 
            lbSort.AutoSize = true;
            lbSort.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSort.Location = new Point(389, 75);
            lbSort.Name = "lbSort";
            lbSort.Size = new Size(146, 28);
            lbSort.TabIndex = 4;
            lbSort.Text = "Сортиране по";
            // 
            // cmbSort
            // 
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(541, 79);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(218, 28);
            cmbSort.TabIndex = 5;
            cmbSort.SelectedIndexChanged += CmbSort_SelectedIndexChanged;
            // 
            // bnGenerateRoom
            // 
            bnGenerateRoom.BackColor = Color.Teal;
            bnGenerateRoom.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnGenerateRoom.Location = new Point(956, 452);
            bnGenerateRoom.Name = "bnGenerateRoom";
            bnGenerateRoom.Size = new Size(235, 70);
            bnGenerateRoom.TabIndex = 9;
            bnGenerateRoom.Text = "Generate room";
            bnGenerateRoom.UseVisualStyleBackColor = false;
            bnGenerateRoom.Visible = false;
            bnGenerateRoom.Click += bnGenerateRoom_Click;
            // 
            // RoomsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1280, 720);
            Controls.Add(bnGenerateRoom);
            Controls.Add(cmbSort);
            Controls.Add(lbSort);
            Controls.Add(lbTitle);
            Controls.Add(dgvRooms);
            Controls.Add(bnNewRoom);
            Controls.Add(bnEditRoom);
            Controls.Add(bnDeleteRoom);
            Controls.Add(navigationBarMenuStrip);
            Name = "RoomsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelManager";
            Load += RoomsForm_Load;
            Shown += RoomsForm_Shown;
            navigationBarMenuStrip.ResumeLayout(false);
            navigationBarMenuStrip.PerformLayout();
            ((ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip navigationBarMenuStrip;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem reservationsToolStripMenuItem;
        private ToolStripMenuItem clientsToolStripMenuItem;
        private ToolStripMenuItem roomsToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private Button bnDeleteRoom;
        private Button bnEditRoom;
        private Button bnNewRoom;
        private DataGridView dgvRooms;
        private Label lbTitle;
        private Label lbSort;
        private ComboBox cmbSort;
        private Button bnGenerateRoom;
    }
}