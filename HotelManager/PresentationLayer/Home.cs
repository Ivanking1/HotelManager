using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class HomeForm : Form
    {
        private User _loggedInUser; // Store logged-in user

        public HomeForm(User loggedInUser)
        {
            _loggedInUser = loggedInUser;  // Store user details

            InitializeComponent();
            ConfigureMenuPermissions();
        }
        private void ConfigureMenuPermissions()
        {
            if (_loggedInUser.Role == Role.Administrator)
            {
                reservationsToolStripMenuItem.Enabled = true;
                clientsToolStripMenuItem.Enabled = true;
                roomsToolStripMenuItem.Enabled = true;
                usersToolStripMenuItem.Enabled = true;
            }
            else if (_loggedInUser.Role == Role.Receptionist)
            {
                reservationsToolStripMenuItem.Enabled = true;
                clientsToolStripMenuItem.Enabled = true;
                roomsToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;
            }
            else if (_loggedInUser.Role == Role.Worker)
            {
                reservationsToolStripMenuItem.Enabled = false; 
                clientsToolStripMenuItem.Enabled = false;
                roomsToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;
            }
            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeForm homeForm = new HomeForm(_loggedInUser);
            homeForm.Show();
        }

        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReservationsForm reservationsForm = new ReservationsForm();
            reservationsForm.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            clientsForm.Show();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomsForm roomsForm = new RoomsForm();
            roomsForm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();  
            usersForm.Show();
        }
    }
}
