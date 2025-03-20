

using ServiceLayer;

namespace PresentationLayer
{
    public partial class AddNewUserForm : Form
    {
        private UserManager userManager;
        private User loggedInUser;
        public AddNewUserForm(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            userManager = new UserManager();
            InitializeComponent();
            InitializePlaceholders();
            LoadUserRoles();
        }
        public AddNewUserForm(User loggedInUser, UserManager userManager)
        {
            this.loggedInUser = loggedInUser;
            this.userManager = userManager;
            InitializeComponent();
            InitializePlaceholders();
            LoadUserRoles();
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
            SetPlaceholder(txtSocialSecurity, "Social Security");
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

            txtSocialSecurity.GotFocus += (sender, e) => RemovePlaceholder(txtSocialSecurity, "Social Security");
            txtSocialSecurity.LostFocus += (sender, e) => SetPlaceholder(txtSocialSecurity, "Social Security");

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


            cmbUserRole.SelectedIndex = 0;
            cmbUserRole.ForeColor = Color.Gray;


            cmbUserRole.SelectedIndexChanged += CmbUserRole_SelectedIndexChanged;
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
            string socialSecurity = txtSocialSecurity.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime startOfEmployment = DateTime.Now;
            string? role = cmbUserRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(secondName) ||
                string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(socialSecurity) ||
                string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(email) || role == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User newUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = username,
                Password = password,  // ⚠️ Consider hashing the password in a real application
                FirstName = firstName,
                SecondName = secondName,
                LastName = lastName,
                SocialSecurity = socialSecurity,
                PhoneNumber = phoneNumber,
                Email = email,
                StartOfEmployment = startOfEmployment,
                IsActive = true,
                Role = (Role)Enum.Parse(typeof(Role), role)  // Assuming Role is an Enum
            };

            try
            {
                await userManager.CreateAsync(newUser); 
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close(); // Close the form
                UsersForm usersForm = new UsersForm(loggedInUser);
                usersForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
