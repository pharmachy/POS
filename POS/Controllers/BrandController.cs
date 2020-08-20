using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Infrastructure;
using POS.Models;
using POS.ViewModels;

namespace POS.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrand repo;
        private readonly ICompany _com;
        public BrandController(IBrand repo, ICompany _com) { this.repo = repo;this._com = _com; }
        public IActionResult Index()
        {
            var data = repo.GetAll().OrderBy(x => x.Id);

            return View(data);
        }
        public IActionResult Create()
        {
            
            //var r = repo.GetAll();
            //if () {


            //    var s = 0;
            //    ViewBag.BrandId = "B00-" + s;
            //    ViewBag.Brands = repo.GetAll();
            //    ViewBag.Date = DateTime.Now.ToString("MM/dd/yyyy");
            //    return View();
            //}
            //else
            //{
                var s = repo.GetAll().Select(x => x.Id).LastOrDefault() + 1;
                ViewBag.BrandId = "B00-" + s;

                //ViewBag.Brands = repo.GetAll();
                ViewBag.Date = DateTime.Now.ToString("MM/dd/yyyy");
            ViewBag.TestParentId = new SelectList(_com.GetAll(), "Id", "Company_Name");
            ViewBag.BrandsD = (from t1 in repo.GetAll()
                                    join t2 in _com.GetAll() on t1.CompanyId equals t2.Id into eGroup
                                    
                                    from t2 in eGroup.DefaultIfEmpty()
                                    select new BrandAndCompany
                                    {
                                        Id=t1.Id,
                                        BrandName=t1.BrandName,
                                    BrandCode=t1.BrandCode,
                                    CreateDate=t1.CreateDate,
                                    CreateId=t1.CreateId,
                                    Remarks=t1.Remarks,
                                    CompanyId=t2.Id,
                                    CompanyName=t2.Company_Name
                                    
                                    }).ToList();
            return View();

            ////}
          
        }
        [HttpPost]
        public IActionResult Create(Brand data)
        {
            if (ModelState.IsValid)
            {
                data.CreateDate = DateTime.Now;
                repo.Insert(data);
                return RedirectToAction("Create");
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
        public IActionResult Edit(Brand data)
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
        public IActionResult Delete(Brand data)
        {
            repo.Delete(data);
            return RedirectToAction("Create");

        }
    }
}