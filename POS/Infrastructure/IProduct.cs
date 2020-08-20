using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Models;
using System.Collections.Generic;

namespace POS.Infrastructure
{
    public  interface IProduct
    {

        Product GetById(int Id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Save();       
        IEnumerable<Product> GetAll();
        IEnumerable<SelectListItem> GetAllProduct();
    }
}
