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
            listBox1 = new ListBox();
            navigationBarMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // navigationBarMenuStrip
            // 
            navigationBarMenuStrip.BackColor = Color.Teal;
            navigationBarMenuStrip.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            navigationBarMenuStrip.ImageScalingSize = new Size(20, 20);
            navigationBarMenuStrip.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, reservationsToolStripMenuItem, clientsToolStripMenuItem, roomsToolStripMenuItem, usersToolStripMenuItem, logOutToolStripMenuItem });
            navigationBarMenuStrip.Location = new Point(0, 0);
            navigationBarMenuStrip.Margin = new Padding(5);
            navigationBarMenuStrip.Name = "navigationBarMenuStrip";
            navigationBarMenuStrip.Size = new Size(1157, 39);
            navigationBarMenuStrip.TabIndex = 1;
            navigationBarMenuStrip.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.BackColor = Color.Teal;
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(93, 35);
            homeToolStripMenuItem.Text = "Home";
            // 
            // reservationsToolStripMenuItem
            // 
            reservationsToolStripMenuItem.Name = "reservationsToolStripMenuItem";
            reservationsToolStripMenuItem.Size = new Size(164, 35);
            reservationsToolStripMenuItem.Text = "Reservations";
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(101, 35);
            clientsToolStripMenuItem.Text = "Clients";
            // 
            // roomsToolStripMenuItem
            // 
            roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            roomsToolStripMenuItem.Size = new Size(101, 35);
            roomsToolStripMenuItem.Text = "Rooms";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(86, 35);
            usersToolStripMenuItem.Text = "Users";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(114, 35);
            logOutToolStripMenuItem.Text = "Log Out";
            // 
            // bnNewClient
            // 
            bnNewClient.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bnNewClient.Location = new Point(806, 621);
            bnNewClient.Name = "bnNewClient";
            bnNewClient.RightToLeft = RightToLeft.No;
            bnNewClient.Size = new Size(283, 52);
            bnNewClient.TabIndex = 2;
            bnNewClient.Text = "Add new client";
            bnNewClient.UseVisualStyleBackColor = true;
            bnNewClient.Click += bnNewClient_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(139, 81);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(503, 464);
            listBox1.TabIndex = 3;
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 685);
            Controls.Add(listBox1);
            Controls.Add(bnNewClient);
            Controls.Add(navigationBarMenuStrip);
            Name = "ClientsForm";
            Text = "Clients";
            navigationBarMenuStrip.ResumeLayout(false);
            navigationBarMenuStrip.PerformLayout();
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
        private ListBox listBox1;
    }
}