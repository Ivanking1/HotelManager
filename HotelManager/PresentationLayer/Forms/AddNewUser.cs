

namespace PresentationLayer
{
    public partial class AddNewUserForm : Form
    {
        private readonly UserManager userManager;
        private User? selectedUser;

        public AddNewUserForm(IFirebaseClient firebaseClient)
        {
            userManager = new UserManager(firebaseClient);
            InitializeComponent();
            InitializePlaceholders();
            LoadUserRoles();
            bnAddUser.Visible = true;
            bnAddUser.Enabled = true;
            bnUpdateUser.Visible = false;
            bnUpdateUser.Enabled = false;
        }
        public AddNewUserForm()
        {
            userManager = new UserManager();
            InitializeComponent();
            InitializePlaceholders();
            LoadUserRoles();
            bnAddUser.Visible = true;
            bnAddUser.Enabled = true;
            bnUpdateUser.Visible = false;
            bnUpdateUser.Enabled = false;
        }

        public void ReturnFormToNormal()// must add the edditing logic
        {
            InitializePlaceholders();
            LoadUserRoles();
            bnAddUser.Visible = true;
            bnAddUser.Enabled = true;
            bnUpdateUser.Visible = false;
            bnUpdateUser.Enabled = false;
        }
        public void UpdateUserInForm(User selectedUser)// must add the edditing logic
        {
            this.selectedUser = selectedUser;
            RefreshUIData();
            bnAddUser.Visible = false;
            bnAddUser.Enabled = false;
            bnUpdateUser.Visible = true;
            bnUpdateUser.Enabled = true;
        }
        public void RefreshUIData()
        {
            if (selectedUser != null)
            {
                txtUsername.Text = selectedUser.UserName;
                txtPassword.Text = selectedUser.Password;
               
                txtFirstName.Text = selectedUser.Password;
                txtSecondName.Text = selectedUser.Password;
                txtLastName.Text = selectedUser.Password;
                txtPhoneNumber.Text = selectedUser.Password;
                txtEmail.Text = selectedUser.Password;
                dtpDateOfBirth.Value = selectedUser.DateOfBirth;
                cmbUserRole.SelectedItem = selectedUser.Role;
                chkIsActive.Checked = selectedUser.IsActive;
            }
        }
        #region placeholders
        private void InitializePlaceholders()
        {
            // Set placeholders for multiple textboxes
            SetPlaceholder(txtUsername, "User Name");
            SetPlaceholder(txtPassword, "Password");
            SetPlaceholder(txtConfirmPassword, "Confirm Password");
            SetPlaceholder(txtFirstName, "First Name");
            SetPlaceholder(txtSecondName, "Second Name");
            SetPlaceholder(txtLastName, "Last Name");
            SetPlaceholder(txtPhoneNumber, "Phone Number");
            SetPlaceholder(txtEmail, "Email");

            // Attach events dynamically
            txtUsername.GotFocus += (sender, e) => RemovePlaceholder(txtUsername, "User Name");
            txtUsername.LostFocus += (sender, e) => SetPlaceholder(txtUsername, "User Name");

            txtPassword.GotFocus += (sender, e) => RemovePlaceholder(txtPassword, "Password", true);
            txtPassword.LostFocus += (sender, e) => SetPlaceholder(txtPassword, "Password", true);

            txtConfirmPassword.GotFocus += (sender, e) => RemovePlaceholder(txtConfirmPassword, "Confirm Password", true);
            txtConfirmPassword.LostFocus += (sender, e) => SetPlaceholder(txtConfirmPassword, "Confirm Password", true);

            txtFirstName.GotFocus += (sender, e) => RemovePlaceholder(txtFirstName, "First Name");
            txtFirstName.LostFocus += (sender, e) => SetPlaceholder(txtFirstName, "First Name");

            txtSecondName.GotFocus += (sender, e) => RemovePlaceholder(txtSecondName, "Second Name");
            txtSecondName.LostFocus += (sender, e) => SetPlaceholder(txtSecondName, "Second Name");

            txtLastName.GotFocus += (sender, e) => RemovePlaceholder(txtLastName, "Last Name");
            txtLastName.LostFocus += (sender, e) => SetPlaceholder(txtLastName, "Last Name");

            txtPhoneNumber.GotFocus += (sender, e) => RemovePlaceholder(txtPhoneNumber, "Phone Number");
            txtPhoneNumber.LostFocus += (sender, e) => SetPlaceholder(txtPhoneNumber, "Phone Number");

            txtEmail.GotFocus += (sender, e) => RemovePlaceholder(txtEmail, "Email");
            txtEmail.LostFocus += (sender, e) => SetPlaceholder(txtEmail, "Email");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
                if (isPassword) textBox.PasswordChar = '\0'; // Show placeholder text
            }
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                if (isPassword) textBox.PasswordChar = '*'; // Hide password as dots
            }
        }
        #endregion


        private void LoadUserRoles()
        {
            cmbUserRole.Items.Add("Select User Role");

            //enum values for role
            foreach (var role in Enum.GetValues(typeof(Role)))
            {
                cmbUserRole.Items.Add(role);
            }

            if (selectedUser == null)
            {
                cmbUserRole.SelectedIndex = 0;
                cmbUserRole.ForeColor = Color.Gray;
            }
            else//edit logic
            {
                cmbUserRole.Text = selectedUser.Role.ToString();
            }

        }
        private void CmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUserRole.SelectedIndex == 0)
            {
                cmbUserRole.ForeColor = Color.Gray; // Placeholder color
            }
            else
            {
                cmbUserRole.ForeColor = Color.Black; // Normal color
            }
        }


        private void AddNewUser_Load(object sender, EventArgs e)
        {

        }

        private async void bnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string? password = null;
            if (!string.IsNullOrWhiteSpace(txtPassword.Text.Trim())
                && txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
            {
                password = txtPassword.Text.Trim();
            }
            string firstName = txtFirstName.Text.Trim();
            string secondName = txtSecondName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime startOfEmployment = DateTime.Now;
            string? roleString = cmbUserRole.SelectedItem.ToString();
            DateTime? endOfEmployment;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(secondName) ||
                string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) || roleString == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            Role role = (Role)Enum.Parse(typeof(Role), roleString);

            try
            {
                User newUser = new User(Guid.NewGuid(),
                                        username,
                                        password,  //hashing the password
                                        firstName,
                                        secondName,
                                        lastName,
                                        dateOfBirth,
                                        phoneNumber,
                                        email,
                                        startOfEmployment,
                                        true,
                                        null,
                                        role);

                await userManager.CreateAsync(newUser);
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                FormsContext.UsersForm?.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnUsersView_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.UsersForm?.Show();
        }

        private async void bnUpdateUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string? password = null;
            if (!string.IsNullOrWhiteSpace(txtPassword.Text.Trim())
                && txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
            {
                password = txtPassword.Text.Trim();
            }
            string firstName = txtFirstName.Text.Trim();
            string secondName = txtSecondName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime startOfEmployment = DateTime.Now;
            string? roleString = cmbUserRole.SelectedItem.ToString();
            DateTime? endOfEmployment;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(secondName) ||
                string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) || roleString == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Role role = (Role)Enum.Parse(typeof(Role), roleString);
            try
            {
                User updatedUser = new User(selectedUser.Id,
                username,
                password,
                firstName,
                secondName,
                lastName,
                dateOfBirth,
                phoneNumber,
                email,
                startOfEmployment,
                true,
                null,
                role);

                await userManager.UpdateAsync(updatedUser);
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Hide();
                FormsContext.UsersForm?.Show();
                ReturnFormToNormal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
