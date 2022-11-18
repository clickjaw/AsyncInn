using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.Interfaces;
//using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using AsyncInn.Models;

namespace AsyncInn.Models.Services
{
    public class HotelService : IHotel
    {
        private readonly TestDbContext _testDbContext;
        public HotelService(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }
        public async Task<Hotel> Create(Hotel hotel)
        {
            _testDbContext.Entry(hotel).State = EntityState.Added;
            await SaveChanges();

            return hotel;
        }
        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            _testDbContext.Update(hotel);
            SaveChanges();
            return hotel;
        }
        public async Task<Hotel> Find(int? id)
        {
            return await _testDbContext.Hotels.FindAsync(id);
        }
        public async Task<Hotel> Delete(Hotel hotel)
        {
            _testDbContext.Hotels.Remove(hotel);
            return null;
        }
        public async Task<List<Hotel>> GetHotels()
        {
            // this is from the hotelscontroller method
            //await _context.Hotels.ToListAsync()
            return await _testDbContext.Hotels.ToListAsync();
        }
        public async Task<Hotel> GetHotel(int? id)
        {
            return await _testDbContext.Hotels.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<Hotel> SaveChanges()
        {
            await _testDbContext.SaveChangesAsync();
            return null;
        }

        public bool Exists(int id)
        {
            return _testDbContext.Hotels.Any(e => e.ID == id);
        }
    }
}