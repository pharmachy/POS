using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure
{
     public   interface ICategory
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(Category category);
        void Save();
        IEnumerable<SelectListItem> GetAllCategory();
    }
}
