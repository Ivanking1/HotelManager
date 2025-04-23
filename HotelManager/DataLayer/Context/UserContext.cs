using BusinessLayer;

using FireSharp.Config;
using FireSharp.Interfaces;

using FireSharp.Response;



namespace DataLayer
{
    public class UserContext : IDb<User, Guid>
    {
        private readonly IFirebaseClient client;

        public UserContext()//constructor without parameters
        {
            client = FirebaseClientProvider.Client;
        }
        public UserContext(IFirebaseClient firebaseClient)
        {
            client = firebaseClient ?? throw new ArgumentNullException(nameof(firebaseClient));
        }

        public async Task CreateAsync(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var firebaseUser = ToFirebaseUser(entity);
            await client.SetAsync($"users/{firebaseUser.Id}", firebaseUser);
        }

        public async Task<User> ReadAsync(Guid key, bool NavigationalProperties = false, bool isReadOnly = true)
        {
            var response = await client.GetAsync($"users/{key}");
            var firebaseUser = response.ResultAs<FirebaseUser>();
            return firebaseUser == null ? null : ToDomainUser(firebaseUser);
        }

        public async Task<ICollection<User>> ReadAllAsync(bool NavigationalProperties = false, bool isReadOnly = true)
        {
            var response = await client.GetAsync("users");
            var usersDict = response.ResultAs<Dictionary<string, FirebaseUser>>();

            return usersDict?.Values.Select(ToDomainUser).ToList() ?? new List<User>();
        }

        public async Task UpdateAsync(User entity, bool NavigationalProperties = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var firebaseUser = ToFirebaseUser(entity);
            await client.UpdateAsync($"users/{firebaseUser.Id}", firebaseUser);
        }

        public async Task DeleteAsync(Guid key)
        {
            await client.DeleteAsync($"users/{key}");
        }
        private FirebaseUser ToFirebaseUser(User user)
        {
            return new FirebaseUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                StartOfEmployment = user.StartOfEmployment,
                IsActive = user.IsActive,
                EndOfEmployment = user.EndOfEmployment,
                Role = user.Role
            };
        }

        private User ToDomainUser(FirebaseUser user)
        {
            return new User(
                user.Id,
                user.UserName,
                user.Password,
                user.FirstName,
                user.SecondName,
                user.LastName,
                user.DateOfBirth,
                user.PhoneNumber,
                user.Email,
                user.StartOfEmployment,
                user.IsActive,
                user.EndOfEmployment,
                user.Role
            );
        }
    }
}
