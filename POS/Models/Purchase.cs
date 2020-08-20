using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        //public PurchaseDetails PurchaseDetails { get; set; }
        [DisplayName("Quantity:")]
        [Required]
        public int Quantity { get; set; }
        [DisplayName("Unit Price:")]
        [Required]
        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; } 
       public Supplier Supplier { get; set; }
       
        public int PurchaseDetailsId{get;set;}

    }
    public class PurchaseDetails
    {
        [Key]
        public int PurchaseDetailsId { get; set; }
        
        public int SupplierId { get; set; }
        public int TransactionId { get; set; }
        public DateTime ExpireDate { get; set; }


    }
    public class POandPurchaseVM
    {
        public ICollection<PO> PO { get; set; }
        public int PurchaseId { get; set; }
        //public PurchaseDetails PurchaseDetails { get; set; }
        [DisplayName("Quantity:")]
        [Required]
        public int Quantity { get; set; }
        [DisplayName("Unit Price:")]
        [Required]
        public double UnitPrice { get; set; }

        public decimal? Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int? PurchaseOrderId { get; set; }


    }
}
