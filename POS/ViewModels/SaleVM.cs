using POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.ViewModels
{
    public class SaleVM
    {
        public int Id { get; set; }
        //[Display(Name = "Product Name")]
        //[ForeignKey("Product")]
        public int ProductId { get; set; }
        //public Product Product  { get; set; }
        // public List<Product> Products { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public DateTime Sales_Date { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Sales Price")]
        public decimal Sales_price { get; set; }
        public decimal Discount { get; set; }
        [Display(Name = "Price")]
        public decimal DicountPrice { get; set; }
        //public SaleVM()
        //{
        //    Products = new List<Product>();
        //}
    }
}
