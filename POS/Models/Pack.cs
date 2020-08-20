using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Pack
    {

        public int PackId { get; set; }

        [DisplayName("Pack Size Name")]
        [Required]
        public string PackSizeName { get; set; }

        [DisplayName("Quantity")]
        [Required]
        public int PackQty { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }
    }

}
