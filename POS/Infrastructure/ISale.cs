using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Models;
using POS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace POS.Infrastructure
{
    public  interface ISale
    {
        Sale GetById(int Id);
        IEnumerable<Sale> GetAll();
        void Insert(Sale  sale);
        void Update(Sale sale);
        void Delete(Sale sale);
        IEnumerable<SelectListItem> GetAllProduct();
        IQueryable<SaleVM> GetVm();
        void Save();
      
    }
}
