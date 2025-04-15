

using DataLayer;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer;

namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        private readonly UserManager userManager;
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
            // Set placeholders for multiple textboxes
            SetPlaceholder(txtUsername, "User123");
            SetPlaceholder(txtPassword, "123456");


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


        private void login_Load(object sender, EventArgs e)
        {

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

            // Find user
           // loggedInUser = users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            //need to check if the user is active
            if (loggedInUser != null)
            {
                HomeForm homeForm = new HomeForm(loggedInUser);
                homeForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //code for testing
            //LoginForm.ActiveForm?.Hide();
            //new AddNewReservationForm(loggedInUser).Show();
            //new AddNewUserForm().Show();
            //new AddNewClientForm().Show();
            //new AddNewRoom().Show();

        }
    }
}
