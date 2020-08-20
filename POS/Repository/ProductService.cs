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
    public class ProductService : IProduct
    {
        private POSDbContext _context;
        public ProductService(POSDbContext context)
        {
            this._context = context;
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int Id)
        {
            return _context.Products.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(Product product)
        {
            _context.Products.Add(product);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
        public IEnumerable<SelectListItem> GetAllProduct()
        {
            return GetAll().Select(pro => new SelectListItem()
            {
                Text = pro.ProductName,
                Value = pro.ProductName.ToString()
            });
        }
    }

      
    
}
