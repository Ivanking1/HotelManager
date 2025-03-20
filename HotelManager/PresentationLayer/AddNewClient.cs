
using ServiceLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer
{
    public partial class AddNewClientForm : Form
    {
        private ClientManager clientManager;
        public AddNewClientForm()
        {
            clientManager = new ClientManager();
            InitializeComponent();
            InitializePlaceholders();
        }
        public AddNewClientForm(ClientManager clientManager)
        {
            this.clientManager = clientManager;
            InitializeComponent();
            InitializePlaceholders();
        }
        #region placeholders
        private void InitializePlaceholders()
        {
            // Set placeholders for multiple textboxes

            SetPlaceholder(txtFirstName, "First Name");
            SetPlaceholder(txtLastName, "Last Name");
            SetPlaceholder(txtAge, "Age");
            SetPlaceholder(txtPhoneNumber, "Phone Number");
            SetPlaceholder(txtEmail, "Email");

            // Attach events dynamically
            txtFirstName.GotFocus += (sender, e) => RemovePlaceholder(txtFirstName, "First Name");
            txtFirstName.LostFocus += (sender, e) => SetPlaceholder(txtFirstName, "First Name");

            txtLastName.GotFocus += (sender, e) => RemovePlaceholder(txtLastName, "Last Name");
            txtLastName.LostFocus += (sender, e) => SetPlaceholder(txtLastName, "Last Name");

            txtAge.GotFocus += (sender, e) => RemovePlaceholder(txtAge, "Age", true);
            txtAge.LostFocus += (sender, e) => SetPlaceholder(txtAge, "Age", true);

            txtPhoneNumber.GotFocus += (sender, e) => RemovePlaceholder(txtPhoneNumber, "Phone Number");
            txtPhoneNumber.LostFocus += (sender, e) => SetPlaceholder(txtPhoneNumber, "Phone Number");

            txtEmail.GotFocus += (sender, e) => RemovePlaceholder(txtEmail, "Email");
            txtEmail.LostFocus += (sender, e) => SetPlaceholder(txtEmail, "Email");
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

        private void ValidateAge()
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

        private void bnAddClient_Click(object sender, EventArgs e)
        {
           
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            int age;
            if (int.TryParse(txtAge.Text, out age))
            {
                errorProvider1.SetError(txtAge, ""); //  Clear error
            }
            else
            {
                errorProvider1.SetError(txtAge, "Please enter a valid number!"); //  Show error
            }
            string phoneNumber = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))//
            {
                return;
            }
        }
    }
}
