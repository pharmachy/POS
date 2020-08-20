using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Infrastructure;
using POS.Models;

namespace POS.Controllers
{
    public class SupController : Controller
    {
        private readonly ISupplier _supplier;

        public SupController(ISupplier supplier)
        {
            _supplier = supplier;
        }

        public IActionResult Index()
        {
            var sup = _supplier.GetSupplier().ToList();
            return View(sup);
        }
        [HttpGet]
        public IActionResult Create()
        {


            var r = _supplier.GetSupplier().Select(x => x.Id).LastOrDefault() + 1;
            ViewBag.Code = "SP00-" + r;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            _supplier.Insert(supplier);
            _supplier.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var sup = _supplier.GetSupplierById(Id);
            return View(sup);
        }
        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            _supplier.Update(supplier);
            _supplier.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var s = _supplier.GetSupplierById(Id);
            return View(s);
        }
        [HttpPost]
        public IActionResult Delete(Supplier supplier)
        {
            _supplier.Delete(supplier);
            _supplier.Save();
            return RedirectToAction("Index");
        }
    }
}