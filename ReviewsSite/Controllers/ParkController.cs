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
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
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
                return View(_parkRepo.GetByID(x));
            }
            
        }
        [HttpPost]
        public IActionResult Edit(Park park)
        {
            _parkRepo.Update(park);
            return RedirectToAction("Index");
        }
    }
}
