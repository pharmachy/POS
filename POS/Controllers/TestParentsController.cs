using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Models;
using POS.ViewModels;

namespace POS.Controllers
{
    public class TestParentsController : Controller
    {
        private readonly POSDbContext _context;

        public TestParentsController(POSDbContext context)
        {
            _context = context;
        }

        // GET: TestParents
        public IActionResult Index()
        {
            //List<TestParentVm> TestList = new List<TestParentVm>();
            //var query= _context.TestChilds
            //            .Include(s => s.TestParent)

            //            .FirstOrDefault();
            //var child = _context.TestParent.Include(x => x.TestChilds).AsQueryable();
            var result = _context.TestParent.ToList();
            return View(result);
        }

        // GET: TestParents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testParent = await _context.TestParent
                .FirstOrDefaultAsync(m => m.TestParentId == id);
            if (testParent == null)
            {
                return NotFound();
            }

            return View(testParent);
        }

        // GET: TestParents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestParents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestParentId,Name")] TestParent testParent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testParent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testParent);
        }

        // GET: TestParents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testParent = await _context.TestParent.FindAsync(id);
            if (testParent == null)
            {
                return NotFound();
            }
            return View(testParent);
        }

        // POST: TestParents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestParentId,Name")] TestParent testParent)
        {
            if (id != testParent.TestParentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testParent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestParentExists(testParent.TestParentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testParent);
        }

        // GET: TestParents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testParent = await _context.TestParent
                .FirstOrDefaultAsync(m => m.TestParentId == id);
            if (testParent == null)
            {
                return NotFound();
            }

            return View(testParent);
        }

        // POST: TestParents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testParent = await _context.TestParent.FindAsync(id);
            _context.TestParent.Remove(testParent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestParentExists(int id)
        {
            return _context.TestParent.Any(e => e.TestParentId == id);
        }
    }
}
