using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryProduct.Models;

namespace InventoryProduct.Controllers
{
    public class FilteringController : Controller
    {
        private InventoryEntities IE = new InventoryEntities();

        // GET: Filtering
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Filter()
        {
            return View();
        }

        public ActionResult Names()
        {
            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        public ActionResult GetPro()
        {
            var filter1 = (from i in IE.PurchaseOrders
                           join p in IE.PurchaseOrderDetails
                           on i.POID equals p.OID
                           select new
                           {
                               Date = i.Date,
                               POID = i.POID,
                               Price = p.Price
                           }).ToList();
            return Json(new { data = filter1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNames()
        {
            var filter2 = (from i in IE.PurchaseOrders
                           join p in IE.PurchaseOrderDetails
                           on i.POID equals p.OID into table1
                           from p in table1.ToList()
                           join l in IE.Products
                           on p.ProductId equals l.ProductId into table2
                           from q in table2.ToList()
                           select new
                           {
                               Date = i.Date,
                               Name = q.Name,
                               Qty = p.qty
                           }).ToList();
            return Json(new { data = filter2 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCust()
        {
            var filter3 = (from i in IE.Customers
                           join l in IE.PurchaseOrders
                           on i.CustomerId equals l.CustomerId
                           select new
                           {
                               Date = l.Date,
                               Name = i.Name,
                               Amount = l.Amount
                           }).ToList();
            return Json(new { data = filter3 }, JsonRequestBehavior.AllowGet);
        }
    }
}