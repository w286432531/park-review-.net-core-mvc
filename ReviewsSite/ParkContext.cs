using Microsoft.EntityFrameworkCore;
using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite
{
    public class ParkContext : DbContext
    {
        public DbSet<Park> Parks { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Company usually gives you server
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=ParkDB_100521; Trusted_Connection=true";


            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
        protected override void  OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Review>().HasData(
                 new Review() { Id = 1, ParkId = 1, ReviewerName = "Crys", Comment = "I really like take my dog to poop here.", StarRating = 1 },
                 new Review() { Id = 2, ParkId = 2, ReviewerName = "Richard", Comment = "This place is great, I love to canoe!!", StarRating = 5 },
                 new Review() { Id = 3, ParkId = 3, ReviewerName = "Kayley", Comment = "The park is nice.", StarRating = 3 }
                );
                 
            modelbuilder.Entity<Park>().HasData(
               new Park() { Id = 1, Name = "Edgewater", HasHandicapAccess = true, IsDogFriendly = true, ParkType = "Beach", ParkDescription = "The 147 acre Edgewater Park is the westernmost park in Cleveland Metroparks Lakefront Reservation. Edgewater Park features 9000 feet of shoreline, beaches, boat ramps,  fishing pier, picnic areas and grills. The park is both wheelchair accessible and dog friendly. Open daily 6am to 11pm. Located at 6500 Cleveland Memorial Shoreway in Cleveland" },
               new Park() { Id = 2, Name = "Mohican", HasHandicapAccess = false, IsDogFriendly = true, ParkType = "River", ParkDescription = "Has thousands of acres covered in woods and offers many hiking trails and water features. There is also a full-service lodge and family campground with a pool. Hours of operation vary depending on area and is located at 3116 OH-3 in Loudonville,Ohio." },
               new Park() { Id = 3, Name = "Kurtz", HasHandicapAccess = false, IsDogFriendly = false, ParkType = "Sport", ParkDescription = "Kurtz  park in Cuyahoga County has an elevation of 856 feet and is situated west of Parma Heights, located near Brook Park Fire Department Station 4." }
            );
        }
    }
}
