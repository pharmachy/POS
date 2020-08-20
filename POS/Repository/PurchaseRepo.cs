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
    public class PurchaseRepo : IPurchase
    {
        POSDbContext db ;
        public PurchaseRepo(POSDbContext db)
        {
            this.db = db;

        }
        public void Delete(Purchase data)
        {
            db.Purchases.Remove(data);
            db.SaveChanges();
        }

        public List<Purchase> GetAll()
        {
            return db.Purchases.ToList();
        }

        public List<Purchase> GetAllInCluded()
        {
            return db.Purchases.Include(d => d.Product).ToList();
        }

        public Purchase GetById(int id)
        {
            return db.Purchases.FirstOrDefault(x => x.PurchaseId == id);
        }

        public IQueryable<PurchaseVM> GetVm()
        {
            throw new NotImplementedException();
            //var result = (from p in db.Purchases
            //              join pr in db.Products on p.ProductId equals pr.Id

            //              where p.ProductId == pr.Id
            //              select new ProductDetailVM
            //              {
            //                  Purchase = p,
            //                  Product = pr

            //              }).AsQueryable();
            //return result;
        }

        public void Insert(Purchase data)
        {
            db.Purchases.Add(data);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Purchase data)
        {
            db.Purchases.Update(data);
            db.SaveChanges();
        }
    }
}
