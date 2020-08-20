using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class PO
    {
        [Key]
        public int PurchaseOrderId { get; set; }
        [Display(Name ="Order No")]
        [Required]
        public string PurchaseOrderNo { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public decimal? NetDiscount { get; set; }
        public decimal NetTotal { get; set; }
        // public ICollection<OrderDetail> OrderDetails { get; set; }
       // public string OrderDateString { get; internal set; }
    }
    public class OrderDetail
    {
     
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SubCategoryId { get; set; }
      //  public int SupplierId { get; set; }
        public int ProductId { get; set; }
      
        public PO PO { get; set; }
        //Supplier        
   
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        [Display(Name ="Total Amount")]
        public decimal TotalAmount { get; set; } 
        [Display(Name = "Discount %")]
        public decimal? DiscountPer { get; set; }
    }
    public class OrderDetailVM
    {
        [Key]
        // public int OrderItemId { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public string OrderNo { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Description { get; set; }
        public decimal? NetDiscount { get; set; }
        public decimal NetTotal { get; set; }
        //public OrderDetail OrderDetail { get; set; }
        // List<OrderDetail> OrderDetail { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
        //  public int PurchaseOrderId { get; set; }
        //public int SubCategoryId { get; set; }
        //public int ProductId { get; set; }
    
        //public int Quantity { get; set; }
        //public decimal Rate { get; set; }
        //public decimal TotalAmount { get; set; }


    }
    public class OrderDetailVM2
    {
        [Key]
        // public int OrderItemId { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string OrderNo { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Description { get; set; }
    
        public ICollection<OrderDetail> OrderDetail { get; set; }
     
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Discount %")]
        public decimal? DiscountPer { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SubCategoryName { get; set; }
        public int SubCategoryId { get; set; }



    }
    public class OrderDetailVM3
    {
        [Key]
        // public int OrderItemId { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string OrderNo { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Description { get; set; }

       


    }
}
