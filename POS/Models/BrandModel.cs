using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class BrandModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name:")]
        [Required]
        public string Name { get; set; }
       
        public string Remarks { get; set; }
        public DateTime CreateDate { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
      
    }
}
