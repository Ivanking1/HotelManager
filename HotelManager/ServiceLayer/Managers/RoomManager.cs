﻿

using DataLayer;

namespace ServiceLayer
{
    public class RoomManager
    {
        private readonly RoomContext roomContext;
        public RoomManager()//constructor without parameters
        {
            roomContext = new RoomContext();
        }
        public RoomManager(RoomContext roomContext)
        {
            this.roomContext = roomContext;
        }

        public async Task CreateAsync(Room room)
        {
            await roomContext.CreateAsync(room);
        }

        public async Task<Room> ReadAsync(Guid roomId, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await roomContext.ReadAsync(roomId, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<Room>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await roomContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Room room, bool useNavigationalProperties = false)
        {
            await roomContext.UpdateAsync(room, useNavigationalProperties);
        }

        public async Task DeleteAsync(Guid roomId)
        {
            await roomContext.DeleteAsync(roomId);
        }
    }
}
