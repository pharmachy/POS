using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Infrastructure;
using POS.Models;

namespace POS.Repository
{
    public class SubCategoryRepo : ISubCategory
    {
        POSDbContext db ;
        public SubCategoryRepo(POSDbContext db)
        {
            this.db = db;

        }
        public void Delete(SubCategory data)
        {
            db.SubCategories.Remove(data);
            db.SaveChanges();
        }

        public List<SubCategory> GetAll()
        {
            return db.SubCategories.ToList();
        }

        public List<SubCategory> GetAllInCluded()
        {
           return db.SubCategories.Include(t => t.Category).ToList();
        }

        public SubCategory GetById(int id)
        {
            return db.SubCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(SubCategory data)
        {
            db.SubCategories.Add(data);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(SubCategory data)
        {
            db.SubCategories.Update(data);
            db.SaveChanges();
        }
    }
}
