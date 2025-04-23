using BusinessLayer;
using FireSharp.Interfaces;

namespace DataLayer
{
    public class RoomContext : IDb<Room, Guid>
    {
        private readonly IFirebaseClient client;
        public RoomContext()
        {
            client = FirebaseClientProvider.Client;
        }
        public RoomContext(IFirebaseClient firebaseClient)
        {
            client = firebaseClient ?? throw new ArgumentNullException(nameof(firebaseClient));
        }

        public async Task CreateAsync(Room entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var firebaseRoom = ToFirebaseRoom(entity);
            await client.SetAsync($"rooms/{firebaseRoom.Id}", firebaseRoom);
        }

        public async Task<Room> ReadAsync(Guid key, bool NavigationalProperties = false, bool isReadOnly = true)
        {
            var response = await client.GetAsync($"rooms/{key}");
            var firebaseRoom = response.ResultAs<FirebaseRoom>();
            return firebaseRoom == null ? null : ToDomainRoom(firebaseRoom);
        }

        public async Task<ICollection<Room>> ReadAllAsync(bool NavigationalProperties = false, bool isReadOnly = true)
        {
            var response = await client.GetAsync("rooms");
            var roomsDict = response.ResultAs<Dictionary<string, FirebaseRoom>>();

            return roomsDict?.Values.Select(ToDomainRoom).ToList() ?? new List<Room>();
        }

        public async Task UpdateAsync(Room entity, bool NavigationalProperties = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var firebaseRoom = ToFirebaseRoom(entity);
            await client.UpdateAsync($"rooms/{firebaseRoom.Id}", firebaseRoom);
        }

        public async Task DeleteAsync(Guid key)
        {
            await client.DeleteAsync($"rooms/{key}");
        }
        private FirebaseRoom ToFirebaseRoom(Room room)
        {
            return new FirebaseRoom
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,  
                Capacity = room.Capacity,      
                RoomType = room.RoomType,       
                IsAvailable = room.IsAvailable,
                AdultPrice = room.AdultPrice,   
                ChildPrice = room.ChildPrice   
            };
        }

        // Mapping from FirebaseRoom to Room domain object
        private Room ToDomainRoom(FirebaseRoom firebaseRoom)
        {
            return new Room(
                firebaseRoom.Id,
                firebaseRoom.RoomNumber,
                firebaseRoom.RoomType,
                firebaseRoom.IsAvailable,
                firebaseRoom.AdultPrice,
                firebaseRoom.ChildPrice
            );
        }
    }
}
