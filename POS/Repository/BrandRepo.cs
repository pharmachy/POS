using POS.Data;
using POS.Infrastructure;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class BrandRepo : IBrand
    {
        POSDbContext db;
        public BrandRepo(POSDbContext db)
        {
            this.db = db;
        }
        public void Delete(Brand data)
        {
            db.Brands.Remove(data);
            db.SaveChanges();
        }

        public List<Brand> GetAll()
        {
            return db.Brands.ToList();
        }

        public List<Brand> GetAllInCluded()
        {
            throw new NotImplementedException();

        }

        public Brand GetById(int id)
        {
            return db.Brands.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Brand data)
        {
            db.Brands.Add(data);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Brand data)
        {
            db.Brands.Update(data);
            db.SaveChanges();
        }
    }
}
