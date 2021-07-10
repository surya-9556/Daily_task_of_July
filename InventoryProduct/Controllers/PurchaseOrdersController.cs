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
    public class PurchaseOrdersController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        public ActionResult Index()
        {
            var purchaseOrders = db.PurchaseOrders.Include(p => p.Customer);
            return View(purchaseOrders.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            var purchaseOrder = db.PurchaseOrders.Where(i => i.POID == id).FirstOrDefault();
            return View(purchaseOrder);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(PurchaseOrder purchaseOrder)
        {
            db.PurchaseOrders.Add(purchaseOrder);
            db.SaveChanges();
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", purchaseOrder.CustomerId);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            var purchaseOrder = db.PurchaseOrders.Where(i => i.POID == id).FirstOrDefault();
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", purchaseOrder.CustomerId);
            return View(purchaseOrder);
        }

        [HttpPost]
        public ActionResult Edit(PurchaseOrder purchaseOrder)
        {
            db.Entry(purchaseOrder).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", purchaseOrder.CustomerId);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveOrder(int id = 0)
        {
            var purchaseOrder = db.PurchaseOrders.Where(i => i.POID == id).FirstOrDefault();
            db.PurchaseOrders.Remove(purchaseOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
