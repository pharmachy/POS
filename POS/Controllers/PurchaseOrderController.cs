using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using POS.Data;
using POS.Models;
using POS.ViewModels;

namespace POS.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly POSDbContext _db;
        public PurchaseOrderController(POSDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            var r = _db.PO.Select(x => x.PurchaseOrderId).LastOrDefault() + 1;

            ViewBag.Code = "PO-" + r;
            ViewData["SupplierId"] = _db.Suppliers.ToList();
            ViewData["CategoryId"] = _db.Categories.ToList();
            ViewData["ProductId"] = _db.Products.ToList();
            ViewData["CompanyId"] = _db.Companies.ToList();
            ViewBag.BrandId = _db.Brands.ToList();
            ViewData["ModelId"] = _db.BrandModels.ToList();
            ViewBag.Date = DateTime.Now.ToString("MM/dd/yyyy");
            var data = _db.PO.ToList(); ;

            return View(data);
        }
        [HttpPost]
        //public JsonResult GetCatList(int CategoryId)//-------------------------------------------------------------------------
        public IActionResult GetSubCatList(int CategoryId)//-------------------------------------------------------------------------
        {
            //dbContext.Configuration.ProxyCreationEnabled = false;

            var ItemList = _db.SubCategories.Where(x => x.CategoryId == CategoryId).ToList();
            // return Json(new SelectList(ItemList, "Id", "Name"/*, JsonRequestBehavior.AllowGet*/));
            //return Json(ItemList);
            var list = JsonConvert.SerializeObject(ItemList,
        Formatting.None,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

            return Content(list, "application/json");

        }
        public IActionResult PoList()
        {
            var r = _db.PO.Select(x => x.PurchaseOrderId).LastOrDefault() + 1;
          
            ViewBag.Code = "PO-" + r;
            ViewData["SupplierId"] = _db.Suppliers.ToList();
            ViewData["CategoryId"] = _db.Categories.ToList();
            ViewData["ProductId"] = _db.Products.ToList();
            ViewData["CompanyId"] = _db.Companies.ToList();
            ViewBag.BrandId = _db.Brands.ToList();
            ViewData["ModelId"] = _db.BrandModels.ToList();
            var data = _db.PO.ToList(); ;
               return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetailsEdit(int? id)
        {
     
            ViewData["ProductId"] = new SelectList(_db.Products, "Id", "ProductName");
            ViewData["SubCategoryId"] = new SelectList(_db.SubCategories, "Id", "Name");

            ///  ViewBag.ProductId= _db.Products.ToList();
            if (id == null)
            {
                return NotFound();
            }
            var testParent = await _db.OrderDetail.FindAsync(id);
            
            if (testParent == null)
            {
                return NotFound();
            }
            return View(testParent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderDetailsCreate(int id, OrderDetail testParent)
        {
            //if (id != testParent.OrderDetailId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {

                _db.OrderDetail.Add(testParent);
                await _db.SaveChangesAsync();


            }
            return RedirectToAction("PurchaseByPO", new { id = testParent.PurchaseOrderId });
        }

        public IActionResult Delete(int id)
        {
            var data = _db.PO.Find(id);
            _db.PO.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("PoList");


        }
        public IActionResult OrderDetailsDelete(int id)
        {
            var data = _db.OrderDetail.Find(id);
            _db.OrderDetail.Remove(data);
            _db.SaveChanges();
        
            return RedirectToAction("PurchaseByPO", new { id = data.PurchaseOrderId });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderDetailsEdit(int id, OrderDetail testParent)
        {
            if (id != testParent.OrderDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _db.OrderDetail.Update(testParent);
                await _db.SaveChangesAsync();


            }
            return RedirectToAction("PurchaseByPO",new {id=testParent.PurchaseOrderId });
        }
        public async Task<IActionResult> Edit(int? id)
        {

            ViewBag.SupplierId = new SelectList(_db.Suppliers/*.Where(x=>x.Id==id)*/, "Id", "Name"); 
            if (id == null)
            {
                return NotFound();
            }

            var testParent = await _db.PO.FindAsync(id);
            if (testParent == null)
            {
                return NotFound();
            }
            return View(testParent);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  PO testParent)
        {
            if (id != testParent.PurchaseOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                    _db.Update(testParent);
                    await _db.SaveChangesAsync();
              
               
            }
            return RedirectToAction("PoList");
        }
        public async Task<IActionResult> PurchaseByPO(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testParent = await _db.PO.FindAsync(id);
            ViewBag.SupplierId = new SelectList(_db.Suppliers/*.Where(x=>x.Id==id)*/, "Id", "Name");
            ViewBag.Sid = _db.Suppliers.Where(x => x.Id == id);

            ViewData["CategoryId"] = _db.Categories.ToList();


            //  ViewBag.OderDetails = _db.OrderDetail.Where(x => x.PurchaseOrderId == id).ToList();
            var master = (from p in _db.PO
                        join pr in _db.OrderDetail on p.PurchaseOrderId equals pr.PurchaseOrderId
                        join s in _db.Suppliers on p.SupplierId equals s.Id
                 

                        where p.SupplierId ==s.Id && pr.PurchaseOrderId == id
                        select new OrderDetailVM3
                        {
                            PurchaseOrderId = pr.PurchaseOrderId,
                           
                            OrderNo = p.PurchaseOrderNo,
                            SupplierId = p.SupplierId,
                            SupplierName = s.Name,
                            OrderDate=p.OrderDate,
                            DeliveryDate=p.DeliveryDate,
                            Description=p.Description




                        }).ToList();

            ViewBag.Master = master;
            var data = (from p in _db.PO
                        join pr in _db.OrderDetail on p.PurchaseOrderId equals pr.PurchaseOrderId
                        join sc in _db.SubCategories on pr.SubCategoryId equals sc.Id
                        join product in _db.Products on pr.ProductId equals product.Id

                        where /*p.PurchaseOrderId ==id &&*/ pr.PurchaseOrderId==id
                        select new OrderDetailVM2
                        {
                            PurchaseOrderId=pr.PurchaseOrderId,
                            OrderDetailId=pr.OrderDetailId,
                            OrderNo = p.PurchaseOrderNo,
                            //SupplierId = p.SupplierId,
                            ProductId = pr.ProductId,
                            ProductName=product.ProductName,
                            SubCategoryId=pr.SubCategoryId,
                            SubCategoryName=sc.Name,
                            Quantity = pr.Quantity,
                            Rate = pr.Rate,
                            DiscountPer = pr.DiscountPer,
                            TotalAmount = pr.TotalAmount


                        }).ToList();

            ViewBag.OderDetails = data;
            if (testParent == null)
            {
                return NotFound();
            }
            return View(testParent);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PurchaseByPO(int id/*,  PO testParent*/)
        {
            //if (id != testParent.PurchaseOrderId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
                var data = (from p in _db.PO
                            join pr in _db.OrderDetail on p.PurchaseOrderId equals pr.PurchaseOrderId
                           // join sc in _db.SubCategories on pr.SubCategoryId equals sc.Id
                            join product in _db.Products on pr.ProductId equals product.Id

                            where /*p.PurchaseOrderId ==id &&*/ pr.PurchaseOrderId == id
                            select new OrderDetailVM2
                            {
                                PurchaseOrderId = pr.PurchaseOrderId,
                                OrderDetailId = pr.OrderDetailId,
                                //OrderNo = p.PurchaseOrderNo,
                                SupplierId = p.SupplierId,
                                ProductId = pr.ProductId,
                                //ProductName = product.ProductName,
                                //SubCategoryId = pr.SubCategoryId,
                                //SubCategoryName = sc.Name,
                                Quantity = pr.Quantity,
                                Rate = pr.Rate,
                                DiscountPer = pr.DiscountPer,
                                TotalAmount = pr.TotalAmount


                            }).ToList();

                foreach (OrderDetailVM2 item in data)
                {
                    Purchase p = new Purchase();
                    p.PurchaseDetailsId = item.OrderDetailId;
                    p.SupplierId = item.SupplierId;
                    p.PurchaseDate = DateTime.Now;
                    //p.OrderDetailId = item.OrderDetailId;
                    //  orderDetail.OrderDetailId = order.OrderDetailId;
                 
                   p.ProductId = item.ProductId;
                   p.Quantity = item.Quantity;
                   p.UnitPrice = item.Rate;
                   p.Discount = item.DiscountPer;
                    p.TotalPrice = item.TotalAmount;
                    _db.Purchases.Add(p);
                }


                // _db.Purchases.Add(testParent);
                //_db.SaveChanges();
                await _db.SaveChangesAsync();


            //}
            return RedirectToAction("AllViewList", "Purchase",new { });
        }
        public IActionResult PoDetailsList()
        {
            var r = _db.OrderDetail.Select(x => x.PurchaseOrderId).LastOrDefault() + 1;

            ViewBag.Code = "PO-" + r;
            ViewData["SupplierId"] = _db.Suppliers.ToList();
            ViewData["CategoryId"] = _db.Categories.ToList();
            ViewData["ProductId"] = _db.Products.ToList();
            ViewData["CompanyId"] = _db.Companies.ToList();
            ViewBag.BrandId = _db.Brands.ToList();
            ViewData["ModelId"] = _db.BrandModels.ToList();
            ViewBag.SubCategoryId = new SelectList(_db.SubCategories/*.Where(x=>x.Id==id)*/, "Id", "Name");
          //  ViewBag.Sid = _db.Suppliers.Where(x => x.Id == id);
            var data = _db.OrderDetail.ToList(); ;

            return View(data);
        }


        //April20----------
        public IActionResult GetBrandList(int CompanyId)//-------------------------------------------------------------------------
        {
            //dbContext.Configuration.ProxyCreationEnabled = false;

            var ItemList = _db.Brands.Where(x => x.CompanyId == CompanyId).ToList();

            var list = JsonConvert.SerializeObject(ItemList,
        Formatting.None,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

            return Content(list, "application/json");

        }
        public IActionResult GetModelList(int BrandId)//-------------------------------------------------------------------------
        {
            //dbContext.Configuration.ProxyCreationEnabled = false;

            var ModelList = _db.BrandModels.Where(x => x.BrandId == BrandId).ToList();
            // return Json(new SelectList(ItemList, "Id", "Name"/*, JsonRequestBehavior.AllowGet*/));
            //return Json(ItemList);
            var listModel = JsonConvert.SerializeObject(ModelList,
        Formatting.None,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

            return Content(listModel, "application/json");

        }
        //EndRegion--
        public JsonResult getProductCategories()
        {
            List<Category> Categories = new List<Category>();

            Categories = _db.Categories.OrderBy(a => a.Name).ToList();

            // return new JsonResult(category);
            return new JsonResult(Categories);
        }
        public JsonResult getProducts(int Id)
        {
            List<Product> products = new List<Product>();

            products = _db.Products.Where(a => a.Id.Equals(Id)).OrderBy(a => a.ProductName).ToList();

            return new JsonResult(products);
        }
        public IActionResult GetProductList(Product data)//-------------------------------------------------------------------------
        {
            var products = _db.Products.Where(x => x.SubCategoryId == data.SubCategoryId).OrderBy(a => a.ProductName).ToList();

            var listModel = JsonConvert.SerializeObject(products,
        Formatting.None,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

            return Content(listModel, "application/json");

        }
        public IActionResult GetCategoryList(OrderDetailVM data)//-------------------------------------------------------------------------
        {

            var products = _db.Categories.OrderBy(a => a.Name).ToList();

            var listModel = JsonConvert.SerializeObject(products,
        Formatting.None,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

            return Content(listModel, "application/json");

        }
        public IActionResult GetSubCategoryList(OrderDetailVM data)//-------------------------------------------------------------------------
        {

            var products = _db.SubCategories.OrderBy(a => a.Name).ToList();

            var listModel = JsonConvert.SerializeObject(products,
        Formatting.None,
              new JsonSerializerSettings()
              {
                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              });

            return Content(listModel, "application/json");

        }
        [HttpPost]
        public JsonResult save(OrderDetailVM order)
        {
            //bool status = false;
            //DateTime dateOrg;
            //var isValidDate = DateTime.TryParseExact(order.OrderDateString, "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrg);
            ////if (isValidDate)
            //{
            //    order.OrderDateString = dateOrg;
            //}

            //var isValidModel = TryUpdateModel(order);
            //if (ModelState.IsValid)
            //{
                var r = _db.PO.Select(x => x.PurchaseOrderId).LastOrDefault() + 1;

                var Code = "PO-" + r;
                PO po = new PO();
                po.OrderDate = order.OrderDate;
                po.DeliveryDate = order.DeliveryDate;


                po.PurchaseOrderNo = Code;
                po.SupplierId = order.SupplierId;
                po.Description = order.Description;
                po.NetDiscount = order.NetDiscount;
                po.NetTotal = order.NetTotal;
                po.PurchaseOrderId = order.PurchaseOrderId;
                _db.PO.Add(po);

                foreach (OrderDetail item in order.OrderDetail)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.PurchaseOrderId = po.PurchaseOrderId;
                    orderDetail.OrderDetailId = item.OrderDetailId;
                    //  orderDetail.OrderDetailId = order.OrderDetailId;
                    orderDetail.SubCategoryId = item.SubCategoryId;
                    orderDetail.ProductId = item.ProductId;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.Rate = item.Rate;
                    orderDetail.DiscountPer = item.DiscountPer;
                    orderDetail.TotalAmount = item.TotalAmount;
                    _db.OrderDetail.Add(orderDetail);
                }
                _db.SaveChanges();

             
                // status = true;
                //return new JsonResult (order);
            //}
            return Json("Success");
        }
        private object TryUpdateModel(PO order)
        {
            throw new NotImplementedException();
        }
        //public IActionResult OrderCreate()
        //{
        //    //ViewBag.GetBrandList = new SelectList(DropDownListHelper.GetBrandList(), "Value", "Text");
        //    //ViewBag.PartySupplierName =
        //    //    new SelectList(DropDownListHelper.GetPartySupplierList("Party"), "Value", "Text");
        //    //ViewBag.GiftTypeItems = new SelectList(DropDownListHelper.GetGiftTypeItemsNew(), "Value", "Text");
        //    //ViewBag.ItemNameWithSizeItems =
        //    //    new SelectList(DropDownListHelper.GetItemNameWithSizeItems(), "Value", "Text");
        //    //ViewBag.PaymentTypeItems = new SelectList(DropDownListHelper.GetPaymentTypeItems(), "Value", "Text");
        //    //ViewBag.BankName = new SelectList(DropDownListHelper.GetBankList(), "Value", "Text");
        //    //ViewBag.DiscountType = new SelectList(DropDownListHelper.GetDiscuntType(), "Value", "Text");
        //    //var date = DateTime.Now;
        //    //ViewBag.TransactionDate = date.ToString("dd-MM-yyyy");
        //    //ViewBag.MonthYear = date.ToString("MMM-yy").ToUpper();
        //    //ViewBag.TransactioId = IdGenerate.GenerateTransactionId("SALE", date);
        //    //var r = _db.PO.Select(x => x.PurchaseOrderId).LastOrDefault() + 1;

        //    //ViewBag.Code = "PO-" + r;
        //    return View();
        //}



        // POST: StoreSales/Create
        //[HttpPost]
        //public IActionResult OrderCreate(FormCollection collection)
        //{

        //         //string bankname = "";
        //        //var empid = CustomizedFunction.EncryptDecrypt.Decrypt(Request.Cookies["UserInfo"]?["UserId"].ToString());

        //        string name = Request.Form["ItemList"];
        //        var data = JsonConvert.DeserializeObject<List<TransactionDetailsCc>>(name);

        //        string transactionDate = Request.Form["TransactionDate"];
        //        string paymentDate = Request.Form["PaymentDate"];
        //        string brandId = Request.Form["BrandId"];
        //        var date = DateTime.ParseExact(transactionDate, "dd-MM-yyyy", null);
        //        var paymentdate = DateTime.ParseExact(paymentDate, "dd-MM-yyyy", null);
        //        var monthyear = date.ToString("MMM-yy").ToUpper();


        //        string vendorSupId = Request.Form["VendorSupId"];
        //        string discountPercentstring = Request.Form["DiscountPercent"];
        //        string utilizediscountPercentstring = Request.Form["UtilizeDiscountAmount"];

        //        string cashamountstring = Request.Form["CashAmount"];
        //        string bankamountstring = Request.Form["BankAmount"];
        //        string remarksmaster = Request.Form["Remarks"];




        //        foreach (var transactionDetailsCc in data)
        //        {

        //            // ItemDb itemDb = dbContext.ItemDb.First(x => x.ItemId == transactionDetailsCc.ItemId);
        //            //var GrossQty = Convert.ToDecimal(transactionDetailsCc.GrossQty);
        //            //var SizeQty = Convert.ToDecimal(itemDb.SizeQty);
        //            //    TransactionDetails transactionDetails = new TransactionDetails
        //            //{
        //            //    TransactionType = "SALE",
        //            //    TransactionDate = date,
        //            //    TransactionMonthYear = monthyear,

        //            //      UnitQty = Convert.ToDecimal(transactionDetailsCc.UnitQty),
        //            //    UnitRate = Convert.ToDecimal(transactionDetailsCc.UnitRate),

        //            //    //Amount = InventoryCustomizeFunction.AmountCalculationForSales(transactionDetailsCc.GiftType, Convert.ToDecimal(transactionDetailsCc.PackQty), Convert.ToDecimal(transactionDetailsCc.UnitRate), itemDb.SizeQty, Convert.ToDecimal(transactionDetailsCc.UnitQty)),

        //            //       RemarksDetails = "",
        //            //    CreateDate = DateTime.Now,

        //        };
        //        //totalAmount += transactionDetails.Amount;
        //        //dbContext.TransactionDetails.Add(transactionDetails);
        //        //itemserial++;
        //        //}
        //        //dbContext.SaveChanges();
        //        return RedirectToAction("Index");

        //}


        //[HttpPost]
        //public JsonResult SavePO(POVM pvm)
        //{

        //    if (ModelState.IsValid)
        //    {              

        //            PO po = new PO { PurchaseOrderNo = pvm.PurchaseOrderNo, OrderDate = pvm.OrderDate, Description = pvm.Description };
        //            foreach (var i in pvm.OrderDetails)
        //            {
        //              po.OrderDetails.Add(i);
        //            }
        //        _db.PO.Add(po);
        //        _db.SaveChanges();

        //    }
        //    return Json(pvm);
        //}


        //public IActionResult GetModelList(int BrandId)//-------------------------------------------------------------------------
        //{
        //    //dbContext.Configuration.ProxyCreationEnabled = false;

        //    var ModelList = _db.BrandModels.Where(x => x.BrandId == BrandId).ToList();
        //    // return Json(new SelectList(ItemList, "Id", "Name"/*, JsonRequestBehavior.AllowGet*/));
        //    //return Json(ItemList);
        //    var listModel = JsonConvert.SerializeObject(ModelList,
        //Formatting.None,
        //      new JsonSerializerSettings()
        //      {
        //          ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //      });

        //    return Content(listModel, "application/json");

        //}


        //[HttpPost]
        //public JsonResult save(OrderDetailVM order)
        //{
        //    bool status = false;
        //    DateTime dateOrg;
        //    var isValidDate = DateTime.TryParseExact(order.OrderDateString, "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrg);
        //    //if (isValidDate)
        //    //{
        //    //    order.OrderDateString = dateOrg;
        //    //}

        //    //var isValidModel = TryUpdateModel(order);
        //    //if (ModelState.IsValid)
        //    //{
        //    //    PO po = new PO();
        //    //    po.OrderDate = DateTime.Parse(order.OrderDateString);
        //    //    po.PurchaseOrderNo=order.OrderNo
        //    //    _db.PO.Add(order);
        //    //    _db.SaveChanges();
        //    //    status = true;
        //    //    //return new JsonResult (order);
        //    //}
        //    return Json(order);
        //}

    }

}
            
        
    
