

namespace BusinessLayer
{
    public class Client
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        public string FirstName { get; private set; }

        [Required]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        public string LastName { get; private set; }

        [Phone]
        [RegularExpression(@"^\+?\d{7,15}$", ErrorMessage = "Phone number must contain only digits and can include a leading '+'.")]
        public string? PhoneNumber { get; private set; }

        [EmailAddress]
        public string? Email { get; private set; }

        [Required]
        [Range(3, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; private set; }
            
        public string FullName => $"{FirstName} {LastName}";
        public string DisplayInfo => $"{FullName} (Age: {Age})";

        // Default constructor that auto-generates the Id
        public Client() : this(Guid.NewGuid(), string.Empty, string.Empty, null, null, 0) { }

        // Constructor with optional Id. 
        public Client(Guid id, string firstName, string lastName, string? phoneNumber, string? email, int age)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;// If Id is Guid.Empty, generate a new Guid

            //to make the compiler happy
            FirstName = string.Empty;
            LastName = string.Empty;

            SetClientDetails(firstName, lastName, phoneNumber, email, age);
        }

        public void UpdateClient(string firstName, string lastName, string? phoneNumber, string? email, int age)
        {
            SetClientDetails(firstName, lastName, phoneNumber, email, age);
        }
        private void SetClientDetails(string firstName, string lastName, string? phoneNumber, string? email, int age)
        {
            //  Trim whitespace from input
            FirstName = firstName?.Trim() ?? throw new ArgumentException("First name cannot be empty.");
            LastName = lastName?.Trim() ?? throw new ArgumentException("Last name cannot be empty.");

            if (FirstName.Length < 2 || LastName.Length < 2)
                throw new ArgumentException("First name and last name must be at least 2 characters.");

            //  Ensure phone number is valid
            if (!string.IsNullOrWhiteSpace(phoneNumber) && !System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\+?\d{7,15}$"))
                throw new ArgumentException("Invalid phone number format.");

            //  Ensure email is valid
            if (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
                throw new ArgumentException("Invalid email format.");

            PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber.Trim();
            Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim();

            if (age < 3 || age > 100)
                throw new ArgumentException("Age must be between 3 and 100.");

            Age = age;
        }
    }
}
