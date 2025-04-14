using BusinessLayer;
using FireSharp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ClientContext : IDb<Client,Guid>
    {
        private readonly IFirebaseClient client;
        public ClientContext()
        {
            client = FirebaseClientProvider.Client;
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
            var response = await client.GetAsync("clients");
            var clientsDict = response.ResultAs<Dictionary<string, FirebaseClient>>();

            return clientsDict?.Values.Select(ToDomainClient).ToList() ?? new List<Client>();
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
            //try
            //{
            //    Client client = await ReadAsync(key, false, false);

            //    if (client is null)
            //    {
            //        throw new ArgumentException("Client with id = " + key + " does not exist!");
            //    }//may replace with  new KeyNotFoundException($"Client with ID {key} does not exist.");

            //    this.client.Clients.Remove(client);
            //    await this.client.SaveChangesAsync();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
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
