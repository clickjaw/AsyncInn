using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models;

namespace AsyncInn.Models.Services
{
    public class AmenityService : IAmenity
    {
        private readonly TestDbContext _testDbContext;
        public AmenityService(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }
        public async Task<Amenity> Create(Amenity amenity)
        {
            _testDbContext.Entry(amenity).State = EntityState.Added;

            return amenity;
        }
        public async Task<Amenity> UpdateAmenity(Amenity amenity)
        {
            _testDbContext.Update(amenity);
            SaveChanges();
            return amenity;
        }
        public async Task<Amenity> Find(int? id)
        {
            return await _testDbContext.Amenities.FindAsync(id);
        }
        public async Task<Amenity> Delete(Amenity amenity)
        {
            _testDbContext.Amenities.Remove(amenity);
            return null;
        }
        public async Task<List<Amenity>> GetAmenities()
        {
            return await _testDbContext.Amenities.ToListAsync();
        }
        public async Task<Amenity> GetAmenity(int? id)
        {
            return await _testDbContext.Amenities.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Amenity> SaveChanges()
        {
            await _testDbContext.SaveChangesAsync();
            return null;
        }

        public bool AmenityExists(int id)
        {
            return _testDbContext.Amenities.Any(e => e.Id == id);
        }
    }
}