using System;
using System.Linq;
using RealEstateApp.Models;
using System.Collections.Generic;
using System.Collections.Concurrent;
using RealEstateApp.Models;

namespace RealEstateApp.Services
{
    public class ListingService : IListingService
    {
        public ListingService() { }

        public List<Listing> GetAllListings()
        {
            using (var db = new ListingContext())
            {
                return db.Listings.ToList();
            }
        }

        public void Add(Listing item)
        {
            using (var db = new ListingContext())
            {
                Console.WriteLine("Adding Item with Listing Address:"+item.Address);
                db.Listings.Add(item);         
                db.SaveChanges();
            }
        }

        public Listing Find(string key)
        {
            Listing result;
            using (var db = new ListingContext()) 
            {
                result = db.Listings.FirstOrDefault(l => l.Id.ToString() == key);
            }

            return result;
        }

        public Listing Remove(string key)
        {
            Listing removed; 
            using (var db = new ListingContext())
            {
                removed = db.Listings.FirstOrDefault(l => l.Id.ToString() == key);
                Console.WriteLine("Removing Item with Id:"+removed.Id+" Listing Address:"+removed.Address);
                db.Listings.Remove(removed);         
                db.SaveChanges();
            }
            return removed;
        }

        public void Update(Listing item)
        {
            using (var db = new ListingContext())
            {
                var toUpdate = db.Listings.FirstOrDefault(l => l.Id == item.Id);
                toUpdate.Address = item.Address;
                toUpdate.Description = item.Description;
                toUpdate.Price = item.Price;
                db.SaveChanges();
            }
        }

        public void CheckDefaultListings()
        {
            List<Listing> defaultListings = new List<Listing> {
                new Listing {
                    Id = 1,
                    Price = 225000,
                    Description = "A beautiful two-story home in Northern Virginia surrounded by lush ...",
                    Address = "12345 Happy Street",
                    CreatedAt = DateTime.Today,
                },
                new Listing {
                    Id = 2,
                    Price = 150000,
                    Description = "A luxury town home featuring attractive brick exterior, attached basement & garage, fireplace ...",
                    Address = "15061 W 138th St, Olathe, KS 66062",
                    CreatedAt = DateTime.Today,
                },
                new Listing {
                    Id = 3,
                    Price = 246500,
                    Description = "Terrific home on large corner lot in very desirable Wexford subdivision. Lots of updates ...",
                    Address = "13826 S Kaw St., Olathe, KS 66062",
                    CreatedAt = DateTime.Today,
                },
                new Listing {
                    Id = 4,
                    Price = 1095000,
                    Description = "Someone who wants the ultimate in care free living and feel of vacation every day of the year ...",
                    Address = "13949 Canterbury Circle, Leawood, KS 66224",
                    CreatedAt = DateTime.Today,
                },
                new Listing {
                    Id = 5,
                    Price = 350000,
                    Description = "Country meets city. Fantastic 2 story home. 4 bedrooms, 3.5 baths",
                    Address = "2055 W. 162nd Terr, Stillwell, KS 66085",
                    CreatedAt = DateTime.Today,
                },
                new Listing {
                    Id = 6,
                    Price = 11100000,
                    Description = "Essenza's Headquarters. Bargain offer!",
                    Address = "11100 Ash Street, Suite 101, Leawood, KS 66211",
                    CreatedAt = DateTime.Today,
                }
            };

            using (var db = new ListingContext())
            {
                var currentListings = db.Listings;
                var isUpdated = false;

                var first = currentListings.FirstOrDefault(l => l.Id == 1);
                
                foreach (var listing in defaultListings)
                {
                    if (currentListings.FirstOrDefault(l => l.Id == listing.Id) == null) {
                        Console.WriteLine("Couldn't find listing for ID:"+listing.Id+"... Adding");
                        db.Listings.Add(listing);
                        isUpdated = true;
                    }
                }

                if (isUpdated) {
                    db.SaveChanges();
                }

                foreach (var listing in currentListings) {
                    Console.WriteLine("ListingId:"+listing.Id+" Listing Address:"+listing.Address);
                }
            }
        }
    }
}