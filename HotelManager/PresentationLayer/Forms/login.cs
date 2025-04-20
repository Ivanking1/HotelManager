

namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        

        private readonly UserManager userManager;
        private bool isPasswordVisible = false;
        public LoginForm()
        {
            userManager = new UserManager();
            InitializeComponent();
            InitializePlaceholders();
        }
        public LoginForm(UserManager userManager)
        {
            this.userManager = userManager;
            InitializeComponent();
            InitializePlaceholders();
        }
        #region placeholders
        private void InitializePlaceholders()
        {
            bnPasswordVisibility.Visible = false;

            // Set placeholders for multiple textboxes
            SetPlaceholder(txtUsername, "User123");
            SetPlaceholder(txtPassword, "123456", true);


            // Attach events dynamically
            txtUsername.GotFocus += (sender, e) => RemovePlaceholder(txtUsername, "User123");
            txtUsername.LostFocus += (sender, e) => SetPlaceholder(txtUsername, "User123");

            txtPassword.GotFocus += (sender, e) => RemovePlaceholder(txtPassword, "123456", true);
            txtPassword.LostFocus += (sender, e) => SetPlaceholder(txtPassword, "123456", true);
        }

        private void SetPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
                if (isPassword) 
                {
                    textBox.PasswordChar = '\0'; // Show placeholder text
                    isPasswordVisible = false;
                    bnPasswordVisibility.Visible = false;  // Hide the eye button
                    bnPasswordVisibility.Image = Properties.Resources.eye_closed;
                }
            }
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;

                if (isPassword)
                {
                    if (isPasswordVisible)
                    {
                        textBox.PasswordChar = '\0'; // Show actual text
                    }
                    else
                    {
                        textBox.PasswordChar = '*'; // Mask with asterisks
                    }
                   
                }
            }
        }
        #endregion


        private void login_Load(object sender, EventArgs e)
        {

        }
        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            bool shouldShowEyeButton = txtPassword.Text.Length > 0 && (txtPassword.Text != "123456" || txtPassword.ForeColor != Color.Gray);
            bnPasswordVisibility.Visible = shouldShowEyeButton;

        }

        private async Task InitializeApplicationForms(User loggedInUser)
        {
            await Task.Run(() =>
            {
                FormsContext.LoggedInUser = loggedInUser;  // Store user globally
                FormsContext.HomeForm = new HomeForm();
                FormsContext.ReservationsForm = new ReservationsForm();
                FormsContext.ClientsForm = new ClientsForm();
                FormsContext.RoomsForm = new RoomsForm();
                FormsContext.UsersForm = new UsersForm();
                FormsContext.AddNewReservationForm = new AddNewReservationForm();
                FormsContext.AddNewClientForm = new AddNewClientForm();
                FormsContext.AddNewRoomForm = new AddNewRoomForm();
                FormsContext.AddNewUserForm = new AddNewUserForm();
            });

        }
        private async Task<User?> GetUser(string username, string password)
        {
            ICollection<User> users = await userManager.ReadAllAsync();
            User? loggedInUser = users.FirstOrDefault(u => u.UserName == username);
            if (loggedInUser != null && loggedInUser.VerifyPassword(password))
            {
                return loggedInUser;  // Correct password
            }

            return null;
        }
        private void bnPasswordVisibility_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "123456" && txtPassword.ForeColor == Color.Gray)
                return;

            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0'; // Show actual text
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Mask with asterisks
            }

            // Optionally change the eye icon to show open/closed state
            if (bnPasswordVisibility.Image != null)
            {
                if (isPasswordVisible)
                {
                    bnPasswordVisibility.Image = Properties.Resources.eye_open;
                }
                else
                {
                    bnPasswordVisibility.Image = Properties.Resources.eye_closed;
                }
            }
        }
        private async void bnLogin_ClickAsync(object sender, EventArgs e)
        {
            User loggedInUser;
            string username;
            string password;
            if (txtUsername.Text.IsNullOrEmpty() || txtPassword.Text.IsNullOrEmpty())
            {
                return;
            }
            else
            {
                username = txtUsername.Text;
                password = txtPassword.Text;
                loggedInUser = await GetUser(username, password);
            }

            // Simulated users
            List<User> users = new List<User>
            {
              new User(Guid.NewGuid(), "adminUser", BCrypt.Net.BCrypt.HashPassword("Admin@123"), "John",
              "Michael", "Doe", new DateTime(1985, 6, 15), "+123456789", "admin@example.com",
              new DateTime(2020, 1, 10), true, null, Role.Administrator),

              new User(Guid.NewGuid(), "receptionist1", BCrypt.Net.BCrypt.HashPassword("Reception@456"),
              "Alice", "Marie", "Johnson", new DateTime(1992, 3, 25), "+987654321", "alice.johnson@example.com",
              new DateTime(2021, 5, 20), true, null, Role.Receptionist),

              new User(Guid.NewGuid(), "worker99", BCrypt.Net.BCrypt.HashPassword("Worker@789"),
              "Robert", "James", "Smith", new DateTime(1998, 11, 10), "+1122334455",
              "robert.smith@example.com", new DateTime(2023, 8, 5), true, null, Role.Worker)
            };
            
            if (loggedInUser != null && loggedInUser.IsActive == true)//need to check if the user is active
            {
                await InitializeApplicationForms(loggedInUser);

                FormsContext.HomeForm?.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
