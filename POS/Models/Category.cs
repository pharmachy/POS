using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name:")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Category ID:")]
        public string Code { get; set; }
       // public ICollection<Product> Products { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }


    }
}