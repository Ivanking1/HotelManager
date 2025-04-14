
namespace BusinessLayer
{
    public class FirebaseUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime StartOfEmployment { get; set; }
        public bool IsActive { get; set; }
        public DateTime? EndOfEmployment { get; set; }
        public Role Role { get; set; }
    }
}
