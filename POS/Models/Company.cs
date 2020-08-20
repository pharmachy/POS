using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Company_Name { get; set; }
       public string Phone { get; set; }
       public string Email { get; set; }
       public string Website { get; set; }
       public string Address { get; set; }
        //public ICollection<TestChild> TestChilds { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}