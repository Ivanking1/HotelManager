

using DataLayer;

namespace ServiceLayer
{
    public class ReservationManager
    {
        private readonly ReservationContext reservationContext;
        public ReservationManager()//constructor without parameters
        {
            reservationContext = new ReservationContext();
        }
        public async Task CreateAsync(Reservation reservation)
        {
            await reservationContext.CreateAsync(reservation);
        }

        public async Task<Reservation> ReadAsync(Guid reservationId, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await reservationContext.ReadAsync(reservationId, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<Reservation>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await reservationContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Reservation reservation, bool useNavigationalProperties = false)
        {
            await reservationContext.UpdateAsync(reservation, useNavigationalProperties);
        }

        public async Task DeleteAsync(Guid reservationId)
        {
            await reservationContext.DeleteAsync(reservationId);
        }
    }
}
