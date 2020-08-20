using Microsoft.AspNetCore.Http;
using POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public class ProductDetailVM
    {
       public Purchase Purchase { get; set; }
       public Product Product { get; set; }
       //public Supplier Supplier { get; set; }


    }
}
