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

namespace POS.Controllers
{
    public class SalesController : Controller
    {
        private readonly POSDbContext _context;
        private readonly ISale _sale;
        public SalesController(POSDbContext context, ISale sale)
        {
            _context = context;
            _sale = sale;
        }

        // GET: Sales
        public IActionResult Index()
        {
           var sale = _sale.GetVm().ToList();

           return View(sale);
           // var pOSDbContext = _context.Sales.Include(s => s.Product);
            //return View( pOSDbContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now.ToString("MM/dd/yyyy");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");
            return View();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", sale.ProductId);
            return View(sale);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", sale.ProductId);
            return View(sale);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!SaleExists(sale.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", sale.ProductId);
            return View(sale);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool SaleExists(int id)
        //{
        //    return _context.Sales.Any(e => e.Id == id);
        //}
    }
}
