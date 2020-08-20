using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Data;
using POS.Infrastructure;
using POS.Models;

namespace POS.Controllers
{
    public class CategoryController : Controller
    {
        //private readonly POSDbContext _db;

        private readonly ICategory repo;
        public CategoryController(ICategory repo) { this.repo = repo; }
        
        public IActionResult Index()
        {
            var data = repo.GetAll().OrderBy(x => x.Id);

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var r = repo.GetAll().Select(x => x.Id).LastOrDefault() +1;
           
            ViewBag.Code= "CT00-" + r;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category data)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(data);
                return RedirectToAction("Index");
            }
        
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = repo.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
           
        
        [HttpPost]
        public IActionResult Edit(Category data)
        {
            if (ModelState.IsValid)
            {
                repo.Update(data);
                return RedirectToAction("Index");
            }
            
            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = repo.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult  Delete(Category data)
        {
            repo.Delete(data);

            return RedirectToAction("Index");
            
        }
    }
    
}