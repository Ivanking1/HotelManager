

using DataLayer;
using ServiceLayer;

namespace PresentationLayer
{
    public partial class UsersForm : Form
    {
        private User loggedInUser;
        private User? SelectedUser;//for edit
        private readonly UserManager userManager;
        private List<User> allUsers = new List<User>();
        public UsersForm(User loggedInUser)
        {
            userManager = new UserManager();
            this.loggedInUser = loggedInUser;  // Store user details

            InitializeComponent();
            ConfigureMenuPermissions();
            LoadUsersAsync();
        }
        public UsersForm(User loggedInUser, User SelectedUser)//for edit
        {
            userManager = new UserManager();
            this.loggedInUser = loggedInUser;  // Store user details
            this.SelectedUser = SelectedUser;

            InitializeComponent();
            ConfigureMenuPermissions();
            LoadUsersAsync();
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
            this.Close();
            HomeForm homeForm = new HomeForm(loggedInUser);
            homeForm.Show();
        }

        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ReservationsForm reservationsForm = new ReservationsForm(loggedInUser);
            reservationsForm.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ClientsForm clientsForm = new ClientsForm(loggedInUser);
            clientsForm.Show();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            RoomsForm roomsForm = new RoomsForm(loggedInUser);
            roomsForm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            //UsersForm usersForm = new UsersForm(loggedInUser);
            //usersForm.Show();
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        #endregion

        private async void LoadUsersAsync()
        {
            try
            {
                allUsers = (await userManager.ReadAllAsync()).ToList(); // store users

                ApplySorting(); // initial load with sorting (default)

                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsers.MultiSelect = false;
                dgvUsers.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }
        private void ApplySorting()
        {
            IEnumerable<User> sortedUsers = allUsers;

            string selected = cmbSort.SelectedItem?.ToString();

            switch (selected)
            {
                case "потребителско име":
                    sortedUsers = allUsers.OrderBy(u => u.UserName);
                    break;
                case "роля":
                    sortedUsers = allUsers.OrderBy(u => u.Role.ToString());
                    break;
                case "активност":
                    sortedUsers = allUsers.OrderBy(u => u.IsActive);
                    break;
                case "възраст":
                    sortedUsers = allUsers.OrderBy(u => u.Age);
                    break;

                default:
                    break;
            }

            dgvUsers.DataSource = sortedUsers.Select(u => new
            {
                u.UserName,
                u.Role,
                u.IsActive,
                u.Age,
                u.Email,
                u.PhoneNumber
            }).ToList();
        }
        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySorting();
        }
        private void UsersForm_Load(object sender, EventArgs e)
        {
            cmbSort.Items.AddRange(new string[] { "потребителско име", "роля", "активност", "възраст" });
            cmbSort.SelectedIndex = 0;
        }

        private async void bnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.DataBoundItem is User selectedUser)
            {
                var confirm = MessageBox.Show($"Delete user {selectedUser.UserName}?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await userManager.DeleteAsync(selectedUser.Id);
                    LoadUsersAsync(); // Refresh grid
                }
            }
        }

        private void bnEditUser_Click(object sender, EventArgs e)
        {
            this.Close();
            AddNewUserForm addNewUserForm = new AddNewUserForm(loggedInUser);// will add new edit constructor
            addNewUserForm.Show();
        }

        private void bnNewUser_Click(object sender, EventArgs e)
        {
            this.Close();
            AddNewUserForm addNewUserForm = new AddNewUserForm(loggedInUser);
            addNewUserForm.Show();
        }

        
    }
}
