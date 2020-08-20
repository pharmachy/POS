using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Infrastructure;
using POS.Models;

namespace POS.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer repo;
        public CustomerController(ICustomer repo) { this.repo = repo; }
        public IActionResult Index()
        {
            var data = repo.GetAll().OrderBy(x => x.Id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var r = repo.GetAll().Select(x => x.Id).LastOrDefault() + 1;
            ViewBag.Code = "C00-" + r;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer data)
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
        public IActionResult Edit(Customer data)
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
        public  IActionResult Delete(Customer data)
        {
            repo.Delete(data);
            return RedirectToAction("Index");

        }
    }
}