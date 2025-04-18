﻿namespace PresentationLayer
{
    partial class ClientsForm
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
            bnNewClient = new Button();
            dgvClients = new DataGridView();
            bnDeleteClient = new Button();
            bnEditClient = new Button();
            lbTitle = new Label();
            lbSort = new Label();
            cmbSort = new ComboBox();
            navigationBarMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();

            #region navigation design
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
            // 
            // reservationsToolStripMenuItem
            // 
            reservationsToolStripMenuItem.Name = "reservationsToolStripMenuItem";
            reservationsToolStripMenuItem.Size = new Size(190, 41);
            reservationsToolStripMenuItem.Text = "Резервации";
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(102, 41);
            clientsToolStripMenuItem.Text = "Гости";
            // 
            // roomsToolStripMenuItem
            // 
            roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            roomsToolStripMenuItem.Size = new Size(92, 41);
            roomsToolStripMenuItem.Text = "Стаи";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(179, 41);
            usersToolStripMenuItem.Text = "Служители";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(290, 41);
            logOutToolStripMenuItem.Text = "Излизане от акаунт";
            #endregion

           
            // 
            // dgvClients
            // 
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(26, 127);
            dgvClients.Name = "dgvClients";
            dgvClients.RowHeadersWidth = 51;
            dgvClients.Size = new Size(774, 581);
            dgvClients.TabIndex = 2;
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
            // 
            // bnDeleteClient
            // 
            bnDeleteClient.BackColor = Color.Teal;
            bnDeleteClient.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnDeleteClient.Location = new Point(875, 116);
            bnDeleteClient.Name = "bnDeleteClient";
            bnDeleteClient.RightToLeft = RightToLeft.No;
            bnDeleteClient.Size = new Size(335, 116);
            bnDeleteClient.TabIndex = 6;
            bnDeleteClient.Text = "Изтрий \nгост";
            bnDeleteClient.UseVisualStyleBackColor = false;
            // 
            // bnEditClient
            // 
            bnEditClient.BackColor = Color.Teal;
            bnEditClient.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnEditClient.Location = new Point(875, 291);
            bnEditClient.Name = "bnEditClient";
            bnEditClient.RightToLeft = RightToLeft.No;
            bnEditClient.Size = new Size(335, 116);
            bnEditClient.TabIndex = 7;
            bnEditClient.Text = "Редактирай \nгост";
            bnEditClient.UseVisualStyleBackColor = false;
            // 
            // bnNewClient
            // 
            bnNewClient.BackColor = Color.Teal;
            bnNewClient.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnNewClient.Location = new Point(875, 589);
            bnNewClient.Name = "bnNewClient";
            bnNewClient.RightToLeft = RightToLeft.No;
            bnNewClient.Size = new Size(335, 119);
            bnNewClient.TabIndex = 8;
            bnNewClient.Text = "Добави нов\n гост";
            bnNewClient.UseVisualStyleBackColor = false;
            bnNewClient.Click += bnNewClient_Click;
            
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(cmbSort);
            Controls.Add(lbSort);
            Controls.Add(lbTitle);
            Controls.Add(bnEditClient);
            Controls.Add(bnDeleteClient);
            Controls.Add(dgvClients);
            Controls.Add(bnNewClient);
            Controls.Add(navigationBarMenuStrip);
            Name = "ClientsForm";
            Text = "HotelManager";
            navigationBarMenuStrip.ResumeLayout(false);
            navigationBarMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
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
        private Button bnNewClient;
        private DataGridView dgvClients;
        private Button bnDeleteClient;
        private Button bnEditClient;
        private Label lbTitle;
        private Label lbSort;
        private ComboBox cmbSort;
    }
}