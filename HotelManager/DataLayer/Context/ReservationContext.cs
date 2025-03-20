using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ReservationContext : IDb<Reservation, Guid>
    {
        private readonly HotelManagerDbContext dbContext;
        public ReservationContext()//constructor without parameters
        {
            dbContext = new HotelManagerDbContext();
        }
        public ReservationContext(HotelManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Reservation entity)
        {
            try
            {
                await dbContext.Reservations.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Reservation> ReadAsync(Guid key, bool NavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Reservation> query = dbContext.Reservations;

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

        public async Task<ICollection<Reservation>> ReadAllAsync(bool NavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Reservation> query = dbContext.Reservations;

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

        public async Task UpdateAsync(Reservation entity, bool NavigationalProperties = false)
        {
            try
            {
                Reservation reservationFromDb = await ReadAsync(entity.Id, NavigationalProperties, false);

                if (reservationFromDb is null)
                {
                    throw new ArgumentException("Reservation with id = " + entity.Id + " does not exist!");
                }

                dbContext.Entry(reservationFromDb).CurrentValues.SetValues(entity);
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
                Reservation reservation = await ReadAsync(key, false, false);

                if (reservation is null)
                {
                    throw new ArgumentException("Reservation with id = " + key + " does not exist!");
                }

                dbContext.Reservations.Remove(reservation);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
