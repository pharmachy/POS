using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public class GeneralVM
    {
        [Key]
        public int GeneralVMId { get; set; }
        public int TestParentId { get; set; }

        public string TestParentName { get; set; }
        public int TestChildId { get; set; }
     
        public string Name { get; set; }
        public int Age { get; set; }
     
       public   GeneralPO GeneralPO { get; set; }
    }
    public class GeneralPO
    {
        [Key]
        public int GeneralPOId { get; set; }
        public int NewId { get; set; }

        public string Extra { get; set; }
      
      


    }
}
