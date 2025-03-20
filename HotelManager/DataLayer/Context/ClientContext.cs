using BusinessLayer;
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
        private readonly HotelManagerDbContext dbContext;
        public ClientContext()//constructor without parameters
        {
            dbContext = new HotelManagerDbContext();
        }
        public ClientContext(HotelManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Client entity)
        {
            try
            {
                await dbContext.Clients.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Client> ReadAsync(Guid key, bool NavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Client> query = dbContext.Clients;

                if (isReadOnly)
                {
                    query.AsNoTrackingWithIdentityResolution();
                }

                return await query.SingleOrDefaultAsync(e => e.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<Client>> ReadAllAsync(bool NavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Client> query = dbContext.Clients;

                if (isReadOnly)
                {
                    query.AsNoTrackingWithIdentityResolution();
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Client entity, bool NavigationalProperties = false)
        {
            try
            {
                Client clientFromDb = await ReadAsync(entity.Id, NavigationalProperties, false);

                if (clientFromDb is null)
                {
                    throw new ArgumentException("Client with id = " + entity.Id + " does not exist!");
                }

                dbContext.Entry(clientFromDb).CurrentValues.SetValues(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Guid key)
        {
            try
            {
                Client client = await ReadAsync(key, false, false);

                if (client is null)
                {
                    throw new ArgumentException("Client with id = " + key + " does not exist!");
                }

                dbContext.Clients.Remove(client);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
