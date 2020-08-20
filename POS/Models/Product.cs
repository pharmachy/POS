using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Product
    {
        public int Id { get; set; }      
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }     
        //Company
        [Display(Name = "Company Name")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        //Category
       [Display(Name ="Sub Category")]
        public int SubCategoryId { get; set; }       
        public SubCategory SubCategory { get; set; }
        [Display(Name = "Model Name")]
        public int BrandModelId { get; set; }
        public BrandModel BrandModel { get; set; }
        [Display(Name = "Unit")]
        public int UnitId { get; set; }  
        public Unit Unit { get; set; }
        [Display(Name ="Photo")]
        public string ProductImage { get; set; }
        public string Description { get; set; }
       // public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
