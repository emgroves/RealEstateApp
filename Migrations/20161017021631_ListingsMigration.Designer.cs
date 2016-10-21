using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RealEstateApp.Models;

namespace RealEstateApp.Migrations
{
    [DbContext(typeof(ListingContext))]
    [Migration("20161017021631_ListingsMigration")]
    partial class ListingsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("RealEstateApp.Models.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.ToTable("Listings");
                });
        }
    }
}
