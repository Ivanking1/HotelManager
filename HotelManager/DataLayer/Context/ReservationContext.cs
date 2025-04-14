using BusinessLayer;
using Microsoft.EntityFrameworkCore;

using FireSharp.Config;
using FireSharp.Interfaces;

using FireSharp.Response;


namespace DataLayer
{
    public class ReservationContext : IDb<Reservation, Guid>
    {
        private readonly IFirebaseClient client;
        public ReservationContext()//constructor without parameters
        {
            client = FirebaseClientProvider.Client;
        }
        
        public async Task CreateAsync(Reservation entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var firebaseReservation = ToFirebaseReservation(entity);
            await client.SetAsync($"reservations/{firebaseReservation.Id}", firebaseReservation);
        }

        public async Task<Reservation> ReadAsync(Guid key, bool NavigationalProperties = false, bool isReadOnly = true)
        {
            var response = await client.GetAsync($"reservations/{key}");
            var firebaseReservation = response.ResultAs<FirebaseReservation>();

            if (firebaseReservation == null)
                return null;

            return await ToDomainReservation(firebaseReservation, NavigationalProperties);
        }

        public async Task<ICollection<Reservation>> ReadAllAsync(bool NavigationalProperties = false, bool isReadOnly = true)
        {
            var response = await client.GetAsync("reservations");
            var dict = response.ResultAs<Dictionary<string, FirebaseReservation>>();

            var reservations = new List<Reservation>();
            foreach (var firebaseRes in dict?.Values ?? Enumerable.Empty<FirebaseReservation>())
            {
                var domainRes = await ToDomainReservation(firebaseRes, NavigationalProperties);
                reservations.Add(domainRes);
            }

            return reservations;
        }

        public async Task UpdateAsync(Reservation entity, bool NavigationalProperties = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var firebaseReservation = ToFirebaseReservation(entity);
            await client.UpdateAsync($"reservations/{firebaseReservation.Id}", firebaseReservation);
        }

        public async Task DeleteAsync(Guid key)
        {
            await client.DeleteAsync($"reservations/{key}");
        }
        private FirebaseReservation ToFirebaseReservation(Reservation r)
        {
            return new FirebaseReservation
            {
                Id = r.Id,
                RoomId = r.ReservedRoom.Id,
                UserId = r.BookedBy.Id,
                Guests = r.Guests?.Select(c => ToFirebaseClient(c)).ToList(),
                StartingDate = r.StartingDate,
                EndingDate = r.EndingDate,
                MealPlan = r.MealPlan,
                Price = r.Price
            };
        }
        private async Task<Reservation> ToDomainReservation(FirebaseReservation f, bool includeNavigation)
        {
            Room room;
            User user;

            if (includeNavigation)
            {
                var roomContext = new RoomContext(); // or inject it
                var userContext = new UserContext();
                room = await roomContext.ReadAsync(f.RoomId);
                user = await userContext.ReadAsync(f.UserId);
            }
            else
            {
                room = new Room(f.RoomId); // minimal constructor
                user = new User(f.UserId); // minimal constructor
            }

            var guests = f.Guests?.Select(ToDomainClient).ToList() ?? new List<Client>();

            return new Reservation(
                f.Id,
                room,
                user,
                guests,
                f.StartingDate,
                f.EndingDate,
                f.MealPlan
            );
        }
        private FirebaseClient ToFirebaseClient(Client client)
        {
            if (client == null) return null;

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

        private Client ToDomainClient(FirebaseClient client)
        {
            return new Client(
                client.Id,
                client.FirstName,
                client.LastName,
                client.PhoneNumber,
                client.Email,
                client.Age
            );
        }
    }
}
