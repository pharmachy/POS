using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class ProductDetail
    {
       
        public int Id { get; set; }
        //Product     
        public int MyProperty { get; set; }
        List<Customer> Customers = new List<Customer>();
    }
}
