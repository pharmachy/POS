using POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public class PurchaseVM
    {

        //public int PurchaseId { get; set; }
        ////public PurchaseDetails PurchaseDetails { get; set; }
        //public int Quantity { get; set; }
        //public double UnitPrice { get; set; }
        //public decimal Discount { get; set; }
        //public decimal TotalPrice { get; set; }
        //public DateTime PurchaseDate { get; set; }
        //public int ProductId { get; set; }
        //public Product Product { get; set; }
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
        public BrandModel BrandModel { get; set; }
        public Brand Brand { get; set; }
        public SubCategory SubCategory { get; set; }
        [DisplayName("Manufacturer")]
        public Company Company { get; set; }
        //public Supplier Supplier { get; set; }


    }
}
