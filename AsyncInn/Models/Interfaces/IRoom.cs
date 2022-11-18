using System;
using AsyncInn.Controllers;

namespace AsyncInn.Models.Interfaces
{
	public interface IRoom
	{
		Task<Room> Create(Room room);

		Task<Room> UpdateRoom(Room room);

		Task<Room> Delete(Room room);

		Task<Room> GetRoom(int? id);

		Task<List<Room>> GetRooms();

		Task<Room> SaveChanges();
		Task<Room> Find(int? id);

		bool Exists(int id);
	}
}

