

namespace PresentationLayer
{
    public partial class AddNewRoomForm : Form
    {
        private readonly RoomManager roomManager;
        private Room? selectedRoom;
        public AddNewRoomForm(IFirebaseClient firebaseClient)
        {
            roomManager = new RoomManager(firebaseClient);
            InitializeComponent();
            LoadRoomTypes();
            InitializePlaceholders();
            bnAddRoom.Visible = true;
            bnAddRoom.Enabled = true;
            bnUpdateRoom.Visible = false;
            bnUpdateRoom.Enabled = false;
        }
        public AddNewRoomForm()
        {
            roomManager = new RoomManager();
            InitializeComponent();
            LoadRoomTypes();
            InitializePlaceholders();
            bnAddRoom.Visible = true;
            bnAddRoom.Enabled = true;
            bnUpdateRoom.Visible = false;
            bnUpdateRoom.Enabled = false;
        }
        public void ReturnFormToNormal()// must add the edditing logic
        {
            InitializePlaceholders();
            LoadRoomTypes();
            bnAddRoom.Visible = true;
            bnAddRoom.Enabled = true;
            bnUpdateRoom.Visible = false;
            bnUpdateRoom.Enabled = false;
        }
        public void UpdateRoomInForm(Room selectedRoom)// must add the edditing logic
        {
            this.selectedRoom = selectedRoom;
            RefreshUIData();
            bnAddRoom.Visible = false;
            bnAddRoom.Enabled = false;
            bnUpdateRoom.Visible = true;
            bnUpdateRoom.Enabled = true;
        }
        public void RefreshUIData()
        {
            if (selectedRoom != null)
            {
                txtRoomNumber.Text = selectedRoom.RoomNumber.ToString();
                cmbRoomType.SelectedItem = selectedRoom.RoomType;
                txtChildPrice.Text = selectedRoom.ChildPrice.ToString();
                txtAdultPrice.Text = selectedRoom.AdultPrice.ToString();
            }
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

            if (adultPrice < 0 || childPrice < 0)
            {
                MessageBox.Show("Invalid prices!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (roomNumber < 0)
            {
                MessageBox.Show("Invalid room number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RoomEnum roomType = (RoomEnum)Enum.Parse(typeof(RoomEnum), cmbRoomType.SelectedItem.ToString());

            Room newRoom = new Room(Guid.Empty, roomNumber, roomType, adultPrice, childPrice);


            try
            {
                await roomManager.CreateAsync(newRoom);
                MessageBox.Show("Room added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                FormsContext.RoomsForm?.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnRoomsView_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.RoomsForm?.Show();
        }

        private async void bnUpdateRoom_Click(object sender, EventArgs e)
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

            if (adultPrice < 0 || childPrice < 0)
            {
                MessageBox.Show("Invalid prices!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (roomNumber < 0)
            {
                MessageBox.Show("Invalid room number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RoomEnum roomType = (RoomEnum)Enum.Parse(typeof(RoomEnum), cmbRoomType.SelectedItem.ToString());

            Room newRoom = new Room(selectedRoom.Id, roomNumber, roomType, adultPrice, childPrice);


            try
            {
                await roomManager.UpdateAsync(newRoom);
                MessageBox.Show("Room edited successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                FormsContext.RoomsForm?.Show();
                ReturnFormToNormal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
