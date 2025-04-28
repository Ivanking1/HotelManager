

namespace PresentationLayer
{
    public partial class ReservationsForm : Form
    {
        private readonly ReservationManager reservationManager;
        private UserManager userManager;
        private ClientManager clientManager;
        private RoomManager roomManager;
        private List<Reservation> allReservations = new List<Reservation>();
        public ReservationsForm(IFirebaseClient firebaseClient)
        {
            userManager = new UserManager(firebaseClient);
            clientManager = new ClientManager(firebaseClient);
            roomManager = new RoomManager(firebaseClient);
            reservationManager = new ReservationManager(firebaseClient);
            InitializeComponent();
            ConfigureMenuPermissions();
            LoadReservationsAsync();
            dgvReservations.AutoGenerateColumns = false;
        }
        public ReservationsForm()
        {
            userManager = new UserManager();
            clientManager = new ClientManager();
            roomManager = new RoomManager();
            reservationManager = new ReservationManager();
            InitializeComponent();
            ConfigureMenuPermissions();
            LoadReservationsAsync();
            dgvReservations.AutoGenerateColumns = false;
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

        private async void LoadReservationsAsync()
        {
            try
            {
                var reservations = await reservationManager.ReadAllAsync(useNavigationalProperties: true);//experimental
                if (reservations == null)
                {
                    MessageBox.Show("No reservations returned from database");
                    return;
                }

                allReservations = reservations.ToList();

                ApplySorting(); // initial load with sorting (default)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading resrvations: {ex.Message}\n\n{ex.InnerException?.Message}");
            }
        }
        private void ApplySorting()
        {
            IEnumerable<Reservation> sortedReservations = allReservations;

            string selected = cmbSort.SelectedItem?.ToString();

            switch (selected)
            {
                case "начална дата":
                    sortedReservations = allReservations.OrderBy(u => u.StartingDate);
                    break;
                case "крайна дата":
                    sortedReservations = allReservations.OrderBy(u => u.EndingDate);
                    break;
                case "брой гости":
                    sortedReservations = allReservations.OrderBy(u => u.Guests.Count());
                    break;
                case "включена храна":
                    sortedReservations = allReservations.OrderBy(u => u.MealPlan);
                    break;
                case "цена на резервация":
                    sortedReservations = allReservations.OrderBy(u => u.Price);
                    break;
                case "стая №":
                    sortedReservations = allReservations
                        .Where(r => r.ReservedRoom != null)
                        .OrderBy(u => u.ReservedRoom.RoomNumber);
                    break;
                default:
                    break;
            }
           
            // Bind the data
            dgvReservations.DataSource = new BindingList<Reservation>(sortedReservations.ToList());

            foreach (DataGridViewRow row in dgvReservations.Rows)
            {
                if (row.DataBoundItem is Reservation reservation)
                {
                    row.Cells["GuestCount"].Value = reservation.Guests.Count;
                    row.Cells["RoomNumber"].Value = reservation.ReservedRoom?.RoomNumber;
                }
            }
        }

        private void ConfigureDataGridView()
        {
            // Clear existing columns
            dgvReservations.Columns.Clear();

            // Configure columns manually
            var columns = new[]
            {
                new { DataProperty = "StartingDate", Header = "Начална дата", Type = typeof(DateTime), ReadOnly = true, Name = (string)null },
                new { DataProperty = "EndingDate", Header = "Крайна дата", Type = typeof(DateTime), ReadOnly = true, Name = (string)null },
                new { DataProperty = "", Header = "Брой гости", Type = typeof(int), ReadOnly = true, Name = "GuestCount" },
                new { DataProperty = "MealPlan", Header = "Включена храна", Type = typeof(string), ReadOnly = true, Name = (string)null },
                new { DataProperty = "Price", Header = "Цена на резервация", Type = typeof(decimal), ReadOnly = true, Name = (string)null },
                new { DataProperty = "RoomNumber", Header = "Стая №", Type = typeof(int), ReadOnly = true,  Name = (string)null }
            };

            foreach (var col in columns)
            {
                DataGridViewColumn column;

                if (col.Type == typeof(bool))
                {
                    column = new DataGridViewCheckBoxColumn();
                }
                else
                {
                    column = new DataGridViewTextBoxColumn();
                }

                column.DataPropertyName = col.DataProperty;
                column.HeaderText = col.Header;
                column.ReadOnly = col.ReadOnly;
                column.Name = col.Name ?? col.DataProperty;
                column.ValueType = col.Type;

                dgvReservations.Columns.Add(column);
            }

            // Format date columns
            dgvReservations.Columns["StartingDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvReservations.Columns["EndingDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

            // Format price column
            dgvReservations.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvReservations.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Configure grid properties
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.MultiSelect = false;


        }
        private void ReservationsForm_Shown(object sender, EventArgs e)
        {
            LoadReservationsAsync();
        }
        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReservationsAsync();
        }
        private void ReservationsForm_Load(object sender, EventArgs e)
        {
            cmbSort.Items.AddRange(new string[] { "начална дата", "крайна дата", "брой гости", "включена храна", "цена на резервация", "стая №" });
            cmbSort.SelectedIndex = 0;

            ConfigureDataGridView();
            
            dgvReservations.ReadOnly = true;

            LoadReservationsAsync();
        }

        private async void bnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow?.DataBoundItem is Reservation selectedReservation)
            {
                var confirm = MessageBox.Show($"Delete selected reservation?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await reservationManager.DeleteAsync(selectedReservation.Id);
                    LoadReservationsAsync(); // Refresh grid
                }
            }
        }

        private void bnEditResrvation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow?.DataBoundItem is Reservation selectedReservation)
            {
                this.Hide();
                FormsContext.AddNewReservationForm.Show();
                FormsContext.AddNewReservationForm.UpdateReservationInForm(selectedReservation);
            }
        }

        private void bnNewReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.AddNewReservationForm.ReturnFormToNormal();
            FormsContext.AddNewReservationForm?.Show();
        }

        #region generate random client
        public static async Task<Reservation> GenerateRandomReservation(
            ClientManager clientManager, RoomManager roomManager, UserManager userManager)
        {
            var random = new Random();

            // Get all available data from managers
            var allClients = await clientManager.ReadAllAsync();
            var allRooms = (await roomManager.ReadAllAsync()).ToList();
            var allUsers = (await userManager.ReadAllAsync()).ToList();

            if (allClients.Count == 0 || allRooms.Count == 0 || allUsers.Count == 0)
                throw new InvalidOperationException("Not enough data in database to create reservation");

            // Select random room, user and clients
            var room = allRooms[random.Next(allRooms.Count)];
            var user = allUsers[random.Next(allUsers.Count)];

            int maxPossibleGuests = Math.Min(room.Capacity, allClients.Count);
            if (maxPossibleGuests < 1)
                throw new InvalidOperationException("Not enough clients to create reservation");

            // Select random number of guests (1 to room capacity)
            int guestCount = random.Next(1, maxPossibleGuests + 1);

            var guests = allClients.Distinct().OrderBy(x => random.Next()).Take(guestCount).ToList();

            // Generate random dates (reservation within next year)
            DateTime startDate = DateTime.Today.AddDays(random.Next(1, 365));
            DateTime endDate = startDate.AddDays(random.Next(1, 15)); // 1-14 night stay

            // Random meal plan
            var mealPlans = Enum.GetValues(typeof(MealsEnum)).Cast<MealsEnum>().ToArray();
            var mealPlan = mealPlans[random.Next(mealPlans.Length)];

            try
            {
                return new Reservation(
                    Guid.NewGuid(),
                    room,
                    user,
                    guests,
                    startDate,
                    endDate,
                    mealPlan
                );
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to create valid reservation", ex);
            }
        }

        private async void bnGenerateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                Reservation randomReservation = await GenerateRandomReservation(
                clientManager, roomManager, userManager);

                await reservationManager.CreateAsync(randomReservation);
                LoadReservationsAsync(); // Refresh grid

                MessageBox.Show("Random reservation generated successfully!",
                     "Success",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Not enough data in database"))
            {
                // Show friendly error message
                MessageBox.Show("Could not generate reservation. Please ensure you have:\n\n" +
                               "- At least 1 available room\n" +
                               "- At least 1 user\n" +
                               "- At least 1 client\n\n" +
                               "Add the required data and try again.",
                               "Insufficient Data",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            { 
                // Handle any other unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
