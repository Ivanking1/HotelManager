using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string SocialSecurity { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime StartOfEmployment { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime? EndOfEmployment { get; set; }

        [Required]
        public ushort Role { get; set; }

        public User()
        {

        }

        public User(string userName, string password, string firstName,
            string secondName, string familyName, string socialSecurity,
            string phoneNumber, string email, DateTime startOfEmployment,
            bool isActive, DateTime? endOfEmployment, ushort role)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            SecondName = secondName;
            FamilyName = familyName;
            SocialSecurity = socialSecurity;
            PhoneNumber = phoneNumber;
            Email = email;
            StartOfEmployment = startOfEmployment;
            IsActive = isActive;
            EndOfEmployment = endOfEmployment;
            Role = role;
        }
    }
}
