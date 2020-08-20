using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Infrastructure
{
   
    public  interface ICustomer
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);

        void Save();
    }
}
