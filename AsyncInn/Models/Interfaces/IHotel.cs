using System;
namespace AsyncInn.Models.Interfaces
{
	public interface IHotel
	{
		Task<Hotel> Create(Hotel hotel);

		Task<Hotel> UpdateHotel(Hotel hotel);

		Task<Hotel> Delete(Hotel hotel);

		Task<Hotel> GetHotel(int? id);

		Task<List<Hotel>> GetHotels();

		Task<Hotel> Find(int? id);

		Task<Hotel> SaveChanges();

		bool Exists(int id);

	}
}

