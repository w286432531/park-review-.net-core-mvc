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
            {   //add message when a park is created
                ViewBag.Result = TempData["Result"].ToString();
            }
            //get all parks from database
            var parks = _parkRepo.GetAll();
            //check if searchString is empty
            //run this code when search string is not empty
            if (!String.IsNullOrEmpty(searchString))
            {   
                ViewBag.SearchString = searchString;
                //search through all parks where park name to lowercase contains search string to lowercase
                parks = parks.Where(park => (park.Name.ToLower()).Contains(searchString.ToLower()));
            }
            // save data to use it next time
            ViewBag.isDogFriendly = isDogFriendly;
            // if isDogFriendly checkbox is checked
            if (isDogFriendly)
            {   //list of parks = all parks where IsDogFriendly is true
                parks = parks.Where(park => park.IsDogFriendly);
            }
            // save data to use it next time
            ViewBag.hasHandicapAccess = hasHandicapAccess;
            // if hasHandicapAccess checkbox is checked
            if (hasHandicapAccess)
            {   //list of parks = all parks where HasHandicapAccess is true
                parks = parks.Where(park => park.HasHandicapAccess);
            }
            // set sortOrder base on what's being pass in from park index
            // When park number is clicked
            // if sortOrder is empty. sort order = id_desc else it's empty which is default in switch statement
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder)? "id_desc" : "";
            // When park name is clicked 
            // if sortOrder is name. sort order = name_desc else sort order is name
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            // if sortOrder is rating. sort order = rating_desc else it's rating.
            ViewBag.RatingSortParm = sortOrder == "rating" ? "rating_desc" : "rating";
            // sort list of parks base on the sort order
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


