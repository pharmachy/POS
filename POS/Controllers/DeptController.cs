using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Data;
using POS.Models;
using POS.Repository;

namespace POS.Controllers
{
    public class DeptController : Controller
    {

        private readonly IDepartmentRepo _dept;
        private readonly POSDbContext _db;
      
        public DeptController(IDepartmentRepo dept,POSDbContext _db)
        {
            this._dept = dept;
            this._db = _db;
        }
        public JsonResult DeleteDepartment(int Id)
        {
            Department dept = _db.Departments.Where(x => x.Id == Id).FirstOrDefault<Department>();
            _db.Departments.Remove(dept);
            _db.SaveChanges();
            return Json(dept);
        }
        public IActionResult Index()
        {
            var dprt = _dept.GetAll().ToList();
            return View(dprt);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            _dept.Insert(department);
            _dept.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var dpt = _dept.GetById(Id);
            return View(dpt);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            _dept.Update(department);
            _dept.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var dpt = _dept.GetById(Id);
            return View(dpt);
        }
        [HttpPost]
        public IActionResult Delete(Department department)
        {
            _dept.Delete(department);
            _dept.Save();
            return RedirectToAction("Index");
        }
    }
}
