using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Data;
using POS.Infrastructure;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Repository
{

    public class UnitService : IUnit
    {
      private readonly POSDbContext _context;
        public UnitService(POSDbContext context)
        {
            _context = context;
        }
        public void Delete(Unit unit)
        {
            _context.Remove(unit);
        }

        public IEnumerable<Unit> GetAll()
        {
            //return _context.Sales.ToList();
            return _context.Units.ToList();
        }

        public IEnumerable<SelectListItem> GetAllUnit()
        {
            return GetAll().Select(pro => new SelectListItem()
            {
                Text = pro.Name,
                Value = pro.Name.ToString()
            });
        }

        public Unit GetById(int Id)
        {
            return _context.Units.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(Unit unit)
        {
            _context.Add(unit);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Unit unit)
        {
            _context.Update(unit);
        }
    }
}
