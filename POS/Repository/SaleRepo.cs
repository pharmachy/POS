using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Data;
using POS.Infrastructure;
using POS.Models;
using POS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class SaleRepo : ISale
    {
      private  POSDbContext _context;
        
        public SaleRepo(POSDbContext context)
        {
           this. _context = context;
          
        }
        public void Delete(Sale sale)
        {
            _context.Remove(sale);
        }

        public IQueryable<SaleVM> GetVm()
        {
            return _context.Sales.Select(x => new SaleVM
            {
               Id = x.Id,
               ProductId=x.ProductId,
               ProductName=x.Product.ProductName,
                Sales_Date = x.Sales_Date,
                Quantity = x.Quantity,
                Sales_price = x.Sales_price,
                Discount = x.Discount,
                DicountPrice=x.Sales_price* x.Quantity * (1-x.Discount/100)

            }).AsQueryable();
        }
         

    public Sale GetById(int Id)
        {
            return _context.Sales.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(Sale sale)
        {
            _context.Sales.Add(sale);
        }

        public void Update(Sale sale)
        {
            _context.Sales.Update(sale);
        }

        public IEnumerable<SelectListItem> GetAllProduct()
        {
            var allproductName = _context.Products.Select(p => new SelectListItem
            {
                Text = p.ProductName,
                Value = p.ProductName.ToString()
            });
            return allproductName;
        }

        public IEnumerable<Sale> GetAll()
        {
            return _context.Sales.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
