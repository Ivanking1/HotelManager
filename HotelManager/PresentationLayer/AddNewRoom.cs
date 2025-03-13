

namespace PresentationLayer
{
    public partial class AddNewRoom : Form
    {
        public AddNewRoom()
        {
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

        private void bnAddRoom_Click(object sender, EventArgs e)
        {
            //if (!int.TryParse(txtRoomNumber.Text, out int roomNumber))
            //{
            //    MessageBox.Show("Invalid Room Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (!decimal.TryParse(txtAdultPrice.Text, out decimal adultPrice))
            //{
            //    MessageBox.Show("Invalid Adult Price!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (!decimal.TryParse(txtChildPrice.Text, out decimal childPrice))
            //{
            //    MessageBox.Show("Invalid Child Price!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //// Get selected room type
            //RoomEnum selectedRoomType = (RoomEnum)cmbRoomType.SelectedItem;

            //// Create a new room
            //Room newRoom = new Room(roomNumber, selectedRoomType, true, adultPrice, childPrice);

            //// Save the room (Example: Add to a list or database)
            //MessageBox.Show("Room Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //// Close the form or clear fields for new entry
            //this.Close();
        }
    }
}
