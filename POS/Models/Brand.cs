using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Brand
    {
        
        [Key]
  
        public int Id { get; set; }

        [DisplayName("Brand Name:")]
        [Required]
        public string BrandName { get; set; }
        [DisplayName("Brand ID:")]
        [Required]
        public string BrandCode { get; set; }
        public string Remarks { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreateId { get; set; }
        public int CompanyId { get; set; }
        //[ForeignKey("CompanyId")]
        //public virtual Company Company { get; set; }
        


    }
}
