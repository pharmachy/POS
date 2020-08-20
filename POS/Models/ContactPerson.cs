using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class ContactPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CustomerId { get; set; }
        public int? SupplierAId { get; set; }
        public SupplierA SupplierA { get; set; }
    }
}
