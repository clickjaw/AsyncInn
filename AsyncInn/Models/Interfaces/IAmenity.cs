using System;
//using AsyncInn.Controllers;

namespace AsyncInn.Models.Interfaces
{
	public interface IAmenity
	{
		Task<Amenity> Create(Amenity amenity);

		Task<Amenity> UpdateAmenity(Amenity amenity);

		Task<Amenity> Delete(Amenity amenity);

		Task<Amenity> GetAmenity(int? id);

		Task<List<Amenity>> GetAmenities();

		Task<Amenity> Find(int? id);

		Task<Amenity> SaveChanges();

		bool AmenityExists(int id);


	}
}

