using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryProduct.Models;

namespace InventoryProduct.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ViewProduct()
        {
            using (InventoryEntities _IE = new InventoryEntities())
            {
                var pro = (from i in _IE.Products
                           select i).ToList();
                return View(pro);
            }
        }

        [HttpGet]
        public ActionResult AddAProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAProduct(Product pro)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                IE.Products.Add(pro);
                IE.SaveChanges();
            }
            return RedirectToAction("ViewProduct");
        }

        [HttpGet]
        public ActionResult DetailsProduct(int id = 0)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                var pro = IE.Products.Where(i=>i.ProductId == id).FirstOrDefault();
                return View(pro);
            }
        }

        [HttpGet]
        public ActionResult EditProduct(int id = 0)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                var pro = IE.Products.Where(i => i.ProductId == id).FirstOrDefault();
                return View(pro);
            }
        }

        [HttpPost]
        public ActionResult EditProduct(Product pro)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                var data = (from i in IE.Products
                            where i.ProductId == pro.ProductId
                            select i).FirstOrDefault();
                if (data != null)
                {
                    data.Name = pro.Name;
                    data.Description = pro.Description;
                    data.Price = pro.Price;
                    data.DiscountRange = pro.DiscountRange;
                    IE.SaveChanges();
                }
            }
            return RedirectToAction("ViewProduct");
        }

        public ActionResult DeleteProduct(int id = 0)
        {
            using (InventoryEntities IE = new InventoryEntities())
            {
                var pro = IE.Products.Where(i => i.ProductId == id).FirstOrDefault();
                IE.Products.Remove(pro);
                IE.SaveChanges();
                return RedirectToAction("ViewProduct");
            }
        }
    }
}