using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Models;

namespace POS.Controllers
{
    public class PacksController : Controller
    {
        private readonly POSDbContext _context;

        public PacksController(POSDbContext context)
        {
            _context = context;
        }

        public JsonResult DeletePack(int PackId)
        {

           
            Pack pack = _context.Pack.Where(x => x.PackId == PackId).FirstOrDefault<Pack>();
            _context.Pack.Remove(pack);
            _context.SaveChanges();
            return Json(pack);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pack.ToListAsync());
        }

          public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pack = await _context.Pack
                .FirstOrDefaultAsync(m => m.PackId == id);
            if (pack == null)
            {
                return NotFound();
            }

            return View(pack);
        }

        public IActionResult Create()
        {
            ViewBag.Packs =  _context.Pack.ToList();
            return View();
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackId,PackSizeName,PackQty,Remarks")] Pack pack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(pack);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pack = await _context.Pack.FindAsync(id);
            if (pack == null)
            {
                return NotFound();
            }
            return View(pack);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackId,PackSizeName,PackQty,Remarks")] Pack pack)
        {
            if (id != pack.PackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackExists(pack.PackId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Create));
            }
            return View(pack);
        }

         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pack = await _context.Pack
                .FirstOrDefaultAsync(m => m.PackId == id);
            if (pack == null)
            {
                return NotFound();
            }

            return View(pack);
        }

        // POST: Packs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pack = await _context.Pack.FindAsync(id);
        //    _context.Pack.Remove(pack);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        //public JsonResult DeleteEmployee(int PackId)
        //{

        //    Pack pack =  _context.Pack.Find(PackId);
        //    if (pack != null)
        //    {
        //        _context.Pack.Remove(pack);
        //        _context.SaveChanges();
              
        //    }

        //    return Json(pack);
        //}
        private bool PackExists(int id)
        {
            return _context.Pack.Any(e => e.PackId == id);
        }
    }
}
