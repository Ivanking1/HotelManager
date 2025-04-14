
using DataLayer;
using System.Linq;

namespace ServiceLayer
{
    public class ClientManager
    {
        private readonly ClientContext clientContext;
        public ClientManager()//constructor without parameters
        {
            clientContext = new ClientContext();
        }
        public ClientManager(ClientContext clientContext)
        {
            this.clientContext = clientContext ?? throw new ArgumentNullException(nameof(clientContext));
        }
        public async Task CreateAsync(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client), "Client cannot be null.");

            await EnsureUniqueClientAsync(client);

            await clientContext.CreateAsync(client);
        }

        public async Task<Client> ReadAsync(Guid clientId, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("Invalid Client ID.", nameof(clientId));

            var client = await clientContext.ReadAsync(clientId, useNavigationalProperties, isReadOnly);

            if (client == null)
                throw new KeyNotFoundException($"Client with ID {clientId} does not exist.");

            return client;
        }

        public async Task<ICollection<Client>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await clientContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Client client, bool useNavigationalProperties = false)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client), "Client cannot be null.");

            var existingClient = await clientContext.ReadAsync(client.Id, useNavigationalProperties, false);
            if (existingClient == null)
                throw new KeyNotFoundException($"Client with ID {client.Id} does not exist.");

            await EnsureUniqueClientAsync(client, existingClient.Id);

            await clientContext.UpdateAsync(client, useNavigationalProperties);
        }

        public async Task DeleteAsync(Guid clientId)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("Invalid Client ID.", nameof(clientId));

            var existingClient = await clientContext.ReadAsync(clientId, false, false);
            if (existingClient == null)
                throw new KeyNotFoundException($"Client with ID {clientId} does not exist.");

            await clientContext.DeleteAsync(clientId);
        }
        private async Task EnsureUniqueClientAsync(Client client, Guid? existingClientId = null)
        {
            var existingClients = await clientContext.ReadAllAsync();

            if (existingClients.Any(c => c.Email == client.Email && c.Id != existingClientId))
                throw new InvalidOperationException($"A client with email {client.Email} already exists.");
        }
    }
}
