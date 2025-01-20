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
        private readonly HotelManagerDbContext _DbContext;
        public UserContext(HotelManagerDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }
        public async Task CreateAsync(User entity)
        {
            try
            {
                await _DbContext.Users.AddAsync(entity);
                await _DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> ReadAsync(Guid key)
        {
            try
            {
                IQueryable<User> query = _DbContext.Users;

                return await query.SingleOrDefaultAsync(e => e.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<User>> ReadAllAsync()
        {
            try
            {
                IQueryable<User> query = _DbContext.Users;

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(User entity)
        {
            try
            {
                User userFromDb = await ReadAsync(entity.Id);

                if (userFromDb is null)
                {
                    throw new ArgumentException("User with id = " + entity.Id + " does not exist!");
                }

                _DbContext.Entry(userFromDb).CurrentValues.SetValues(entity);
                await _DbContext.SaveChangesAsync();
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
                User user = await ReadAsync(key);

                if (user is null)
                {
                    throw new ArgumentException("User with id = " + key + " does not exist!");
                }

                _DbContext.Users.Remove(user);
                await _DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
