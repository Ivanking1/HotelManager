

namespace PresentationLayer
{
    public partial class HomeForm : Form
    {
        private User loggedInUser; // Store logged-in user

        public HomeForm(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;  // Store user details

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
            HomeForm homeForm = new HomeForm(loggedInUser);// that would open a new one without closing the previous one
            homeForm.Show();                               //should change thet
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
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        #endregion


    }
}
