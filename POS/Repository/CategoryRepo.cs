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
    public class CategoryRepo : ICategory
    {
        POSDbContext db;
        public CategoryRepo(POSDbContext db)
        {
            this.db = db;
       
        }
        public void Delete(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public IEnumerable<SelectListItem> GetAllCategory()
        {
            return GetAll().Select(cat => new SelectListItem()
            {
                Text = cat.Name,
                Value = cat.Id.ToString()
            }); ;
        }

        public Category GetById(int id)
        {
            return db.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
        }
    }
}
