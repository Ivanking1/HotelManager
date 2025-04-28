

namespace PresentationLayer
{
    public partial class ClientsForm : Form
    {
        private readonly ClientManager clientManager;
        private List<Client> allClients = new List<Client>();
        public ClientsForm(IFirebaseClient firebaseClient)
        {
            clientManager = new ClientManager(firebaseClient);
            InitializeComponent();
            ConfigureMenuPermissions();
            LoadClientsAsync();
            dgvClients.AutoGenerateColumns = false;
        }
        public ClientsForm()
        {
            clientManager = new ClientManager();
            InitializeComponent();
            ConfigureMenuPermissions();
            LoadClientsAsync();
            dgvClients.AutoGenerateColumns = false;
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

        private async void LoadClientsAsync()
        {
            try
            {
                var clients = await clientManager.ReadAllAsync();
                if (clients == null)
                {
                    MessageBox.Show("No guests returned from database");
                    return;
                }

                allClients = clients.ToList();

                ApplySorting(); // initial load with sorting (default)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading guests: {ex.Message}");
            }
        }
        private void ApplySorting()
        {
            IEnumerable<Client> sortedClients = allClients;

            string selected = cmbSort.SelectedItem?.ToString();

            switch (selected)
            {
                case "пълно име":
                    sortedClients = allClients.OrderBy(u => u.FullName);
                    break;
                case "възраст":
                    sortedClients = allClients.OrderBy(u => u.Age);
                    break;
                default:
                    break;
            }

            // Bind the data
            dgvClients.DataSource = new BindingList<Client>(sortedClients.ToList());
        }
        private void ConfigureDataGridView()
        {
            // Clear existing columns
            dgvClients.Columns.Clear();

            // Define columns with Bulgarian headers
            var columns = new[]
            {
                new { DataProperty = "FullName", Header = "Пълно име", Type = typeof(string) },
                new { DataProperty = "Age", Header = "Възраст", Type = typeof(int) },
                new { DataProperty = "PhoneNumber", Header = "Телефонен номер", Type = typeof(string) },
                new { DataProperty = "Email", Header = "Имейл", Type = typeof(string) }
            };

            // Add columns to DataGridView
            foreach (var col in columns)
            {
                dgvClients.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = col.DataProperty,
                    HeaderText = col.Header,
                    ReadOnly = true
                });
            }

            // Configure grid properties
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.AllowUserToAddRows = false;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.MultiSelect = false;
            dgvClients.ReadOnly = true;
        }
        private void ClientsForm_Shown(object sender, EventArgs e)
        {
            LoadClientsAsync();
        }
        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClientsAsync();
        }
        private void ClientsForm_Load(object sender, EventArgs e)
        {
            cmbSort.Items.AddRange(new string[] { "пълно име", "възраст" });
            cmbSort.SelectedIndex = 0;

            ConfigureDataGridView();

            LoadClientsAsync();
        }
        private async void bnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow?.DataBoundItem is Client selectedClient)
            {
                var confirm = MessageBox.Show($"Delete guest {selectedClient.FullName}?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await clientManager.DeleteAsync(selectedClient.Id);
                    LoadClientsAsync(); // Refresh grid
                }
            }
        }

        private void bnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow?.DataBoundItem is Client selectedClient)
            {
                this.Hide();
                FormsContext.AddNewClientForm.UpdateClientInForm(selectedClient);
                FormsContext.AddNewClientForm.Show();
            }
        }
        private void bnNewClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.AddNewClientForm.ReturnFormToNormal();
            FormsContext.AddNewClientForm?.Show();
        }

        #region generate random client
        public static Client GenerateRandomClient()
        {
            var random = new Random();

            // Sample data collections
            string[] firstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah", "Robert", "Jennifer" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis" };
            string[] domains = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "example.com" };

            // Generate random values
            string firstName = firstNames[random.Next(firstNames.Length)];
            string lastName = lastNames[random.Next(lastNames.Length)];
            string email = $"{firstName.ToLower()}.{lastName.ToLower()}{random.Next(1, 100)}@{domains[random.Next(domains.Length)]}";
            string phone = $"+1{random.Next(200, 999)}{random.Next(100, 999)}{random.Next(1000, 9999)}";
            int age = random.Next(18, 100);

            return new Client(
                Guid.NewGuid(),
                firstName,
                lastName,
                phone,
                email,
                age
            );
        }

        private async void bnGenerateClient_Click(object sender, EventArgs e)
        {
            Client randomClient = GenerateRandomClient();
            await clientManager.CreateAsync(randomClient);
            LoadClientsAsync(); // Refresh grid
        }
        #endregion

    }
}
