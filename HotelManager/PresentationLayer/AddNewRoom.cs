

using ServiceLayer;

namespace PresentationLayer
{
    public partial class AddNewRoom : Form
    {
        private readonly RoomManager roomManager;
        private User loggedInUser;
        public AddNewRoom(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            roomManager = new RoomManager();
            InitializeComponent();
            LoadRoomTypes();
            InitializePlaceholders();
        }
        public AddNewRoom(User loggedInUser, RoomManager roomManager)
        {
            this.loggedInUser = loggedInUser;
            this.roomManager = roomManager;
            InitializeComponent();
            LoadRoomTypes();
            InitializePlaceholders();
        }
        #region placeholders
        private void InitializePlaceholders()
        {
            // Set placeholders for multiple textboxes
            SetPlaceholder(txtRoomNumber, "Room Number");
            SetPlaceholder(txtChildPrice, "Price for child");
            SetPlaceholder(txtAdultPrice, "Price for adult");

            // Attach events dynamically
            txtRoomNumber.GotFocus += (sender, e) => RemovePlaceholder(txtRoomNumber, "Room Number");
            txtRoomNumber.LostFocus += (sender, e) => SetPlaceholder(txtRoomNumber, "Room Number");

            txtChildPrice.GotFocus += (sender, e) => RemovePlaceholder(txtChildPrice, "Price for child");
            txtChildPrice.LostFocus += (sender, e) => SetPlaceholder(txtChildPrice, "Price for child");

            txtAdultPrice.GotFocus += (sender, e) => RemovePlaceholder(txtAdultPrice, "Price for adult");
            txtAdultPrice.LostFocus += (sender, e) => SetPlaceholder(txtAdultPrice, "Price for adult");
        }
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }
        #endregion

        private void LoadRoomTypes()
        {
            cmbRoomType.Items.Add("Select Room Type");

            // Add enum values
            foreach (var type in Enum.GetValues(typeof(RoomEnum)))
            {
                cmbRoomType.Items.Add(type);
            }

            
            cmbRoomType.SelectedIndex = 0;
            cmbRoomType.ForeColor = Color.Gray; 

           
            cmbRoomType.SelectedIndexChanged += CmbRoomType_SelectedIndexChanged;
        }
        private void CmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoomType.SelectedIndex == 0)
            {
                cmbRoomType.ForeColor = Color.Gray; // Placeholder color
            }
            else
            {
                cmbRoomType.ForeColor = Color.Black; // Normal color
            }
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {

        }

        private async void bnAddRoom_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRoomNumber.Text, out int roomNumber))
            {
                MessageBox.Show("Invalid Room Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtAdultPrice.Text, out decimal adultPrice) ||
             !decimal.TryParse(txtChildPrice.Text, out decimal childPrice))
            {
                MessageBox.Show("Invalid price input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbRoomType.SelectedIndex == 0) // Prevent placeholder selection
            {
                MessageBox.Show("Please select a valid Room Type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(adultPrice < 0 || childPrice < 0) 
            {
                MessageBox.Show("Invalid prices!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (roomNumber < 0 )
            {
                MessageBox.Show("Invalid room number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RoomEnum roomType = (RoomEnum)Enum.Parse(typeof(RoomEnum), cmbRoomType.SelectedItem.ToString());

            Room newRoom = new Room(Guid.Empty, roomNumber, roomType, true, adultPrice, childPrice);


            try
            {
                await roomManager.CreateAsync(newRoom);
                MessageBox.Show("Room added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                RoomsForm roomsForm = new RoomsForm(loggedInUser);
                roomsForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
