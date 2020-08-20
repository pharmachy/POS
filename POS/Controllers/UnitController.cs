using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Infrastructure;
using POS.Models;
using POS.ViewModels;

namespace POS.Controllers
{
    public class UnitController : Controller
    {

        private readonly POSDbContext _db;
      private readonly  IUnit _context;
        public UnitController(IUnit context, POSDbContext db)
        {
            _context = context;
            _db = db;
        }
        public IActionResult Index()
        {
          var model = _db.Units.ToList();
          return View(model);           
        }
        public IActionResult Create()
        {
            ViewBag.Unit = _db.Units.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                _db.Add(unit);
                _db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(unit);
            }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _context.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            if (ModelState.IsValid)
            {
                _context.Update(unit);
                _context.Save();
                return RedirectToAction("Create");
            }
            return View(unit);
        }       
        public JsonResult DeleteUnit(int Id)
        {
            Unit unit = _db.Units.Where(x => x.Id == Id).FirstOrDefault<Unit>();
            _db.Units.Remove(unit);
            _db.SaveChanges();
            return Json(unit);
        }

    }
}