using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure
{
  public  interface ISupplier
    {
        IEnumerable<Supplier> GetSupplier();
        Supplier GetSupplierById(int Id);
        void Insert(Supplier supplier);        
        void Update(Supplier supplier);
        void Delete(Supplier supplier);
        void Save();
        
    }
}
