using POS.Data;
using POS.Infrastructure;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace POS.Repository
{
    public class SupplierRepo : ISupplier
    {
        private POSDbContext _context;

        public SupplierRepo(POSDbContext context)
        {
            _context = context;
        }
        public void Delete(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
        }       

        public IEnumerable<Supplier> GetSupplier()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier GetSupplierById(int Id)
        {
            return _context.Suppliers.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
        }
    }
}
