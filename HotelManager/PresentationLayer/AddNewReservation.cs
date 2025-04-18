

using ServiceLayer;

namespace PresentationLayer
{
    public partial class AddNewReservationForm : Form
    {
        private readonly ReservationManager reservationManager;//investigate readonly
        private readonly ClientManager clientManager;
        private readonly RoomManager roomManager;
        private User loggedInUser;
        public AddNewReservationForm(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            reservationManager = new ReservationManager();
            clientManager = new ClientManager();
            roomManager = new RoomManager();
            InitializeComponent();
            LoadClients();
            LoadFreeRooms();
            LoadMealsTypes();
        }
        public AddNewReservationForm(User loggedInUser, ClientManager clientManager, RoomManager roomManager, ReservationManager reservationManager)
        {
            this.loggedInUser = loggedInUser;
            this.clientManager = clientManager;
            this.roomManager = roomManager;
            this.reservationManager = reservationManager;
            InitializeComponent();
            LoadClients();
            LoadFreeRooms();
            LoadMealsTypes();
        }
        #region placeholders

        #endregion
        private void LoadFreeRooms()
        {
            List<Room> exampleRooms = new List<Room>
            {
               new Room(Guid.NewGuid(), 101, RoomEnum.FamilyRoom, true, 100m, 50m),  // Free
               new Room(Guid.NewGuid(), 102, RoomEnum.Suite, true, 150m, 75m),  // Free
               new Room(Guid.NewGuid(), 103, RoomEnum.TwinRoom, false, 200m, 100m) // Occupied (Not shown)
            };

            // Filter only free rooms
            var freeRooms = exampleRooms.Where(room => room.IsAvailable).ToList();

            // Bind to ComboBox
            cmbRoom.Items.Add("Select Room");

            // Add enum values
            foreach (var room in freeRooms)
            {
                cmbRoom.Items.Add(room);
            }


            cmbRoom.SelectedIndex = 0;
            cmbRoom.ForeColor = Color.Gray;


            cmbRoom.SelectedIndexChanged += CmbRoomType_SelectedIndexChanged;

            //using (var db = new HotelManagerDbContext()) // This should be entirely redone
            //{
            //    var freeRooms = db.Rooms
            //        .Where(room => !db.Reservations.Any(res => res.RoomId == room.Id)) // Room is not in any reservation
            //        .ToList();

            //    // Bind to ComboBox
            //    cmbRooms.DataSource = freeRooms;
            //    cmbRooms.DisplayMember = "RoomDetails"; // Display room info
            //    cmbRooms.ValueMember = "Id"; // Store room ID
            //}
        }

        private void CmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedIndex == 0)
            {
                cmbRoom.ForeColor = Color.Gray; // Placeholder color
            }
            else
            {
                cmbRoom.ForeColor = Color.Black; // Normal color
            }
        }
        private void LoadClients()
        {
            List<Client> exampleClients = new List<Client>
            {
              new Client(Guid.NewGuid(), "John", "Doe", "123-456-7890", "john.doe@example.com", 30),
              new Client(Guid.NewGuid(), "Jane", "Smith", "987-654-3210", "jane.smith@example.com", 25),
              new Client(Guid.NewGuid(), "Alice", "Brown", "555-123-4567", "alice.brown@example.com", 28)
            };

            // Bind the list to the CheckedListBox
            clbClients.DataSource = exampleClients;
            clbClients.DisplayMember = "FullName";
            clbClients.ValueMember = "Id";


            clbClients.DataSource = clientManager.ReadAllAsync();
            clbClients.DisplayMember = "FullName"; // Assuming Client has a FullName property
            clbClients.ValueMember = "Id"; // Store the unique ID

        }

        private void LoadMealsTypes()
        {
            cmbMealsType.Items.Add("Select Meals Type");

            // Add enum values
            foreach (var type in Enum.GetValues(typeof(MealsEnum)))
            {
                cmbMealsType.Items.Add(type);
            }


            cmbMealsType.SelectedIndex = 0;
            cmbMealsType.ForeColor = Color.Gray;


            cmbMealsType.SelectedIndexChanged += CmbMealsType_SelectedIndexChanged;
        }
        private void CmbMealsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMealsType.SelectedIndex == 0)
            {
                cmbMealsType.ForeColor = Color.Gray; // Placeholder color
            }
            else
            {
                cmbMealsType.ForeColor = Color.Black; // Normal color
            }
        }

        private void AddNewReservation_Load(object sender, EventArgs e)
        {

        }

        private List<Client> GetSelectedClients()
        {
            return clbClients.CheckedItems
                             .Cast<Client>()  // Assuming DataSource is List<Client>
                             .ToList();
        }

        private void bnAddReservation_Click(object sender, EventArgs e)
        {
            List<Client> selectedGuests = GetSelectedClients();
        }

        private void bnReservationsView_Click(object sender, EventArgs e)
        {
            this.Close();
            ReservationsForm reservationsForm = new ReservationsForm(loggedInUser);
            reservationsForm.Show();
        }
    }
}
