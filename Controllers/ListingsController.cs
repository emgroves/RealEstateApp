using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RealEstateApp.Models;
using RealEstateApp.Services;


namespace RealEstateApp.Controllers
{
    [Route("listings")]
    public class ListingsController : Controller
    {
        private IListingService _listingService;
        public ListingsController(IListingService listingService) 
        {
            _listingService = listingService;
        }

        public IActionResult Index()
        {
            var listings = _listingService.GetAllListings();
            return View(new ListingsViewModel { Listings = listings });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var item = _listingService.Find(id);
            Console.WriteLine("value of item: " + item);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost("")] 
        public IActionResult Post(string address, string description, string price) 
        {
            var listing = new Listing {
                Address = address,
                Description = description,
                Price = Convert.ToInt32(price),
                CreatedAt = DateTime.Now,
            };

            _listingService.Add(listing);

            return new JsonResult(new {success = true});
        }

        [HttpPost("{id}/details/delete")]
        public IActionResult Delete(string id)
        {
            var item = _listingService.Remove(id);
            Console.WriteLine("value of deleted item: " + item);
            if (item == null)
            {
                return NotFound();
            }
            return new JsonResult(item);
        }

        [HttpPut("{id}/details/update")]
        public IActionResult Update(string id, string address, string description, string price)
        {
            Console.WriteLine("id: " + id + " address " + address );

            var listing = new Listing {
                Id = Convert.ToInt32(id),
                Address = address,
                Description = description,
                Price = Convert.ToInt32(price),
            };

            _listingService.Update(listing);

            return new JsonResult(listing);
        }

        [HttpGetAttribute("{id}/details")]
        public IActionResult Details(string id)
        {
            var item = _listingService.Find(id);
            Console.WriteLine("value of item: " + item);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
    }
}
