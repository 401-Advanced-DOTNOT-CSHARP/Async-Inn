using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12_2.Models;

namespace Lab12_2.Data
{
    public class ASynceInnDbContext : DbContext
    {
        public ASynceInnDbContext(DbContextOptions<ASynceInnDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomAmenities>().HasKey(x => new { x.AmenitiesID, x.RoomID });
            modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelID, x.RoomNumber });

            /*
            modelBuilder.Entity<HotelRoom>().HasData(
                new HotelRoom
                {
                    HotelID = 1,
                    RoomNumber = 105,
                    RoomId = 1,
                    Rate = 65,
                    PetFriendly = true
                },
                new HotelRoom
                {
                    HotelID = 1,
                    RoomNumber = 110,
                    RoomId = 3,
                    Rate = 65,
                    PetFriendly = true
                }
                );
            */

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    City = "Seattle",
                    Name = "Bryant Comfort Inn",
                    PhoneNumber = "555-555-5555",
                    State = "Washington",
                    StretAddress = "123 Fake Street"
                },
                new Hotel
                {
                    Id = 2,
                    City = "Burien",
                    Name = "Bryant Resort",
                    PhoneNumber = "555-555-9999",
                    State = "Washington",
                    StretAddress = "312 Awesome Avenue"

                },
                new Hotel
                {
                    Id = 3,
                    City = "San Diego",
                    Name = "Bryant Sunny Lake View Hotel",
                    PhoneNumber = "888-777-6666",
                    State = "California",
                    StretAddress = "876 Burned Avenue"
                }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "Vampire Suite",
                    Layout = 2

                },
                new Room
                {
                    Id = 2,
                    Name = "Burned Villa",
                    Layout = 3
                },
                new Room
                {
                    Id = 3,
                    Name = "Boring Cottage",
                    Layout = 1
                }
                );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    Id = 1,
                    Name = "Air Conditioner"
                },
                new Amenity
                {
                    Id = 2,
                    Name = "Heater"
                },
                new Amenity
                {
                    Id = 3,
                    Name = "Fridge"
                }
                );
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenity { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }



    }
}
