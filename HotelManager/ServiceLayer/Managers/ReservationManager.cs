

using DataLayer;
using FireSharp.Interfaces;
using System.Linq;

namespace ServiceLayer
{
    public class ReservationManager
    {
        private readonly ReservationContext reservationContext;
        private readonly RoomContext roomContext;
        private readonly UserContext userContext;
        public ReservationManager()//constructor without parameters
        {
            reservationContext = new ReservationContext();
            roomContext = new RoomContext();
            userContext = new UserContext();
        }
        public ReservationManager(IFirebaseClient firebaseClient)
        {
            reservationContext = new ReservationContext(firebaseClient);
            roomContext = new RoomContext(firebaseClient);
            userContext = new UserContext(firebaseClient);
        }

        // Constructor with dependency injection (recommended)
        public ReservationManager(ReservationContext reservationContext, RoomContext roomContext, UserContext userContext)
        {
            this.reservationContext = reservationContext ?? throw new ArgumentNullException(nameof(reservationContext));
            this.roomContext = roomContext ?? throw new ArgumentNullException(nameof(roomContext));
            this.userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }
        public async Task CreateAsync(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation), "Reservation cannot be null.");

            await EnsureReservationIsValidAsync(reservation);

            await reservationContext.CreateAsync(reservation);
        }

        public async Task<Reservation> ReadAsync(Guid reservationId, bool useNavigationalProperties = true, bool isReadOnly = true)
        {
            return await reservationContext.ReadAsync(reservationId, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<Reservation>> ReadAllAsync(bool useNavigationalProperties = true, bool isReadOnly = true)
        {
            return await reservationContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Reservation reservation, bool useNavigationalProperties = true)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation), "Reservation cannot be null.");

            await EnsureReservationIsValidAsync(reservation, reservation.Id);

            await reservationContext.UpdateAsync(reservation, useNavigationalProperties);
        }

        public async Task DeleteAsync(Guid reservationId)
        {
            if (reservationId == Guid.Empty)
                throw new ArgumentException("Invalid reservation ID.", nameof(reservationId));

            await reservationContext.DeleteAsync(reservationId);
        }
        private async Task EnsureReservationIsValidAsync(Reservation reservation, Guid? existingReservationId = null)
        {
            // Ensure the room exists
            var room = await roomContext.ReadAsync(reservation.RoomId, false, true);
            if (room == null)
                throw new KeyNotFoundException($"Room with ID {reservation.RoomId} does not exist.");

            // Ensure the user exists
            var user = await userContext.ReadAsync(reservation.UserId, false, true);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {reservation.UserId} does not exist.");

            // Ensure guests list is valid
            if (reservation.Guests == null || !reservation.Guests.Any())
                throw new ArgumentException("At least one guest must be included in the reservation.");

            if (reservation.Guests.Count > room.Capacity)
                throw new ArgumentException($"Room capacity exceeded. Max capacity: {room.Capacity}, Provided guests: {reservation.Guests.Count}");

            // Ensure the room is not already booked for the given date range
            var allReservations = await reservationContext.ReadAllAsync();
            bool isRoomBooked = allReservations.Any(r =>
                r.RoomId == reservation.RoomId &&
                r.Id != existingReservationId && // Exclude the current reservation if updating
                r.StartingDate < reservation.EndingDate &&
                r.EndingDate > reservation.StartingDate
            );

            if (isRoomBooked)
                throw new InvalidOperationException("Room is already booked for the selected dates.");
        }
    }
}
