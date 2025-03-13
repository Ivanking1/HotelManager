

namespace PresentationLayer
{
    public partial class ReservationsForm : Form
    {
        private User loggedInUser;
        public ReservationsForm(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            InitializeComponent();
            ConfigureMenuPermissions();
        }
        #region navigation bar
        private void ConfigureMenuPermissions()
        {
            if (loggedInUser.Role == Role.Administrator)
            {
                reservationsToolStripMenuItem.Enabled = true;
                clientsToolStripMenuItem.Enabled = true;
                roomsToolStripMenuItem.Enabled = true;
                usersToolStripMenuItem.Enabled = true;
            }
            else if (loggedInUser.Role == Role.Receptionist)
            {
                reservationsToolStripMenuItem.Enabled = true;
                clientsToolStripMenuItem.Enabled = true;
                roomsToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;
            }
            else if (loggedInUser.Role == Role.Worker)
            {
                reservationsToolStripMenuItem.Enabled = false;
                clientsToolStripMenuItem.Enabled = false;
                roomsToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;
            }

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeForm homeForm = new HomeForm(loggedInUser);
            homeForm.Show();
        }

        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReservationsForm reservationsForm = new ReservationsForm(loggedInUser);
            reservationsForm.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm(loggedInUser);
            clientsForm.Show();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomsForm roomsForm = new RoomsForm(loggedInUser);
            roomsForm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm(loggedInUser);
            usersForm.Show();
        }
        #endregion

    }
}
