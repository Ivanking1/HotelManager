

namespace PresentationLayer
{
    public partial class AddNewReservationForm : Form
    {
        private readonly ReservationManager reservationManager;//investigate readonly
        private readonly ClientManager clientManager;
        private readonly RoomManager roomManager;
        private List<Client> allClients = new List<Client>();
        private List<Room> allRooms = new List<Room>();
        private Reservation? selectedReservation;
        public AddNewReservationForm(IFirebaseClient firebaseClient)
        {
            reservationManager = new ReservationManager(firebaseClient);
            clientManager = new ClientManager(firebaseClient);
            roomManager = new RoomManager(firebaseClient);
            InitializeComponent();
            dtpStartDate.MinDate = DateTime.Today;
            dtpEndDate.MinDate = DateTime.Today.AddDays(1);
            cmbRoom.Visible = false;
            bnAddReservation.Visible = true;
            bnAddReservation.Enabled = true;
            bnUpdateReservation.Visible = false;
            bnUpdateReservation.Enabled = false;
            LoadInitialDataAsync();
        }
        public AddNewReservationForm()
        {
            reservationManager = new ReservationManager();
            clientManager = new ClientManager();
            roomManager = new RoomManager();
            InitializeComponent();
            dtpStartDate.MinDate = DateTime.Today;
            dtpEndDate.MinDate = DateTime.Today.AddDays(1);
            cmbRoom.Visible = false;
            bnAddReservation.Visible = true;
            bnAddReservation.Enabled = true;
            bnUpdateReservation.Visible = false;
            bnUpdateReservation.Enabled = false;
            LoadInitialDataAsync();
        }

        #region switchind bethween editing and adding mode
        public void ReturnFormToNormal()
        {
            // Reset form to default state
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1);
            cmbMealPlan.SelectedIndex = 0;
            //cmbRoom.SelectedIndex = 0;
            txtTotalPrice.Text = string.Empty;
            txtSearch.Text = string.Empty;
            clbClients.ClearSelected();

            // Reset button states
            bnAddReservation.Visible = true;
            bnAddReservation.Enabled = true;
            bnUpdateReservation.Visible = false;
            bnUpdateReservation.Enabled = false;

            selectedReservation = null;
        }
        public void UpdateReservationInForm(Reservation reservation)
        {
            this.selectedReservation = reservation;
            RefreshReservationData();

            // Switch to edit mode
            bnAddReservation.Visible = false;
            bnAddReservation.Enabled = false;
            bnUpdateReservation.Visible = true;
            bnUpdateReservation.Enabled = true;
        }
        private void RefreshReservationData()
        {
            if (selectedReservation != null)
            {
                // Set basic reservation info
                dtpStartDate.Value = selectedReservation.StartingDate;
                dtpEndDate.Value = selectedReservation.EndingDate;

                // Set meal plan
                cmbMealPlan.SelectedItem = selectedReservation.MealPlan;

                // Select the room
                foreach (var item in cmbRoom.Items)
                {
                    if (item is Room room && room.Id == selectedReservation.RoomId)
                    {
                        cmbRoom.SelectedItem = item;
                        break;
                    }
                }

                // Select the clients
                for (int i = 0; i < clbClients.Items.Count; i++)
                {
                    if (clbClients.Items[i] is Client client &&
                        selectedReservation.Guests.Any(g => g.Id == client.Id))
                    {
                        clbClients.SetItemChecked(i, true);
                    }
                }

                // Calculate and show price
                CalculatePrice();
            }
        }
        #endregion


        private void AddNewReservationForm_Shown(object sender, EventArgs e)
        {
            LoadInitialDataAsync();
        }
        private async void LoadInitialDataAsync()
        {
            try
            {
                Debug.WriteLine("[AddNewReservation] Starting LoadInitialDataAsync");

                LoadMealTypes(); // Keep synchronous

                // Force a new context for the async operation
                var clients = await Task.Run(async () =>
                {
                    Debug.WriteLine("[AddNewReservation] Starting client fetch on background thread");
                    return await clientManager.ReadAllAsync().ConfigureAwait(false);
                }).ConfigureAwait(true); // Return to UI context

                Debug.WriteLine($"[AddNewReservation] Retrieved {clients?.Count ?? 0} clients");

                allClients = clients?.ToList() ?? new List<Client>();
                UpdateClientsListBox("");

                dtpStartDate.Value = DateTime.Today;
                dtpStartDate.Value = DateTime.Today.AddDays(1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[AddNewReservation] ERROR: {ex}");
            }
        }
       
        private void LoadMealTypes()
        {
            cmbMealPlan.Items.Clear();
            cmbMealPlan.Items.Add("Select Meal Plan");

            // Add items with proper display
            cmbMealPlan.Items.Add(MealsEnum.None);
            cmbMealPlan.Items.Add(MealsEnum.OnlyBreakfast);
            cmbMealPlan.Items.Add(MealsEnum.ThreeMeals);
            cmbMealPlan.Items.Add(MealsEnum.AllInclusive);

            cmbMealPlan.DisplayMember = "ToString"; // This will use the enum's ToString()
            cmbMealPlan.SelectedIndex = 0;
            cmbMealPlan.ForeColor = Color.Black;
        }
        private async void UpdateAvailableRooms()
        {
            try
            {
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;

                if (startDate >= endDate)
                {
                    MessageBox.Show("End date must be after start date");
                    return;
                }

                // Get all rooms
                var rooms = await roomManager.ReadAllAsync();
                allRooms = rooms.ToList();

                // Get existing reservations for the selected period
                var reservations = await reservationManager.ReadAllAsync();

                // Filter out rooms that are booked during the selected period
                var availableRooms = allRooms.Where(room =>
                   !reservations.Any(res =>
                       res.RoomId == room.Id &&
                       res.StartingDate < endDate &&
                       res.EndingDate > startDate))
                   .ToList();

                // Clear and rebind
                cmbRoom.DataSource = null;
                cmbRoom.Items.Clear();
                cmbRoom.Items.Add("Select Room");

                // Add each room with proper display text
                foreach (var room in availableRooms)
                {
                    cmbRoom.Items.Add(room);
                }

                cmbRoom.DisplayMember = "RoomInfo";
                cmbRoom.ValueMember = "Id";
                cmbRoom.SelectedIndex = 0;
                cmbRoom.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading available rooms: {ex.Message}");
            }
        }
        private void UpdateClientsListBox(string searchText)
        {
            clbClients.BeginUpdate();
            clbClients.Items.Clear();

            IEnumerable<Client> filteredClients;

            if (string.IsNullOrEmpty(searchText))
            {
                filteredClients = allClients;
            }
            else
            {
                filteredClients = allClients.Where(c => c.FullName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var displayItems = filteredClients.ToList();
            foreach (var item in displayItems)
            {
                clbClients.Items.Add(item);
            }
            clbClients.DisplayMember = "DisplayInfo";
            clbClients.ValueMember = "Id";
            clbClients.EndUpdate();
        }
        private void UpdateRoomComboBoxVisibility()
        {
            bool shouldShow = cmbMealPlan.SelectedIndex > 0 &&
                             dtpStartDate.Value < dtpEndDate.Value &&
                             clbClients.CheckedItems.Count > 0;

            cmbRoom.Visible = shouldShow;

            if (shouldShow)
            {
                UpdateAvailableRooms();
            }
        }
        private void CalculatePrice()
        {
            if (cmbRoom.SelectedIndex <= 0 || cmbMealPlan.SelectedIndex <= 0 ||
                dtpStartDate.Value >= dtpEndDate.Value || clbClients.CheckedItems.Count == 0)
            {
                txtTotalPrice.Text = "";
                return;
            }

            try
            {
                var selectedRoom = (Room)cmbRoom.SelectedItem;
                var guests = clbClients.CheckedItems.Cast<Client>().ToList();
                string? mealPlanString = cmbMealPlan.SelectedItem.ToString();
                MealsEnum mealPlan = (MealsEnum)Enum.Parse(typeof(MealsEnum), mealPlanString);
                var currentUser = FormsContext.LoggedInUser;
                //int totalNights = (dtpEndDate.Value - dtpStartDate.Value).Days;
                //int adults = guests.Count(g => g.Age >= 18);
                //int children = guests.Count(g => g.Age < 18);

                //// Calculate room price
                //decimal basePrice = (selectedRoom.AdultPrice * adults + selectedRoom.ChildPrice * children) * totalNights;

                //// Calculate meal plan price
                //decimal mealPlanPrice = mealPlan switch
                //{
                //    MealsEnum.OnlyBreakfast => (adults * 15 + children * 10) * totalNights,
                //    MealsEnum.ThreeMeals => (adults * 30 + children * 20) * totalNights,
                //    MealsEnum.AllInclusive => (adults * 50 + children * 35) * totalNights,
                //    _ => 0
                //};
                var reservation = new Reservation(
                    Guid.NewGuid(),
                    selectedRoom,
                    currentUser,
                    guests,
                    dtpStartDate.Value,
                    dtpEndDate.Value,
                    mealPlan);
                // Display total price
                txtTotalPrice.Text = reservation.Price.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating price: {ex.Message}");
            }
        }



        #region placeholders

        #endregion
        

        private void AddNewReservation_Load(object sender, EventArgs e)
        {

        }

        // Event handlers
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value.AddDays(1);
            UpdateRoomComboBoxVisibility();
            CalculatePrice();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomComboBoxVisibility();
            CalculatePrice();
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedIndex > 0)
            {
                cmbRoom.ForeColor = Color.Black;
                CalculatePrice();
            }
            else
            {
                cmbRoom.ForeColor = Color.Gray;
            }
        }

        private void cmbMealPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMealPlan.SelectedIndex > 0)
            {
                cmbMealPlan.ForeColor = Color.Black;
                UpdateRoomComboBoxVisibility();
            }
            else
            {
                cmbMealPlan.ForeColor = Color.Gray;
            }
            CalculatePrice();
        }

        private void clbClients_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //this.BeginInvoke((MethodInvoker)delegate {
            //    UpdateRoomComboBoxVisibility();
            //    CalculatePrice();
            //});
            UpdateRoomComboBoxVisibility();
            CalculatePrice();
        }

        private void btnSearchClients_Click(object sender, EventArgs e)
        {
            UpdateClientsListBox(txtSearch.Text);
        }

        private void txtSearchClients_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                UpdateClientsListBox("");
            }
        }


        private async void bnAddReservation_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                // Validate inputs
                if (cmbRoom.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a room");
                    return;
                }

                if (cmbMealPlan.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a meal plan");
                    return;
                }

                if (dtpStartDate.Value >= dtpEndDate.Value)
                {
                    MessageBox.Show("End date must be after start date");
                    return;
                }

                var selectedGuests = clbClients.CheckedItems.Cast<Client>().ToList();
                if (selectedGuests.Count == 0)
                {
                    MessageBox.Show("Please select at least one guest");
                    return;
                }

                // Get selected values
                var selectedRoom = (Room)cmbRoom.SelectedItem;
                string? mealPlanString = cmbMealPlan.SelectedItem.ToString();
                MealsEnum mealPlan = (MealsEnum)Enum.Parse(typeof(MealsEnum), mealPlanString);
                var currentUser = FormsContext.LoggedInUser;

                // Create reservation
                var reservation = new Reservation(
                    Guid.NewGuid(),
                    selectedRoom,
                    currentUser,
                    selectedGuests,
                    dtpStartDate.Value,
                    dtpEndDate.Value,
                    mealPlan);

                // Save to database
                await reservationManager.CreateAsync(reservation);

                MessageBox.Show("Reservation created successfully!");
                this.Hide();
                FormsContext.ReservationsForm?.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating reservation: {ex.Message}");
            }
        }

        private void bnReservationsView_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.ReservationsForm?.Show();
        }

        private async void bnUpdateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedReservation == null) return;

                // Validate inputs
                if (cmbRoom.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a room");
                    return;
                }

                if (cmbMealPlan.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a meal plan");
                    return;
                }

                if (dtpStartDate.Value >= dtpEndDate.Value)
                {
                    MessageBox.Show("End date must be after start date");
                    return;
                }

                var selectedGuests = clbClients.CheckedItems.Cast<Client>().ToList();
                if (selectedGuests.Count == 0)
                {
                    MessageBox.Show("Please select at least one guest");
                    return;
                }

                // Get selected values
                var selectedRoom = (Room)cmbRoom.SelectedItem;
                var mealPlan = (MealsEnum)((dynamic)cmbMealPlan.SelectedItem).Value;
                var currentUser = FormsContext.LoggedInUser;
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;

                Reservation updatedReservation = new Reservation(selectedReservation.Id,
                    selectedRoom,
                    currentUser, 
                    selectedGuests,
                    startDate,
                    endDate, 
                    mealPlan);
                
                // Save to database
                await reservationManager.UpdateAsync(updatedReservation);

                MessageBox.Show("Reservation updated successfully!");
                this.Hide();
                FormsContext.ReservationsForm?.Show();
                ReturnFormToNormal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating reservation: {ex.Message}");
            }
        }
    }
}
