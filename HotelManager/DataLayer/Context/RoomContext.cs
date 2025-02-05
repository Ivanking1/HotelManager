using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class RoomContext : IDb<Room, Guid>
    {
        private readonly HotelManagerDbContext dbContext;
        public RoomContext(HotelManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Room entity)
        {
            try
            {
                await dbContext.Rooms.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Room> ReadAsync(Guid key, bool NavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Room> query = dbContext.Rooms;

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

        public async Task<ICollection<Room>> ReadAllAsync(bool NavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Room> query = dbContext.Rooms;

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

        public async Task UpdateAsync(Room entity, bool NavigationalProperties = false)
        {
            try
            {
                Room roomFromDb = await ReadAsync(entity.Id, NavigationalProperties, false);

                if (roomFromDb is null)
                {
                    throw new ArgumentException("Room with id = " + entity.Id + " does not exist!");
                }

                dbContext.Entry(roomFromDb).CurrentValues.SetValues(entity);
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
                Room room = await ReadAsync(key, false, false);

                if (room is null)
                {
                    throw new ArgumentException("Room with id = " + key + " does not exist!");
                }

                dbContext.Rooms.Remove(room);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
