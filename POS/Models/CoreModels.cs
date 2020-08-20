using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POS.Models
{
    public abstract class CoreModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public bool Active { get; set; } = true;
        public string User { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string Remarks { get; set; }
        public int UserID { get; set; }

        //public bool IsActive { get; set; }
    }
    public class Logger : CoreModel
    {
       
        public string EntityName { get; set; }
        public int EntityID { get; set; }
        public string Description { get; set; }
    }
}
