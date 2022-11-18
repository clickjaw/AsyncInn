using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models;

namespace AsyncInn.Models.Services
{
    public class RoomService : IRoom
    {
        private readonly TestDbContext _testDbContext;
        public RoomService(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }
        public async Task<Room> Create(Room room)
        {
            _testDbContext.Entry(room).State = EntityState.Added;

            return room;
        }
        public async Task<Room> UpdateRoom(Room room)
        {
            _testDbContext.Update(room);
            SaveChanges();
            return room;
        }
        public async Task<Room> Find(int? id)
        {
            return await _testDbContext.Rooms.FindAsync(id);
        }
        public async Task<Room> Delete(Room room)
        {
            _testDbContext.Rooms.Remove(room);
            return null;
        }
        public async Task<List<Room>> GetRooms()
        {
            return await _testDbContext.Rooms.ToListAsync();
        }
        public async Task<Room> GetRoom(int? id)
        {
            return await _testDbContext.Rooms.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<Room> SaveChanges()
        {
            await _testDbContext.SaveChangesAsync();
            return null;
        }

        public bool Exists(int id)
        {
            return _testDbContext.Rooms.Any(e => e.ID == id);
        }
    }
}