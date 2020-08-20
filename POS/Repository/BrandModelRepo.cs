using Microsoft.EntityFrameworkCore;
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
    public class BrandModelRepo : IBrandModel
    {
        POSDbContext db;
        public BrandModelRepo(POSDbContext db)
        {
            this.db = db;
        }
        public void Delete(BrandModel data)
        {
            db.BrandModels.Remove(data);
            db.SaveChanges();
        }

        public IEnumerable<BrandModel> GetAll()
        {
            return db.BrandModels.ToList();
        }

        public List<BrandModel> GetAllInCluded()
        {

            return db.BrandModels.Include(t => t.Brand).ToList();
        }

        public BrandModel GetById(int Id)
        {
            return db.BrandModels.FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<BrandModelVM> GetVm()
        {
            throw new NotImplementedException();
        }

        public void Insert(BrandModel data)
        {
            db.BrandModels.Add(data);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(BrandModel data)
        {
            db.BrandModels.Update(data);
            db.SaveChanges();
        }
    }
}
