using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Data;
using POS.Infrastructure;
using POS.Models;

namespace POS.Controllers
{
    public class SubCategoryController : Controller
    {
         //private readonly POSDbContext db;
         private readonly ISubCategory repo;
         private readonly ICategory cat;
        public SubCategoryController(ISubCategory repo, ICategory cat/*, POSDbContext db*/)
        { this.repo = repo;
             this.cat=cat;
             //this.db=db;
        }
        public IActionResult Index()
        {

            var data = repo.GetAllInCluded().OrderBy(x => x.Id);

            return View(data);
        }
        public IActionResult Create()
        {


            var r = repo.GetAll().Select(x => x.Id).LastOrDefault() + 1;
            ViewBag.Code = "SC00-" + r;
            // ViewData["TestParentId"] = new SelectList(_cat.GetAllCategory(), "Id", "Name");
            //ViewBag.TestParentId = new SelectList(repo.GetAllInCluded(), "CategoryId", "Name");
            ViewBag.TestParentId = new SelectList(cat.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(SubCategory data)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(data);
                return RedirectToAction("Index");
            }

          

            ViewData["TestParentId"] = new SelectList(repo.GetAllInCluded(), "CategoryId", "CategoryId", data.CategoryId);
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
        public IActionResult Edit(SubCategory data)
        {
            if (ModelState.IsValid)
            {
                repo.Update(data);
                return RedirectToAction("Index");
            }

            return View(data);
        }
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
        public IActionResult Delete(SubCategory data)
        {
            repo.Delete(data);

            return RedirectToAction("Index");

        }
    }
}