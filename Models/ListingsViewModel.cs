using RealEstateApp.Models;
using System.Collections.Generic;

namespace RealEstateApp.Models
{
    public class ListingsViewModel
    {
        public List<Listing> Listings { get; set; }
        public bool isCreatingListing { get; set; }
    }
}