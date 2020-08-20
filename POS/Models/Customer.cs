using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Customer
    {
       
        public int Id { get; set; }
        [DisplayName("Customer ID:")]
   
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }

        public int LoyalityPoint { get; set; }

      
    }
}
