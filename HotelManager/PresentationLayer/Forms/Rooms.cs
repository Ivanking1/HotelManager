

namespace PresentationLayer
{
    public partial class RoomsForm : Form
    {
        private readonly RoomManager roomManager;
        private List<Room> allRooms = new List<Room>();
        public RoomsForm(IFirebaseClient firebaseClient)
        {
            roomManager = new RoomManager(firebaseClient);
            InitializeComponent();
            ConfigureMenuPermissions();
            LoadRoomsAsync();
        }
        public RoomsForm()
        {
            roomManager = new RoomManager();
            InitializeComponent();
            ConfigureMenuPermissions();
            LoadRoomsAsync();
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


        private async void LoadRoomsAsync()
        {
            try
            {
                var rooms = await roomManager.ReadAllAsync();
                if (rooms == null)
                {
                    MessageBox.Show("No rooms returned from database");
                    return;
                }

                allRooms = rooms.ToList();

                ApplySorting(); // initial load with sorting (default)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}");
            }
        }
        private void ApplySorting()
        {
            IEnumerable<Room> sortedRooms = allRooms;

            string selected = cmbSort.SelectedItem?.ToString();

            switch (selected)
            {
                case "номер":
                    sortedRooms = allRooms.OrderBy(u => u.RoomNumber);
                    break;
                case "максимум клиенти":
                    sortedRooms = allRooms.OrderBy(u => u.Capacity);
                    break;
                case "вид на стая":
                    sortedRooms = allRooms.OrderBy(u => u.RoomType.ToString());
                    break;
                case "цена за дете":
                    sortedRooms = allRooms.OrderBy(u => u.ChildPrice);
                    break;
                case "цена за възрастен":
                    sortedRooms = allRooms.OrderBy(u => u.AdultPrice);
                    break;

                default:
                    break;
            }
           
            // Bind the data
            dgvRooms.DataSource = new BindingList<Room>(sortedRooms.ToList());
        }
        private void ConfigureDataGridView()
        {
            // Clear existing columns
            dgvRooms.Columns.Clear();

            // Define columns with Bulgarian headers
            var columns = new[]
            {
                new { DataProperty = "RoomNumber", Header = "Номер", Type = typeof(int), Format = "" },
                new { DataProperty = "RoomType", Header = "Вид стая", Type = typeof(string), Format = "" },
                new { DataProperty = "Capacity", Header = "Максимум клиенти", Type = typeof(int), Format = "" },
                new { DataProperty = "ChildPrice", Header = "Цена за дете", Type = typeof(decimal), Format = "C2" },
                new { DataProperty = "AdultPrice", Header = "Цена за възрастен", Type = typeof(decimal), Format = "C2" }
            };

            foreach (var col in columns)
            {
                dgvRooms.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = col.DataProperty,
                    HeaderText = col.Header,
                    ReadOnly = true
                });
            }

            // Configure grid properties
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.MultiSelect = false;
            dgvRooms.ReadOnly = true;
        }
        private void RoomsForm_Shown(object sender, EventArgs e)
        {
            LoadRoomsAsync();
        }
        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomsAsync();
        }
        private void RoomsForm_Load(object sender, EventArgs e)
        {
            cmbSort.Items.AddRange(new string[] { "номер", "вид на стая", "максимум клиенти", "цена за дете", "цена за възрастен" });
            cmbSort.SelectedIndex = 0;

            ConfigureDataGridView();

            LoadRoomsAsync();
        }


        private async void bnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow?.DataBoundItem is Room selectedRoom)
            {
                var confirm = MessageBox.Show($"Delete room {selectedRoom.RoomNumber}?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await roomManager.DeleteAsync(selectedRoom.Id);
                    LoadRoomsAsync(); // Refresh grid
                }
            }
        }

        private void bnEditRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow?.DataBoundItem is Room selectedRoom)
            {
                this.Hide();
                FormsContext.AddNewRoomForm.UpdateRoomInForm(selectedRoom);
                FormsContext.AddNewRoomForm.Show();
            }
        }
        private void bnNewRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.AddNewRoomForm.ReturnFormToNormal();
            FormsContext.AddNewRoomForm?.Show();
        }

        #region generate random client
        public static Room GenerateRandomRoom(int? fixedRoomNumber = null)
        {
            var random = new Random();

            // Room type distribution (some types are more common)
            RoomEnum[] roomTypeDistribution =
            {
                RoomEnum.SingleRoom, RoomEnum.SingleRoom, RoomEnum.SingleRoom,
                RoomEnum.TwinRoom, RoomEnum.TwinRoom,
                RoomEnum.DoubleRoom, RoomEnum.DoubleRoom,
                RoomEnum.FamilyRoom,
                RoomEnum.Suite,
                RoomEnum.Penthouse
            };

            RoomEnum roomType = roomTypeDistribution[random.Next(roomTypeDistribution.Length)];

            // Base prices with more realistic ranges
            (decimal minAdult, decimal maxAdult) = roomType switch
            {
                RoomEnum.SingleRoom => (40m, 80m),
                RoomEnum.TwinRoom => (60m, 100m),
                RoomEnum.DoubleRoom => (80m, 130m),
                RoomEnum.FamilyRoom => (120m, 200m),
                RoomEnum.Suite => (200m, 400m),
                RoomEnum.Penthouse => (400m, 1000m),
                _ => (50m, 100m)
            };

            decimal adultPrice = minAdult + (decimal)(random.NextDouble() * (double)(maxAdult - minAdult));
            decimal childPrice = adultPrice * (0.5m + (decimal)(random.NextDouble() * 0.2)); // 50-70% of adult price

            // Room number allocation by floor (assuming 3 floors)
            int floor = random.Next(1, 4);
            int roomNumber = fixedRoomNumber ?? (floor * 100 + random.Next(1, 30));

            // More sophisticated availability (penthouse is rarely available)
            bool isAvailable = roomType == RoomEnum.Penthouse
                ? random.Next(4) == 0  // 25% chance
                : random.Next(10) < 8;  // 80% chance

            return new Room(
                Guid.NewGuid(),
                roomNumber,
                roomType,
                isAvailable,
                Math.Round(adultPrice, 2),
                Math.Round(childPrice, 2)
            );
        }

        private async void bnGenerateRoom_Click(object sender, EventArgs e)
        {
            Room randomRoom = GenerateRandomRoom();
            await roomManager.CreateAsync(randomRoom);
            LoadRoomsAsync(); // Refresh grid
        }
        #endregion

    }
}
