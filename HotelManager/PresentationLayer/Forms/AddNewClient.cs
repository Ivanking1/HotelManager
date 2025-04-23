

using FireSharp.Interfaces;

namespace PresentationLayer
{
    public partial class AddNewClientForm : Form
    {
        private readonly ClientManager clientManager;
        private Client? selectedClient;
        public AddNewClientForm(IFirebaseClient firebaseClient)
        {
            clientManager = new ClientManager(firebaseClient);
            InitializeComponent();
            InitializePlaceholders();
            bnAddClient.Visible = true;
            bnAddClient.Enabled = true;
            bnUpdateClient.Visible = false;
            bnUpdateClient.Enabled = false;
        }
        public AddNewClientForm()
        {
            clientManager = new ClientManager();
            InitializeComponent();
            InitializePlaceholders();
            bnAddClient.Visible = true;
            bnAddClient.Enabled = true;
            bnUpdateClient.Visible = false;
            bnUpdateClient.Enabled = false;
        }

        public void ReturnFormToNormal()// must add the edditing logic
        {
            InitializePlaceholders();
            bnAddClient.Visible = true;
            bnAddClient.Enabled = true;
            bnUpdateClient.Visible = false;
            bnUpdateClient.Enabled = false;
        }
        public void UpdateClientInForm(Client selectedClient)// must add the edditing logic
        {
            this.selectedClient = selectedClient;
            RefreshUIData();
            bnAddClient.Visible = false;
            bnAddClient.Enabled = false;
            bnUpdateClient.Visible = true;
            bnUpdateClient.Enabled = true;
        }
        public void RefreshUIData()
        {
            if (selectedClient != null)
            {
                txtFirstName.Text = selectedClient.FirstName;
                txtLastName.Text = selectedClient.LastName;
                txtAge.Text = selectedClient.Age.ToString();
                txtPhoneNumber.Text = selectedClient.PhoneNumber;
                txtEmail.Text = selectedClient.Email;
            }
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
            if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text) && !System.Text.RegularExpressions.Regex.IsMatch(txtPhoneNumber.Text, @"^\+?\d{7,15}$"))
            {
                MessageBox.Show("Invalid phone number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save to database asynchronously
            try
            {
                Client newClient = new Client(Guid.NewGuid(),
                txtFirstName.Text,
                txtLastName.Text,
                txtPhoneNumber.Text,
                txtEmail.Text,
                age);//experimental

                await clientManager.CreateAsync(newClient);
                MessageBox.Show("Client Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.Hide();
                FormsContext.ClientsForm?.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnClientsView_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsContext.ClientsForm?.Show();
        }

        private async void bnUpdateClient_Click(object sender, EventArgs e)
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
            if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text) && !System.Text.RegularExpressions.Regex.IsMatch(txtPhoneNumber.Text, @"^\+?\d{7,15}$"))
            {
                MessageBox.Show("Invalid phone number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save to database asynchronously
            try
            {
                Client newClient = new Client(selectedClient.Id,
               txtFirstName.Text,
               txtLastName.Text,
               txtPhoneNumber.Text,
               txtEmail.Text,
               age);//experimental

                await clientManager.UpdateAsync(newClient);
                MessageBox.Show("Client Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                FormsContext.ClientsForm?.Show();
                FormsContext.AddNewClientForm.ReturnFormToNormal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
