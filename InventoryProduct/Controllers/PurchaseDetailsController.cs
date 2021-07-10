using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryProduct.Models;

namespace InventoryProduct.Controllers
{
    public class PurchaseDetailsController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: PurchaseDetails
        public ActionResult ViewPurchaseDetails()
        {
            var purchaseOrderDetails = db.PurchaseOrderDetails.Include(p => p.Product).Include(p => p.PurchaseOrder);
            return View(purchaseOrderDetails.ToList());
        }


        public ActionResult PurchaseDetails(int id = 0)
        {
            var purchaseOrderDetail = db.PurchaseOrderDetails.Where(i=>i.PODID == id).FirstOrDefault();
            return View(purchaseOrderDetail);
        }

        public ActionResult AddAPurchase()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            ViewBag.OID = new SelectList(db.PurchaseOrders, "POID", "POID");
            return View();
        }

        [HttpPost]
        public ActionResult AddAPurchase(PurchaseOrderDetail purchaseOrderDetail)
        {
            db.PurchaseOrderDetails.Add(purchaseOrderDetail);
            db.SaveChanges();
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", purchaseOrderDetail.ProductId);
            ViewBag.OID = new SelectList(db.PurchaseOrders, "POID", "POID", purchaseOrderDetail.OID);
            return RedirectToAction("ViewPurchaseDetails");
        }

        public ActionResult EditPurchaseDetails(int id=0)
        {
            PurchaseOrderDetail purchaseOrderDetail = db.PurchaseOrderDetails.Find(id);
            ViewBag.Product = new SelectList(db.Products, "ProductId", "Name", purchaseOrderDetail.ProductId);
            ViewBag.OID = new SelectList(db.PurchaseOrders, "POID", "POID", purchaseOrderDetail.OID);
            return View(purchaseOrderDetail);
        }

        [HttpPost]
        public ActionResult EditPurchaseDetails(PurchaseOrderDetail purchaseOrderDetail)
        {
            db.Entry(purchaseOrderDetail).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.Product = new SelectList(db.Products, "ProductId", "Name", purchaseOrderDetail.ProductId);
            ViewBag.OID = new SelectList(db.PurchaseOrders, "POID", "Name", purchaseOrderDetail.OID);
            return RedirectToAction("ViewPurchaseDetails");
        }

        public ActionResult RemovePurchaseDetails(int id = 0)
        {
            var purchase = db.PurchaseOrderDetails.Where(i => i.PODID == id).FirstOrDefault();
            db.PurchaseOrderDetails.Remove(purchase);
            db.SaveChanges();
            return RedirectToAction("ViewPurchaseDetails");
        }
    }
}
