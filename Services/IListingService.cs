using System.Collections.Generic;
using RealEstateApp.Models;

namespace RealEstateApp.Services
{
    public interface IListingService
    {
        void Add(Listing listing);
        List<Listing> GetAllListings();
        Listing Find(string key);
        Listing Remove(string key);
        void Update(Listing listing);
        void CheckDefaultListings();
    }
}