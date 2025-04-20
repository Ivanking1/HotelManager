namespace PresentationLayer
{
    partial class UsersForm
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
            dgvUsers = new DataGridView();
            bnDeleteUser = new Button();
            bnEditUser = new Button();
            bnNewUser = new Button();
            cmbSort = new ComboBox();
            lbSort = new Label();
            lbTitle = new Label();
            bnEndEmployment = new Button();
            navigationBarMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
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
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(26, 127);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(817, 581);
            dgvUsers.TabIndex = 2;
            // 
            // bnDeleteUser
            // 
            bnDeleteUser.BackColor = Color.Teal;
            bnDeleteUser.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnDeleteUser.Location = new Point(907, 116);
            bnDeleteUser.Name = "bnDeleteUser";
            bnDeleteUser.RightToLeft = RightToLeft.No;
            bnDeleteUser.Size = new Size(335, 116);
            bnDeleteUser.TabIndex = 6;
            bnDeleteUser.Text = "Изтрий \nслужител";
            bnDeleteUser.UseVisualStyleBackColor = false;
            bnDeleteUser.Click += bnDeleteUser_Click;
            // 
            // bnEditUser
            // 
            bnEditUser.BackColor = Color.Teal;
            bnEditUser.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnEditUser.Location = new Point(907, 272);
            bnEditUser.Name = "bnEditUser";
            bnEditUser.RightToLeft = RightToLeft.No;
            bnEditUser.Size = new Size(335, 116);
            bnEditUser.TabIndex = 7;
            bnEditUser.Text = "Редактирай \nслужител";
            bnEditUser.UseVisualStyleBackColor = false;
            bnEditUser.Click += bnEditUser_Click;
            // 
            // bnNewUser
            // 
            bnNewUser.BackColor = Color.Teal;
            bnNewUser.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnNewUser.Location = new Point(907, 589);
            bnNewUser.Name = "bnNewUser";
            bnNewUser.RightToLeft = RightToLeft.No;
            bnNewUser.Size = new Size(335, 119);
            bnNewUser.TabIndex = 8;
            bnNewUser.Text = "Добави нов\n служител";
            bnNewUser.UseVisualStyleBackColor = false;
            bnNewUser.Click += bnNewUser_Click;
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
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(61, 55);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(241, 54);
            lbTitle.TabIndex = 3;
            lbTitle.Text = "Служители";
            // 
            // bnEndEmployment
            // 
            bnEndEmployment.BackColor = Color.Teal;
            bnEndEmployment.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnEndEmployment.Location = new Point(907, 424);
            bnEndEmployment.Name = "bnEndEmployment";
            bnEndEmployment.RightToLeft = RightToLeft.No;
            bnEndEmployment.Size = new Size(335, 116);
            bnEndEmployment.TabIndex = 9;
            bnEndEmployment.Text = "Уволни \nслужител";
            bnEndEmployment.UseVisualStyleBackColor = false;
            bnEndEmployment.Click += bnEndEmployment_Click;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(bnEndEmployment);
            Controls.Add(lbTitle);
            Controls.Add(lbSort);
            Controls.Add(cmbSort);
            Controls.Add(bnNewUser);
            Controls.Add(bnEditUser);
            Controls.Add(bnDeleteUser);
            Controls.Add(dgvUsers);
            Controls.Add(navigationBarMenuStrip);
            Name = "UsersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelManager";
            Load += UsersForm_Load;
            navigationBarMenuStrip.ResumeLayout(false);
            navigationBarMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
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
        private DataGridView dgvUsers;
        private Button bnDeleteUser;
        private Button bnEditUser;
        private Button bnNewUser;
        private ComboBox cmbSort;
        private Label lbSort;
        private Label lbTitle;
        private Button bnEndEmployment;
    }
}