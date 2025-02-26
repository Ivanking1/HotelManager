using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class AddNewRoom : Form
    {
        public AddNewRoom()
        {
            InitializeComponent();
            LoadRoomTypes();
        }
        private void LoadRoomTypes()
        {
            cmbRoomType.Items.Add("Select Room Type");

            // Add actual enum values
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
