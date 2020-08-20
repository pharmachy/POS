using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Infrastructure;
using POS.Models;
using POS.ViewModels;

namespace POS.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly POSDbContext _context;
        private readonly IPurchase repo;
        private readonly IProduct _product;
        public PurchaseController(IPurchase repo, IProduct _product, POSDbContext context) 
        { this.repo = repo; 
        this._product = _product;
            _context = context;
        }
        public IActionResult Index()
        {
            var data = repo.GetAllInCluded().OrderBy(x => x.PurchaseId);

            return View(data);
        }
        public IActionResult Details(int id)
        {


            var data = _context.Purchases.Find(id);
            //var sale =  _context.Purchases
            //.Include(s => s.Product).Include(b=>b.Product.SubCategory).Include(sb=>sb.Product.BrandModel)
            //.FirstOrDefaultAsync(m => m.PurchaseId == id);
            ////if (data == null)
            //{
            //    return NotFound();
            //}
            var reuslt = (from p in _context.Purchases
                        join pr in _context.Products on p.ProductId equals pr.Id
                        join subCat in _context.SubCategories on pr.SubCategoryId equals subCat.Id
                        join bm in _context.BrandModels on pr.BrandModelId equals bm.Id
                        join b in _context.Brands on bm.BrandId equals b.Id
                        join c in _context.Companies on pr.CompanyId equals c.Id

                        where p.PurchaseId == data.PurchaseId && p.ProductId == pr.Id && bm.BrandId == b.Id
                        select new PurchaseVM
                        {
                            Purchase = p,
                            Product = pr,
                            SubCategory = subCat,
                            BrandModel = bm,
                            Brand = b,
                            Company = c

                        }).OrderBy(x => x.Purchase.PurchaseId == id).ToList();
            //ViewBag.TransactionList = data;
            return View(reuslt);
        }
        public IActionResult AllViewList()
        {
            var data = (from p in _context.Purchases
                          join pr in _context.Products on p.ProductId equals pr.Id
                          join subCat in _context.SubCategories on pr.SubCategoryId equals subCat.Id
                          join bm in _context.BrandModels on pr.BrandModelId equals bm.Id
                          join b in _context.Brands on bm.BrandId equals b.Id
                          join c in _context.Companies on pr.CompanyId equals c.Id

                          where p.ProductId == pr.Id && bm.BrandId==b.Id
                          select new PurchaseVM
                          {
                              Purchase = p,
                              Product = pr,
                              SubCategory=subCat,
                              BrandModel=bm,
                              Brand=b,
                              Company=c

                          }).OrderBy(x => x.Purchase.PurchaseId).ToList();
            ViewBag.TransactionList = data;

          

            return View(data);
        }
        public IActionResult Create(int POid)
        {
          
            var data = (from p in _context.PO
                        join pr in _context.OrderDetail on p.PurchaseOrderId equals pr.PurchaseOrderId
                       


                        where p.PurchaseOrderId == POid
                        select new OrderDetailVM2
                        {
                          OrderNo=p.PurchaseOrderNo,
                          SupplierId=p.SupplierId/*,*/
                          //ProductId=pr.ProductId,
                          //Quantity=pr.Quantity,
                          //Rate=pr.Rate,
                          //DiscountPer=pr.DiscountPer,
                          //TotalAmount=pr.TotalAmount
                          

        }).ToList();
            //ViewBag.TransactionList = data;
            //ViewData["ProductId"] = data.Find(x => x.SupplierId);
            //ViewBag.TestParentId = new SelectList(_product.GetAll(), "Id", "ProductName");
            ViewBag.Date = DateTime.Now.ToString("MM/dd/yyyy");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");
            ViewBag.SupplierId= new SelectList(_context.Suppliers, "Id", "Name");

            return View();
           
        }
        [HttpPost]
        public IActionResult Create(Purchase data)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(data);
                return RedirectToAction("AllViewList");
            }
            // ViewData["TestParentId"] = new SelectList(repo.GetAllInCluded(), "ProductId", "ProductId", data.ProductId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", data.ProductId);
             ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", data.SupplierId);

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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");

            return View(data);
        }


        [HttpPost]
        public IActionResult Edit(Purchase data)
        {
            if (ModelState.IsValid)
            {
                repo.Update(data);
                return RedirectToAction("AllViewList");
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", data.ProductId);

            return View(data);
        }
        public IActionResult Delete(int id)
        {
            var data = repo.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");

            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Purchase data)
        {
            repo.Delete(data);

            return RedirectToAction("AllViewList");


        }
    }
}