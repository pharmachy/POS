using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Supplier
    {
        public int Id { set; get; }
        [Display(Name="SL")]
        public string Code { set; get; }
        public string Name { set; get; }
        [Display(Name = "Address Line1")]
        public string Address { set; get; }
        [Display(Name = "Address Line2")]
        public string Address2 { set; get; }
        public string Contact { set; get; }
        public string Email { set; get; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { set; get; }
        public string Phone { get; set; }
        [Display(Name ="Email")]
        public string CEmail { get; set; }
        [Display(Name = "Address Line1")]
        public string CAddress { get; set; }

    }
   
    public class SupplierA
    {
        public int Id { set; get; }

        public string Code { set; get; }

        public string Name { set; get; }

        public string Address { set; get; }

        public string Contact { set; get; }

        public string Email { set; get; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { set; get; }
    }
}
