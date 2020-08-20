using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
      public class SubCategory
    {
        [Key]

        public int Id { get; set; }
        [DisplayName("SubCategory ID:")]
        [Required]
        public string Code { get; set; }
        [DisplayName("SubCategory Name:")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}

