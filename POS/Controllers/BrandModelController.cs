using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Infrastructure;
using POS.Models;

namespace POS.Controllers
{
    public class BrandModelController : Controller
    {
        //private readonly POSDbContext db;
        private readonly IBrandModel repo;
        private readonly IBrand _brand;
        public BrandModelController(IBrandModel repo, IBrand _brand/*, POSDbContext db*/)
        {
            this.repo = repo;
            this._brand = _brand;
            //this.db=db;
        }
        public IActionResult Index()
        {

            var data = repo.GetAllInCluded().OrderBy(x => x.Id);

            return View(data);
        }
        public IActionResult Create()
        {
            // ViewData["TestParentId"] = new SelectList(_cat.GetAllCategory(), "Id", "Name");
            //ViewBag.TestParentId = new SelectList(repo.GetAllInCluded(), "CategoryId", "Name");
            ViewBag.Date = DateTime.Now.ToString("MM/dd/yyyy");
            ViewBag.TestParentId = new SelectList(_brand.GetAll(), "Id", "BrandName");
            ViewBag.BrandModel = repo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(BrandModel data)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.Now;
                data.CreateDate = date;
                repo.Insert(data);
                return RedirectToAction("Create");
            }



            ViewData["TestParentId"] = new SelectList(repo.GetAllInCluded(), "BrandId", "BrandId", data.BrandId);
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
        public IActionResult Edit(BrandModel data)
        {
            if (ModelState.IsValid)
            {
                repo.Update(data);
                return RedirectToAction("Create");
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
        public IActionResult Delete(BrandModel data)
        {
            repo.Delete(data);

            return RedirectToAction("Create");

        }
    }
}