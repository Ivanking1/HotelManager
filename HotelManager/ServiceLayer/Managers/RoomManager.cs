

using DataLayer;
using FireSharp.Interfaces;
using System.Linq;

namespace ServiceLayer
{
    public class RoomManager
    {
        private readonly RoomContext roomContext;
        public RoomManager()//constructor without parameters
        {
            roomContext = new RoomContext();
        }
        public RoomManager(IFirebaseClient firebaseClient)
        {
            roomContext = new RoomContext(firebaseClient);
        }

        public async Task CreateAsync(Room room)
        {
            if (room is null)
                throw new ArgumentNullException(nameof(room), "Room cannot be null.");

            await EnsureUniqueRoomAsync(room);

            await roomContext.CreateAsync(room);
        }

        public async Task<Room> ReadAsync(Guid roomId, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            if (roomId == Guid.Empty)
                throw new ArgumentException("Invalid Room ID.", nameof(roomId));

            var room = await roomContext.ReadAsync(roomId, useNavigationalProperties, isReadOnly);
            if (room is null)
                throw new KeyNotFoundException($"Room with ID {roomId} does not exist.");

            return room;
        }

        public async Task<ICollection<Room>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await roomContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Room room, bool useNavigationalProperties = false)
        {
            if (room is null)
                throw new ArgumentNullException(nameof(room), "Room cannot be null.");

            var existingRoom = await roomContext.ReadAsync(room.Id, useNavigationalProperties, false);
            if (existingRoom is null)
                throw new KeyNotFoundException($"Room with ID {room.Id} does not exist.");

            await EnsureUniqueRoomAsync(room, existingRoom.Id);

            await roomContext.UpdateAsync(room, useNavigationalProperties);
        }

        public async Task DeleteAsync(Guid roomId)
        {
            if (roomId == Guid.Empty)
                throw new ArgumentException("Invalid Room ID.", nameof(roomId));

            var existingRoom = await roomContext.ReadAsync(roomId, false, false);
            if (existingRoom is null)
                throw new KeyNotFoundException($"Room with ID {roomId} does not exist.");

            await roomContext.DeleteAsync(roomId);
        }
        private async Task EnsureUniqueRoomAsync(Room room, Guid? existingRoomId = null)
        {
            var existingRooms = await roomContext.ReadAllAsync();

            if (existingRooms.Any(r => r.RoomNumber == room.RoomNumber && r.Id != existingRoomId))
                throw new InvalidOperationException($"A room with number {room.RoomNumber} already exists.");
        }
    }
}
