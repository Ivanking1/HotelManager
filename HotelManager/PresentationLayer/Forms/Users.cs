
using System.ComponentModel;


namespace PresentationLayer
{
    public partial class UsersForm : Form
    {
        private readonly UserManager userManager;
        private List<User> allUsers = new List<User>();
        public UsersForm()
        {
            userManager = new UserManager();

            InitializeComponent();
            ConfigureMenuPermissions();
            LoadUsersAsync();
        }


        #region navigation bar
        private void ConfigureMenuPermissions()
        {
            if (FormsContext.LoggedInUser == null)//not neccesarry may remove later
            {
                throw new ArgumentException("not logged in");
            }

            if (FormsContext.LoggedInUser.Role == Role.Administrator)
            {
                reservationsToolStripMenuItem.Enabled = true;
                clientsToolStripMenuItem.Enabled = true;
                roomsToolStripMenuItem.Enabled = true;
                usersToolStripMenuItem.Enabled = true;
            }
            else if (FormsContext.LoggedInUser.Role == Role.Receptionist)
            {
                reservationsToolStripMenuItem.Enabled = true;
                clientsToolStripMenuItem.Enabled = true;
                roomsToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;
            }
            else if (FormsContext.LoggedInUser.Role == Role.Worker)
            {
                reservationsToolStripMenuItem.Enabled = false;
                clientsToolStripMenuItem.Enabled = false;
                roomsToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;
            }

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.HomeForm?.Show();
        }

        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.ReservationsForm?.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.ClientsForm?.Show();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.RoomsForm?.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.UsersForm?.Show();
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close all forms
            FormsContext.HomeForm?.Close();
            FormsContext.ReservationsForm?.Close();
            FormsContext.ClientsForm?.Close();
            FormsContext.RoomsForm?.Close();
            FormsContext.UsersForm?.Close();
            FormsContext.AddNewReservationForm?.Close();
            FormsContext.AddNewClientForm?.Close();
            FormsContext.AddNewRoomForm?.Close();
            FormsContext.AddNewUserForm?.Close();

            // Reset AppContext
            FormsContext.LoggedInUser = null;

            // Return to login
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
        #endregion

        private async void LoadUsersAsync()
        {
            try
            {
                var users = await userManager.ReadAllAsync();
                if (users == null)
                {
                    MessageBox.Show("No users returned from database");
                    return;
                }

                allUsers = users.ToList();

                ApplySorting(); // initial load with sorting (default)
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
            // Clear existing columns if they exist
            dgvUsers.Columns.Clear();

            // Add only the columns we want with Bulgarian headers
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "UserName",
                HeaderText = "Потребителско име"
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Role",
                HeaderText = "Роля"
            });
            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "IsActive",
                HeaderText = "Активност"
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Age",
                HeaderText = "Възраст"
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Email",
                HeaderText = "Имейл"
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "PhoneNumber",
                HeaderText = "Телефон"
            });

            // Bind the data
            dgvUsers.DataSource = new BindingList<User>(sortedUsers.ToList());

            // Configure grid properties
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AllowUserToAddRows = false; // This removes the empty row

        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadUsersAsync(); // Refresh data every time form is shown
        }
        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsersAsync();
        }
        private async void UsersForm_Load(object sender, EventArgs e)
        {
            cmbSort.Items.AddRange(new string[] { "потребителско име", "роля", "активност", "възраст" });
            cmbSort.SelectedIndex = 0;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;

            LoadUsersAsync();
        }

        private async void bnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.DataBoundItem is User selectedUser)
            {
                //if (selectedUser == FormsContext.LoggedInUser)
                //{
                //    return;
                //}
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
            if (dgvUsers.CurrentRow?.DataBoundItem is User selectedUser)
            {
                this.Hide();
                FormsContext.AddNewUserForm.UpdateUserInForm(selectedUser);
                FormsContext.AddNewUserForm.Show();
            }

        }

        private void bnNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.AddNewUserForm?.Show();
        }

        private void bnEndEmployment_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.DataBoundItem is User selectedUser)
            {
                if (selectedUser == FormsContext.LoggedInUser)
                {
                    return;
                }
                if(selectedUser.EndOfEmployment == null)
                {
                    User newUser = new User(selectedUser.Id,
                                        selectedUser.UserName,
                                        selectedUser.Password,  
                                        selectedUser.FirstName,
                                        selectedUser.SecondName,
                                        selectedUser.LastName,
                                        selectedUser.DateOfBirth,
                                        selectedUser.PhoneNumber,
                                        selectedUser.Email,
                                        selectedUser.StartOfEmployment,
                                        false,
                                        DateTime.Now,
                                        selectedUser.Role);
                    LoadUsersAsync();
                }
                else
                {
                    return;
                }
               
            }
        }
    }
}
