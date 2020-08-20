using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using POS.Data;
using POS.Models;
using POS.ViewModels;

namespace POS.Controllers
{
    public class TestChildsController : Controller
    {
        private readonly POSDbContext _context;

        public TestChildsController(POSDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pOSDbContext = _context.TestChilds.Include(t => t.TestParent);
            return View(await pOSDbContext.ToListAsync());
        }
        [HttpGet]
        public IActionResult CreateA()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateA(SupplierA supplier)
        {
            _context.SupplierA.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddBar()
        {
            var pOSDbContext = _context.TestChilds.Include(t => t.TestParent);
            return View(await pOSDbContext.ToListAsync());
        }
        public IActionResult InsertSkills(TestChildVM2 skills)
        {
            return Json(skills);
        }
        //public JsonResult InsertSkills(List<TestChildVM2> skills)
        //{



        //   // var insertedRecords = skills.Count();

        //    //Loop and insert records.
        //    //foreach (TestChild s in skills.TestChilds)
        //    //{
        //    //    _context.TestChilds.Add(s);
        //    //}
        //    //int insertedRecords = _context.SaveChanges();
        //    return Json(skills);
        //}


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testChild = await _context.TestChilds
                           .Include(t => t.TestParent)
                             .FirstOrDefaultAsync(m => m.TestChildId == id);
            if (testChild == null)
            {
                return NotFound();
            }

            return View(testChild);
        }
        public IActionResult MultiCreate()
        {
            ViewData["TestParentId"] = new SelectList(_context.TestParent, "TestParentId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MultiCreate(GeneralVM model)
        {

            string name = Request.Form["ItemList"];
            var data = JsonConvert.DeserializeObject<List<GeneralPO>>(name);
            if (model.TestParentName != null)
            {
                TestChild tc = new TestChild();
                tc.TestChildId = model.TestChildId;
                tc.Name = model.Name;
                tc.Age = model.Age;
                tc.TestParentId = model.TestParentId;
                _context.TestChilds.Add(tc);
                _context.SaveChanges();
                TestParent tp = new TestParent();
                tp.TestParentId = 0; /*_context.TestParent.ToList().Select(x => x.TestParentId).Last() + 1;*/
                tp.Name = model.TestParentName;
                _context.TestParent.Add(tp);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

           else if (ModelState.IsValid)
            {
                
             

                TestChild tc = new TestChild();
                tc.TestChildId = model.TestChildId;
                tc.Name = model.Name;
                tc.Age = model.Age;
                tc.TestParentId = model.TestParentId;
                _context.TestChilds.Add(tc);
               // _context.SaveChanges();



                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TestParentId"] = new SelectList(_context.TestParent, "TestParentId", "TestParentId", model.TestParentId);
            return View(model);
        }



        public IActionResult Create()
        {
            ViewData["TestParentId"] = new SelectList(_context.TestParent, "TestParentId", "Name");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestChild testChild)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testChild);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TestParentId"] = new SelectList(_context.TestParent, "TestParentId", "TestParentId", testChild.TestParentId);
            return View(testChild);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testChild = await _context.TestChilds.FindAsync(id);
            if (testChild == null)
            {
                return NotFound();
            }
            ViewData["TestParentId"] = new SelectList(_context.TestParent, "TestParentId", "Name", testChild.TestParentId);
            return View(testChild);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestChildId,Name,Age,TestParentId")] TestChild testChild)
        {
            if (id != testChild.TestChildId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testChild);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestChildExists(testChild.TestChildId))
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
            ViewData["TestParentId"] = new SelectList(_context.TestParent, "TestParentId", "TestParentId", testChild.TestParentId);
            return View(testChild);
        }

      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testChild = await _context.TestChilds
                                  .Include(t => t.TestParent)
                                  .FirstOrDefaultAsync(m => m.TestChildId == id);
            if (testChild == null)
            {
                return NotFound();
            }

            return View(testChild);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testChild = await _context.TestChilds.FindAsync(id);


                _context.TestChilds.Remove(testChild);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestChildExists(int id)
        {
            return _context.TestChilds.Any(e => e.TestChildId == id);
        }
    }
}
