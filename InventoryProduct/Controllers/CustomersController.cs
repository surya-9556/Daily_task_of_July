using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryProduct.Models;

namespace InventoryProduct.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult ViewCustomer()
        {
            using (InventoryEntities _IE = new InventoryEntities())
            {
                var cus = (from i in _IE.Customers
                           select i).ToList();
                return View(cus);
            }
        }

        [HttpGet]
        public ActionResult AddACustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddACustomer(Customer cus)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                IE.Customers.Add(cus);
                IE.SaveChanges();
            }
            return RedirectToAction("ViewCustomer");
        }

        [HttpGet]
        public ActionResult DetailsCustomer(int id = 0)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                var cus = IE.Customers.Where(i => i.CustomerId == id).FirstOrDefault();
                return View(cus);
            }
        }

        [HttpGet]
        public ActionResult EditCustomer(int id = 0)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                var cus = IE.Customers.Where(i => i.CustomerId == id).FirstOrDefault();
                return View(cus);
            }
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer cus)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                var data = (from i in IE.Customers
                            where i.CustomerId == cus.CustomerId
                            select i).FirstOrDefault();
                if (data != null)
                {
                    data.Name = cus.Name;
                    data.Address = cus.Address;
                    data.ContactNo = cus.ContactNo;
                    IE.SaveChanges();
                }
            }
            return RedirectToAction("ViewCustomer");
        }

        public ActionResult DeleteCustomer(int id = 0)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                var cus = IE.Customers.Where(i => i.CustomerId == id).FirstOrDefault();
                IE.Customers.Remove(cus);
                IE.SaveChanges();
                return RedirectToAction("ViewProduct");
            }
        }
    }
}