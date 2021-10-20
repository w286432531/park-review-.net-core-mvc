using Microsoft.AspNetCore.Mvc;
using ReviewsSite.Models;
using ReviewsSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Controllers
{
    public class ParkController : Controller
    {
        private IRepository<Park> _parkRepo;

        public ParkController(IRepository<Park> parkRepo)
        {
            this._parkRepo = parkRepo;
        }
        public IActionResult Index(string sortOrder, string searchString, bool isDogFriendly, bool hasHandicapAccess)
        {   //add result from create park 
            if (TempData["Result"] != null)
            {
                ViewBag.Result = TempData["Result"].ToString();
            }

            var parks = _parkRepo.GetAll();
            foreach (var park in parks)
            {
                park.GetAverage();
            }
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder)? "id_desc" : "";
            ViewBag.IdSortParm = sortOrder == "id" ? "id_desc" : "id";
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.RatingSortParm = sortOrder == "rating" ? "rating_desc" : "rating";
            switch (sortOrder)
            {
                case "id_desc":
                    parks = parks.OrderByDescending(park => park.Id);
                    break;
                case "name":
                    parks = parks.OrderBy(park => park.Name);
                    break;
                case "name_desc":
                    parks = parks.OrderByDescending(park => park.Name);
                    break;
                case "rating":
                    parks = parks.OrderBy(park => park.AverageRating);
                    break;
                case "rating_desc":
                    parks = parks.OrderByDescending(park => park.AverageRating);
                    break;
                default:
                    parks = parks.OrderBy(park => park.Id);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                parks = parks.Where(park => (park.Name.ToLower()).Contains(searchString.ToLower()));
            }
            if (isDogFriendly)
            {
                parks = parks.Where(park => park.IsDogFriendly);
            }
            if (hasHandicapAccess)
            {
                parks = parks.Where(park => park.HasHandicapAccess);
            }
            return View(parks);
        }

        public IActionResult Create()
        {
            return View(new Park());
        }
        [HttpPost]
        public IActionResult Create(Park newPark)
        {
            if (!String.IsNullOrEmpty(newPark.Name))
            {
                TempData["Result"] = "You've successfully added a new park!";
                _parkRepo.Create(newPark);
                return RedirectToAction("Index", "Park", newPark);
            }
            else
            {
                ViewBag.Error = "There is a error please try again.";
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Park park = _parkRepo.GetByID(id);

            return View(park);
        }
        [HttpPost]
        public IActionResult Delete(int id, Park park)
        {
            Park parkDel = _parkRepo.GetByID(park.Id);
            _parkRepo.Delete(parkDel);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            Park park = _parkRepo.GetByID(id);
            park.GetAverage();
            return View(park);
        }

        // get method for edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                int x = id.GetValueOrDefault();
                Park park = _parkRepo.GetByID(x);
                return View(park);
            }

        }
        [HttpPost]
        public IActionResult Edit(int id, Park park)
        {
            _parkRepo.Update(park);
            return RedirectToAction("Index");

        }




    }
}


