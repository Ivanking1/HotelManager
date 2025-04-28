


namespace BusinessLayer
{
    public class User
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(100, ErrorMessage = "Username name cannot exceed 100 characters.")]
        public string UserName { get; private set; }

        [Required]
        public string Password { get; private set; }

        [Required]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        public string FirstName { get; private set; }

        [Required]
        [StringLength(100, ErrorMessage = "Second name cannot exceed 100 characters.")]
        public string SecondName { get; private set; }

        [Required]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        public string LastName { get; private set; }

        [Required]
        public DateTime DateOfBirth { get; private set; }  

        [NotMapped]  // Is not stored in DB, only calculated when needed
        public int Age => DateTime.Now.Year - DateOfBirth.Year -
                         (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
        [Required]
        [Phone]
        public string PhoneNumber { get; private set; }

        [Required]
        [EmailAddress]
        public string Email { get; private set; }

        [Required]
        public DateTime StartOfEmployment { get; private set; }

        [Required]
        public bool IsActive { get; private set; }

        public DateTime? EndOfEmployment { get; private set; }

        [Required]
        public Role Role { get; private set; }

        public string FullName => $"{FirstName} {SecondName} {LastName}";

        public User() : this(Guid.NewGuid(), string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty, DateTime.Now, string.Empty, string.Empty, 
                        DateTime.Now, false, DateTime.Now, Role.Worker)
        { }

        public User(Guid id)
        {
            Id = id;
        }

        public User(Guid id, string userName, string password, string firstName,
            string secondName, string lastName, DateTime dateOfBirth,
            string phoneNumber, string email, DateTime startOfEmployment,
            bool isActive, DateTime? endOfEmployment, Role role)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;

            //to make the compiler happy
            UserName = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;

            SetUserDetails(userName, password, firstName, secondName, lastName, 
                dateOfBirth, phoneNumber, email, startOfEmployment, isActive, endOfEmployment, role);
        }

        public void SetPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }

        private void SetUserDetails(string userName, string password, string firstName, string secondName, string lastName,
                                DateTime dateOfBirth, string phoneNumber, string email, DateTime startOfEmployment,
                                bool isActive, DateTime? endOfEmployment, Role role)
        {
            // ✅ Ensure required fields are not empty
            UserName = !string.IsNullOrWhiteSpace(userName) ? userName.Trim() : throw new ArgumentException("Username cannot be empty.");
            Password = !string.IsNullOrWhiteSpace(password) ? password : throw new ArgumentException("Password cannot be empty.");

            FirstName = firstName?.Trim() ?? throw new ArgumentException("First name cannot be empty.");
            SecondName = secondName?.Trim() ?? throw new ArgumentException("Second name cannot be empty.");
            LastName = lastName?.Trim() ?? throw new ArgumentException("Last name cannot be empty.");

            if (FirstName.Length < 2 || SecondName.Length < 2 || LastName.Length < 2)
                throw new ArgumentException("First name, second name, and last name must be at least 2 characters.");

            // ✅ Validate date of birth (reasonable age check)
            if (dateOfBirth > DateTime.Now.AddYears(-18))
                throw new ArgumentException("User must be at least 18 years old.");

            DateOfBirth = dateOfBirth;

            // ✅ Validate phone number format
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\+?\d{7,15}$"))
                throw new ArgumentException("Invalid phone number format.");

            PhoneNumber = phoneNumber.Trim();

            // ✅ Validate email format
            if (!email.Contains("@"))
                throw new ArgumentException("Invalid email format.");

            Email = email.Trim();

            // ✅ Employment dates validation
            if (startOfEmployment < dateOfBirth.AddYears(18))
                throw new ArgumentException("Start of employment must be after the user turns 18.");

            if (endOfEmployment.HasValue && endOfEmployment <= startOfEmployment)
                throw new ArgumentException("End of employment must be after the start of employment.");

            Password = password;
            StartOfEmployment = startOfEmployment;
            EndOfEmployment = endOfEmployment;
            IsActive = isActive;
            Role = role;
        }

        public void UpdateUser(string userName, string password, string firstName,
            string secondName, string lastName, DateTime dateOfBirth,
            string phoneNumber, string email, DateTime startOfEmployment,
            bool isActive, DateTime? endOfEmployment, Role role)
        {
            SetUserDetails(userName, password, firstName, secondName, lastName, 
                dateOfBirth, phoneNumber, email, startOfEmployment, isActive, endOfEmployment, role);
        }
    }
}
