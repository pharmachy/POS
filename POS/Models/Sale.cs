using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Sale
    {
        public int Id { get; set; }
        //Items/Products name
        [Display(Name ="Product Name")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
       // public virtual List<Product>Products { get; set; }
        public DateTime Sales_Date { get; set; }
        public int Quantity { get; set; }       
        public decimal Sales_price { get; set; }
        public decimal Discount { get; set; }
        //public Sale()
        //{
        //    Products = new List<Product>();
        //}

    }
}
