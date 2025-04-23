


using FireSharp.Interfaces;
using System.Linq;

namespace ServiceLayer
{
    public class UserManager
    {
        private readonly UserContext userContext;
        public UserManager()//constructor without parameters
        {
            userContext = new UserContext();
        }
        public UserManager(IFirebaseClient firebaseClient)
        {
            userContext = new UserContext(firebaseClient);
        }

        public async Task CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            await EnsureUniqueUserAsync(user);

            // Hash password before saving
            user.SetPassword(user.Password);

            await userContext.CreateAsync(user);
        }

        public async Task<User> ReadAsync(Guid userId, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Invalid User ID.", nameof(userId));

            var user = await userContext.ReadAsync(userId, useNavigationalProperties, isReadOnly);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {userId} does not exist.");

            return user;
        }

        public async Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await userContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(User user, bool useNavigationalProperties = false)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            var existingUser = await userContext.ReadAsync(user.Id, useNavigationalProperties, false);
            if (existingUser == null)
                throw new KeyNotFoundException($"User with ID {user.Id} does not exist.");

            await EnsureUniqueUserAsync(user, existingUser.Id);

            // Preserve existing hashed password unless explicitly changed
            if (!string.IsNullOrWhiteSpace(user.Password) && !existingUser.VerifyPassword(user.Password))
            {
                if (!IsPasswordHashed(user.Password))
                {
                    existingUser.SetPassword(user.Password); // Only hash if it’s raw
                }
               
            }

            // Update user details
            existingUser.UpdateUser(user.UserName, existingUser.Password, user.FirstName, user.SecondName, user.LastName,
                                    user.DateOfBirth, user.PhoneNumber, user.Email, user.StartOfEmployment, user.IsActive,
                                    user.EndOfEmployment, user.Role);

            await userContext.UpdateAsync(existingUser, useNavigationalProperties);
        }

        public async Task DeleteAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Invalid User ID.", nameof(userId));

            var existingUser = await userContext.ReadAsync(userId, false, false);
            if (existingUser == null)
                throw new KeyNotFoundException($"User with ID {userId} does not exist.");

            await userContext.DeleteAsync(userId);
        }

        private async Task EnsureUniqueUserAsync(User user, Guid? existingUserId = null)
        {
            var existingUsers = await userContext.ReadAllAsync();

            if (existingUsers.Any(u => u.UserName == user.UserName && u.Id != existingUserId))
                throw new InvalidOperationException($"A user with username '{user.UserName}' already exists.");

            if (!string.IsNullOrWhiteSpace(user.Email) &&
                existingUsers.Any(u => u.Email == user.Email && u.Id != existingUserId))
                throw new InvalidOperationException($"A user with email '{user.Email}' already exists.");
        }
        bool IsPasswordHashed(string password)
        {
            return password.StartsWith("$2a$") || password.StartsWith("$2b$") || password.StartsWith("$2y$");
        }
    }
}
