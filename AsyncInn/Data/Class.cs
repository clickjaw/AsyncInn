using System.Reflection.Emit;
using System.Reflection.Metadata;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AsyncInn.Data
{
	public class TestDbContext: DbContext
	{
		
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Amenity> Amenities { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 1, Name = "The M2", StreetAddress = "1300 Apple Ave", City = "Memphis", State = "TN", Country = "US", Phone = "901-555-7364" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 2, Name = "Process Inn", StreetAddress = "32 Middling St", City = "Chicago", State = "IL", Country = "US", Phone = "901-555-3412" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 3, Name = "Retina Place", StreetAddress = "976 Bittle Ave", City = "Seattle", State = "WA", Country = "US", Phone = "901-555-4921" });

            modelBuilder.Entity<Room>().HasData(new Room {ID = 1, Name = "Blue Room", Layout = 0});
            modelBuilder.Entity<Room>().HasData(new Room {ID = 2, Name = "Green Room", Layout = 1});
            modelBuilder.Entity<Room>().HasData(new Room {ID = 3, Name = "Purple Room", Layout = 2 });

            modelBuilder.Entity<Amenity>().HasData(new Amenity { Id = 1, Name = "Smoking" }) ;
            modelBuilder.Entity<Amenity>().HasData(new Amenity { Id = 2, Name = "Non-Smoking" }) ;
            
        }


		
		public TestDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}

