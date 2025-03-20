using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserContext : IDb<User, Guid>
    {
        private readonly HotelManagerDbContext dbContext;

        public UserContext()//constructor without parameters
        {
            dbContext = new HotelManagerDbContext();
        }
        public UserContext(HotelManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(User entity)
        {
            try
            {
                await dbContext.Users.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> ReadAsync(Guid key, bool NavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

                
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

        public async Task<ICollection<User>> ReadAllAsync(bool NavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

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

        public async Task UpdateAsync(User entity, bool NavigationalProperties = false)
        {
            try
            {
                User userFromDb = await ReadAsync(entity.Id, NavigationalProperties, false);

                if (userFromDb is null)
                {
                    throw new ArgumentException("User with id = " + entity.Id + " does not exist!");
                }

                dbContext.Entry(userFromDb).CurrentValues.SetValues(entity);
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
                User user = await ReadAsync(key, false, false);

                if (user is null)
                {
                    throw new ArgumentException("User with id = " + key + " does not exist!");
                }

                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
