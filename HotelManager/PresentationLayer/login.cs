

namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitializePlaceholders();
        }
        #region placeholders
        private void InitializePlaceholders()
        {
            // Set placeholders for multiple textboxes
            SetPlaceholder(txtUsername, "User Name");
            SetPlaceholder(txtPassword, "Password");

            // Attach events dynamically
            txtUsername.GotFocus += (sender, e) => RemovePlaceholder(txtUsername, "User Name");
            txtUsername.LostFocus += (sender, e) => SetPlaceholder(txtUsername, "User Name");

            txtPassword.GotFocus += (sender, e) => RemovePlaceholder(txtPassword, "Password", true);
            txtPassword.LostFocus += (sender, e) => SetPlaceholder(txtPassword, "Password", true);
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

        private void bnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Simulated users
            List<User> users = new List<User>
            {
              new User("admin", "1234", "Admin", "", "User", "SSN", "123456789", "admin@email.com", DateTime.Now, true, null, Role.Administrator),
              new User("reception", "1234", "Receptionist", "", "User", "SSN", "987654321", "reception@email.com", DateTime.Now, true, null, Role.Receptionist),
              new User("worker", "1234", "Guest", "", "User", "SSN", "456123789", "guest@email.com", DateTime.Now, true, null, Role.Worker)
            };

            // Find user
            User loggedInUser = users.FirstOrDefault(u => u.UserName == username && u.Password == password);

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
            
            LoginForm.ActiveForm?.Hide();
            //new AddNewUserForm().Show();
            //new AddNewClientForm().Show();
            //new AddNewRoom().Show();
            new AddNewReservation().Show();
        }
    }
}
