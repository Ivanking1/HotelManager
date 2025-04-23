using BusinessLayer;
using FireSharp.Interfaces;
using System.Diagnostics;


namespace DataLayer
{
    public class ClientContext : IDb<Client,Guid>
    {
        private readonly IFirebaseClient client;
        public ClientContext()
        {
            client = FirebaseClientProvider.Client;
        }
        public ClientContext(IFirebaseClient firebaseClient)
        {
            client = firebaseClient ?? throw new ArgumentNullException(nameof(firebaseClient));
        }

        public async Task CreateAsync(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var firebaseClient = ToFirebaseClient(entity);
            await client.SetAsync($"clients/{firebaseClient.Id}", firebaseClient);
        }

        public async Task<Client> ReadAsync(Guid key, bool NavigationalProperties = false, bool isReadOnly = true)
        {
            var response = await client.GetAsync($"clients/{key}");
            var firebaseClient = response.ResultAs<FirebaseClient>();
            return firebaseClient == null ? null : ToDomainClient(firebaseClient);
        }

        public async Task<ICollection<Client>> ReadAllAsync(bool NavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                if (client == null)
                {
                    Debug.WriteLine("FIREBASE CLIENT IS NULL!");
                    return new List<Client>();
                }
                Debug.WriteLine("[ClientContext] Starting ReadAllAsync");

                var response = await client.GetAsync("clients").ConfigureAwait(false);

                Debug.WriteLine($"[ClientContext] Firebase response: {response?.Body ?? "NULL"}");

                if (response?.Body == "null" || string.IsNullOrEmpty(response?.Body))
                {
                    Debug.WriteLine("[ClientContext] No clients found in database");
                    return new List<Client>();
                }

                var clientsDict = response.ResultAs<Dictionary<string, FirebaseClient>>();
                var clients = clientsDict?.Values.Select(ToDomainClient).ToList() ?? new List<Client>();

                Debug.WriteLine($"[ClientContext] Returning {clients.Count} clients");
                return clients;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ClientContext] Error in ReadAllAsync: {ex}");
                throw; // Re-throw to see the error in calling code
            }
            //var response = await client.GetAsync("clients");
            //var clientsDict = response.ResultAs<Dictionary<string, FirebaseClient>>();

            //return clientsDict?.Values.Select(ToDomainClient).ToList() ?? new List<Client>();
        }

        public async Task UpdateAsync(Client entity, bool NavigationalProperties = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var firebaseClient = ToFirebaseClient(entity);
            await client.UpdateAsync($"clients/{firebaseClient.Id}", firebaseClient);
        }

        public async Task DeleteAsync(Guid key)
        {
            await client.DeleteAsync($"clients/{key}");
           
        }
        private FirebaseClient ToFirebaseClient(Client client)
        {
            return new FirebaseClient
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Age = client.Age
            };
        }

        // Mapping from FirebaseClient to Client domain object
        private Client ToDomainClient(FirebaseClient firebaseClient)
        {
            return new Client(
                firebaseClient.Id,
                firebaseClient.FirstName,
                firebaseClient.LastName,
                firebaseClient.PhoneNumber,
                firebaseClient.Email,
                firebaseClient.Age
            );
        }
    }
}
