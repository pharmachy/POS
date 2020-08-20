using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Infrastructure;
using POS.Models;

namespace POS.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompany _company;
        public CompanyController(ICompany company)
        {
            this._company = company;
        }
        public IActionResult Index()
        {
            var com = _company.GetAll().ToList();
            return View(com);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company company)
        {
            _company.Insert(company);
            _company.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var com = _company.GetById(Id);
            return View(com);
        }
        [HttpPost]
        public IActionResult Edit(Company company)
        {
            _company.Update(company);
            _company.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var com = _company.GetById(Id);
            return View(com);
        }
        [HttpPost]
        public IActionResult Delete(Company company)
        {
            _company.Delete(company);
            _company.Save();
            return RedirectToAction("Index");
        }
    }
}