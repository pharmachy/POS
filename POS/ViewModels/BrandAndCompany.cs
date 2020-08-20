using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public class BrandAndCompany
    {
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
        public string CompanyName { get; set; }
    }
}
