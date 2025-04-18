﻿
using ServiceLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer
{
    public partial class AddNewClientForm : Form
    {
        private readonly ClientManager clientManager;
        private User loggedInUser;
        public AddNewClientForm(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            clientManager = new ClientManager();
            InitializeComponent();
            InitializePlaceholders();
        }
        public AddNewClientForm(User loggedInUser, ClientManager clientManager)
        {
            this.loggedInUser = loggedInUser;
            this.clientManager = clientManager;
            InitializeComponent();
            InitializePlaceholders();
        }
        #region placeholders
        private void InitializePlaceholders()
        {
            // Set placeholders for multiple textboxes

            SetPlaceholder(txtFirstName, "първо име");
            SetPlaceholder(txtLastName, "последно име");
            SetPlaceholder(txtAge, "възраст", true); //experiment
            SetPlaceholder(txtPhoneNumber, "0000000000");
            SetPlaceholder(txtEmail, "example@gmail.com");

            // Attach events dynamically
            txtFirstName.GotFocus += (sender, e) => RemovePlaceholder(txtFirstName, "първо име");
            txtFirstName.LostFocus += (sender, e) => SetPlaceholder(txtFirstName, "първо име");

            txtLastName.GotFocus += (sender, e) => RemovePlaceholder(txtLastName, "последно име");
            txtLastName.LostFocus += (sender, e) => SetPlaceholder(txtLastName, "последно име");

            txtAge.GotFocus += (sender, e) => RemovePlaceholder(txtAge, "възраст", true);
            txtAge.LostFocus += (sender, e) => SetPlaceholder(txtAge, "възраст", true);

            txtPhoneNumber.GotFocus += (sender, e) => RemovePlaceholder(txtPhoneNumber, "0000000000");
            txtPhoneNumber.LostFocus += (sender, e) => SetPlaceholder(txtPhoneNumber, "0000000000");

            txtEmail.GotFocus += (sender, e) => RemovePlaceholder(txtEmail, "example@gmail.com");
            txtEmail.LostFocus += (sender, e) => SetPlaceholder(txtEmail, "example@gmail.com");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder, bool isAge = false)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
                if (isAge) { ValidateAge(); }
            }
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder, bool isAge = false)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                if (isAge) { ValidateAge(); }
            }
        }
        #endregion

        private void ValidateAge()//experimental
        {
            int currentAge;
            if (int.TryParse(txtAge.Text, out currentAge) || string.IsNullOrWhiteSpace(txtAge.Text))
            {
                errorProvider1.SetError(txtAge, ""); //  Clear error
            }
            else
            {
                errorProvider1.SetError(txtAge, "Please enter a valid number!"); //  Show error
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);//email validation
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void bnAddClient_Click(object sender, EventArgs e)
        {

            // Validate Inputs
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text))
            {
                MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Invalid age!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            Client newClient = new Client(Guid.NewGuid(),
                txtFirstName.Text,
                txtLastName.Text,
                txtPhoneNumber.Text,
                txtEmail.Text,
                age);//experimental


            // Save to database asynchronously
            try
            {
                await clientManager.CreateAsync(newClient);
                MessageBox.Show("Client Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClientsForm clientsForm = new ClientsForm(loggedInUser);
                clientsForm.Show();
                this.Hide();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnClientsView_Click(object sender, EventArgs e)
        {
            this.Close();
            ClientsForm clientsForm = new ClientsForm(loggedInUser);
            clientsForm.Show();
        }
    }
}
