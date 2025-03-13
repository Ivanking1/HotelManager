

namespace PresentationLayer
{
    public partial class AddNewReservation : Form
    {
        public AddNewReservation()
        {
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
               new Room(101, RoomEnum.Apartment, true, 100m, 50m),  // Free
               new Room(102, RoomEnum.TwoSingleBeds, true, 150m, 75m),  // Free
               new Room(103, RoomEnum.DoubleBed, false, 200m, 100m) // Occupied (Not shown)
            };

            // Filter only free rooms
            var freeRooms = exampleRooms.Where(room => room.IsFree).ToList();

            // Bind to ComboBox
            cmbRooms.Items.Add("Select Room");

            // Add enum values
            foreach (var room in freeRooms)
            {
                cmbRooms.Items.Add(room);
            }


            cmbRooms.SelectedIndex = 0;
            cmbRooms.ForeColor = Color.Gray;


            cmbRooms.SelectedItemChanged += CmbRoomType_SelectedIndexChanged;

            //using (var db = new HotelManagerDbContext()) // Your DbContext
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
            if (cmbRooms.SelectedIndex == 0)
            {
                cmbRooms.ForeColor = Color.Gray; // Placeholder color
            }
            else
            {
                cmbRooms.ForeColor = Color.Black; // Normal color
            }
        }
        private void LoadClients()
        {
            List<Client> exampleClients = new List<Client>
            {
              new Client("John", "Doe", "123-456-7890", "john.doe@example.com", 30),
              new Client("Jane", "Smith", "987-654-3210", "jane.smith@example.com", 25),
              new Client("Alice", "Brown", "555-123-4567", "alice.brown@example.com", 28)
            };

            // Bind the list to the CheckedListBox
            clbClients.DataSource = exampleClients;
            clbClients.DisplayMember = "FullName";
            clbClients.ValueMember = "Id";

            //using (var db = new HotelManagerDbContext()) // Replace with your HotelManagerDbContext
            //{
            //    var clients = db.Clients.ToList();
            //    clbClients.DataSource = clients;
            //    clbClients.DisplayMember = "FullName"; // Assuming Client has a FullName property
            //    clbClients.ValueMember = "Id"; // Store the unique ID
            //}
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
    }
}
