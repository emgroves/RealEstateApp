using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace RealEstateApp.Models
{
    public class ListingContext : DbContext
    {
        public DbSet<Listing> Listings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=../Listings.db");
        }
    }

    public class Listing
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}