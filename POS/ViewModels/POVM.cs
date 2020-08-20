using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public class POVM
    {
        public int PurchaseOrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
