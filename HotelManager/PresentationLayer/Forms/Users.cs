


namespace PresentationLayer
{
    public partial class UsersForm : Form
    {
        private readonly UserManager userManager;
        private List<User> allUsers = new List<User>();
        public UsersForm(IFirebaseClient firebaseClient)
        {
            userManager = new UserManager(firebaseClient);
            InitializeComponent();
            ConfigureMenuPermissions();
            LoadUsersAsync();
        }
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
            

            // Bind the data
            dgvUsers.DataSource = new BindingList<User>(sortedUsers.ToList());

            // Configure grid properties
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AllowUserToAddRows = false; // This removes the empty row

        }
        private void ConfigureDataGridViewColumns()
        {
            dgvUsers.Columns.Clear();

            var columns = new[]
            {
                new { DataProperty = "UserName", Header = "Потребителско име", Type = typeof(string) },
                new { DataProperty = "Role", Header = "Роля", Type = typeof(string) },
                new { DataProperty = "IsActive", Header = "Активност", Type = typeof(bool) },
                new { DataProperty = "Age", Header = "Възраст", Type = typeof(int) },
                new { DataProperty = "Email", Header = "Имейл", Type = typeof(string) },
                new { DataProperty = "PhoneNumber", Header = "Телефон", Type = typeof(string) }
            };

            foreach (var col in columns)
            {
                if (col.Type == typeof(bool))
                {
                    dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn()
                    {
                        DataPropertyName = col.DataProperty,
                        HeaderText = col.Header,
                        ReadOnly = true
                    });
                }
                else
                {
                    dgvUsers.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = col.DataProperty,
                        HeaderText = col.Header,
                        ReadOnly = true
                    });
                }
            }

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;
        }

        private void UsersForm_Shown(object sender, EventArgs e)
        {
            LoadUsersAsync();
        }
        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsersAsync();
        }
        private void UsersForm_Load(object sender, EventArgs e)
        {
            cmbSort.Items.AddRange(new string[] { "потребителско име", "роля", "активност", "възраст" });
            cmbSort.SelectedIndex = 0;

            ConfigureDataGridViewColumns();

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
            FormsContext.AddNewUserForm.ReturnFormToNormal();
            FormsContext.AddNewUserForm?.Show();
        }

        private async void bnEndEmployment_Click(object sender, EventArgs e)
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
                    await userManager.UpdateAsync(newUser);
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
