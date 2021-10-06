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

        }
    }
}
