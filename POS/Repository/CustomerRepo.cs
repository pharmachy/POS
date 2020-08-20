using POS.Data;
using POS.Infrastructure;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class CustomerRepo : ICustomer
    {
        POSDbContext db ;
        public CustomerRepo(POSDbContext db)
        {
            this.db = db;

        }
        public void Delete(Customer customer)
        {
            db.Remove(customer);
            db.SaveChanges();
        }

        public List<Customer> GetAll()
        {
          return  db.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return db.Customers.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            db.Customers.Update(customer);
            db.SaveChanges();
        }
    }
}
