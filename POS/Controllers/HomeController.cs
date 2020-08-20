using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.Infrastructure;

namespace POS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPurchase _purchase;
        private readonly ISale _sale;
        public HomeController(IPurchase _purchase, ISale _sale)
        {
            this._purchase = _purchase;
            this._sale = _sale;
        }
        public IActionResult Index()
        {

            var SumPurchase = _purchase.GetAll().Select(x => x.TotalPrice).Sum();
            var SumSale = _sale.GetVm().Select(x => x.DicountPrice).Sum();
            ViewBag.SumPurchase = SumPurchase;
            ViewBag.Sale = SumSale;
            return View();
        }
    }
}