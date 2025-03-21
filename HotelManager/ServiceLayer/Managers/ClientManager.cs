﻿
using DataLayer;

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
            this.clientContext = clientContext;
        }
        public async Task CreateAsync(Client client)
        {
            await clientContext.CreateAsync(client);
        }

        public async Task<Client> ReadAsync(Guid clientId, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await clientContext.ReadAsync(clientId, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<Client>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await clientContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Client client, bool useNavigationalProperties = false)
        {
            await clientContext.UpdateAsync(client, useNavigationalProperties);
        }

        public async Task DeleteAsync(Guid clientId)
        {
            await clientContext.DeleteAsync(clientId);
        }
    }
}
