using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Models;
using POS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure
{
   public interface IPurchase
    {
        List<Purchase> GetAllInCluded();
        //IEnumerable<SelectListItem> GetAllProduct();
        //IQueryable<PurchaseVm> GetVm();
        List<Purchase> GetAll();
        IQueryable<PurchaseVM> GetVm();
        Purchase GetById(int id);
        void Insert(Purchase data);
        void Update(Purchase data);
        void Delete(Purchase data);
        void Save();
    }
}
