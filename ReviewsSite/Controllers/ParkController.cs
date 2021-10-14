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
        public IActionResult Index()
        {
            if (TempData["Result"] != null)
            {
                ViewBag.Result = TempData["Result"].ToString();
            }      
            return View(_parkRepo.GetAll());
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


