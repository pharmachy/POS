using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using POS.Data;
using POS.Infrastructure;
using POS.Models;

namespace POS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHostingEnvironment _hm;
        private readonly POSDbContext _context;
        private readonly IProduct _product;
        private readonly ISubCategory _subcategory;
        private readonly ICompany _company;
        private readonly IBrandModel _brandmodel;
        private readonly IUnit _unit;

        public ProductsController(POSDbContext context, IProduct product, ISubCategory subcategory, ICompany company, IUnit unit, IBrandModel brandmodel, IHostingEnvironment hm)
        {
            _context = context;
            _product = product;
            _subcategory = subcategory;
            _brandmodel = brandmodel;
            _company = company;
            _unit = unit;
            _hm = hm;
        }

        //For GET: Products
        public async Task<IActionResult> Index()
        {
            var products = _context.Products
                .Include(c => c.SubCategory)
                .Include(c => c.Company)
                .Include(c => c.BrandModel)
                .Include(c => c.Unit);
            return View(await products.ToListAsync());
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products
                .Include(p => p.SubCategory)
                .Include(p => p.Company)
                .Include(c => c.BrandModel)
                .Include(c => c.Unit)
                .FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        //public JsonResult GetCatList(int CategoryId)//-------------------------------------------------------------------------
        public IActionResult GetCatList(int CategoryId)//-------------------------------------------------------------------------
        {
            //dbContext.Configuration.ProxyCreationEnabled = false;
           
                var ItemList = _context.SubCategories.Where(x => x.CategoryId == CategoryId).ToList();
                // return Json(new SelectList(ItemList, "Id", "Name"/*, JsonRequestBehavior.AllowGet*/));
                //return Json(ItemList);
                var list = JsonConvert.SerializeObject(ItemList,
            Formatting.None,
                  new JsonSerializerSettings()
                  {
                      ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                  });

                return Content(list, "application/json");
  
        }
        [HttpPost]
        //public JsonResult GetCatList(int CategoryId)//-------------------------------------------------------------------------
        public IActionResult GetBrandList(int CompanyId)//-------------------------------------------------------------------------
        {
            //dbContext.Configuration.ProxyCreationEnabled = false;

            var ItemList = _context.Brands.Where(x => x.CompanyId == CompanyId).ToList();
           
            var list = JsonConvert.SerializeObject(ItemList,
        Formatting.None,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

            return Content(list, "application/json");

        }
        public IActionResult GetModelList(int BrandId)//-------------------------------------------------------------------------
        {
            //dbContext.Configuration.ProxyCreationEnabled = false;

            var ModelList = _context.BrandModels.Where(x => x.BrandId == BrandId).ToList();
            // return Json(new SelectList(ItemList, "Id", "Name"/*, JsonRequestBehavior.AllowGet*/));
            //return Json(ItemList);
            var listModel = JsonConvert.SerializeObject(ModelList,
        Formatting.None,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

            return Content(listModel, "application/json");

        }
        // GET Products for Create...
        public IActionResult Create()
        {

            // ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["CategoryId"] = _context.Categories.ToList();
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Company_Name");
           
            ViewData["BrandIdd"] = _context.Brands.ToList();
            ViewData["BrandModelId"] = new SelectList(_context.BrandModels, "Id", "Name");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
            return View();
        }

        // POST Products for Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile FF)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (FF != null)
            {
                var name = Path.Combine(_hm.WebRootPath + "/images", Path.GetFileName(FF.FileName));
                await FF.CopyToAsync(new FileStream(name, FileMode.Create));
                product.ProductImage = "images/" + FF.FileName;
            }
            if (FF == null)
            {
                product.ProductImage = "images/noimage.jpg";
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Company_Name", product.CompanyId);
            ViewData["BrandModelId"] = new SelectList(_context.BrandModels, "Id", "Name", product.BrandModelId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", product.UnitId);
            return View(product);
        }

        // GET Data for Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Company_Name", product.CompanyId);
            ViewData["BrandModelId"] = new SelectList(_context.BrandModels, "Id", "Name", product.BrandModelId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", product.UnitId);
            return View(product);
        }

        // POST Edit data 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Name", product.SubCategoryId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Company_Name", product.CompanyId);
            ViewData["BrandModelId"] = new SelectList(_context.BrandModels, "Id", "Name", product.BrandModelId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", product.UnitId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.SubCategory)
                .Include(p => p.Company)
                .Include(p => p.BrandModel)
                .Include(p => p.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
