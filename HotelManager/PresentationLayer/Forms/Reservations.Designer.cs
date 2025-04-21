namespace PresentationLayer
{
    partial class ReservationsForm
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
            dgvReservations = new DataGridView();
            bnDeleteReservation = new Button();
            bnEditResrvation = new Button();
            bnNewReservation = new Button();
            lbTitle = new Label();
            lbSort = new Label();
            cmbSort = new ComboBox();
            bnGenerateReservation = new Button();
            navigationBarMenuStrip.SuspendLayout();
            ((ISupportInitialize)dgvReservations).BeginInit();
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
            // dgvReservations
            // 
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Location = new Point(26, 127);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.Size = new Size(774, 581);
            dgvReservations.TabIndex = 2;
            // 
            // bnDeleteReservation
            // 
            bnDeleteReservation.BackColor = Color.Teal;
            bnDeleteReservation.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnDeleteReservation.Location = new Point(907, 116);
            bnDeleteReservation.Name = "bnDeleteReservation";
            bnDeleteReservation.RightToLeft = RightToLeft.No;
            bnDeleteReservation.Size = new Size(335, 116);
            bnDeleteReservation.TabIndex = 6;
            bnDeleteReservation.Text = "Изтрий \nрезервация";
            bnDeleteReservation.UseVisualStyleBackColor = false;
            bnDeleteReservation.Click += bnDeleteReservation_Click;
            // 
            // bnEditResrvation
            // 
            bnEditResrvation.BackColor = Color.Teal;
            bnEditResrvation.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnEditResrvation.Location = new Point(907, 272);
            bnEditResrvation.Name = "bnEditResrvation";
            bnEditResrvation.RightToLeft = RightToLeft.No;
            bnEditResrvation.Size = new Size(335, 116);
            bnEditResrvation.TabIndex = 7;
            bnEditResrvation.Text = "Редактирай \nрезервация";
            bnEditResrvation.UseVisualStyleBackColor = false;
            bnEditResrvation.Click += bnEditResrvation_Click;
            // 
            // bnNewReservation
            // 
            bnNewReservation.BackColor = Color.Teal;
            bnNewReservation.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnNewReservation.Location = new Point(907, 589);
            bnNewReservation.Name = "bnNewReservation";
            bnNewReservation.RightToLeft = RightToLeft.No;
            bnNewReservation.Size = new Size(335, 119);
            bnNewReservation.TabIndex = 8;
            bnNewReservation.Text = "Добави нов\n резервация";
            bnNewReservation.UseVisualStyleBackColor = false;
            bnNewReservation.Click += bnNewReservation_Click;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(61, 55);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(256, 54);
            lbTitle.TabIndex = 3;
            lbTitle.Text = "Резервации";
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
            // bnGenerateReservation
            // 
            bnGenerateReservation.BackColor = Color.Teal;
            bnGenerateReservation.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnGenerateReservation.Location = new Point(907, 452);
            bnGenerateReservation.Name = "bnGenerateReservation";
            bnGenerateReservation.Size = new Size(335, 70);
            bnGenerateReservation.TabIndex = 9;
            bnGenerateReservation.Text = "Generate reservation";
            bnGenerateReservation.UseVisualStyleBackColor = false;
            bnGenerateReservation.Click += bnGenerateReservation_Click;
            // 
            // ReservationsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(bnGenerateReservation);
            Controls.Add(cmbSort);
            Controls.Add(lbSort);
            Controls.Add(lbTitle);
            Controls.Add(bnNewReservation);
            Controls.Add(bnEditResrvation);
            Controls.Add(bnDeleteReservation);
            Controls.Add(dgvReservations);
            Controls.Add(navigationBarMenuStrip);
            Name = "ReservationsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelManager";
            Load += ReservationsForm_Load;
            Shown += ReservationsForm_Shown;
            navigationBarMenuStrip.ResumeLayout(false);
            navigationBarMenuStrip.PerformLayout();
            ((ISupportInitialize)dgvReservations).EndInit();
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
        private DataGridView dgvReservations;
        private Button bnDeleteReservation;
        private Button bnEditResrvation;
        private Button bnNewReservation;
        private Label lbTitle;
        private Label lbSort;
        private ComboBox cmbSort;
        private Button bnGenerateReservation;
    }
}