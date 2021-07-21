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
        private InventoryEntities _IE;

        public ProductController(InventoryEntities iE)
        {
            _IE = iE;
        }

        // GET: Product
        public ActionResult ViewProduct()
        {
            var pro = (from i in _IE.Products
                       select i).ToList();
            return View(pro);
        }

        [HttpGet]
        public ActionResult AddAProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAProduct(Product pro)
        {
            _IE.Products.Add(pro);
            _IE.SaveChanges();
            return RedirectToAction("ViewProduct");
        }

        [HttpGet]
        public ActionResult DetailsProduct(int id = 0)
        {
            var pro = _IE.Products.Where(i => i.ProductId == id).FirstOrDefault();
            return View(pro);
        }

        [HttpGet]
        public ActionResult EditProduct(int id = 0)
        {
            var pro = _IE.Products.Where(i => i.ProductId == id).FirstOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult EditProduct(Product pro)
        {
            var data = (from i in _IE.Products
                        where i.ProductId == pro.ProductId
                        select i).FirstOrDefault();
            if (data != null)
            {
                data.Name = pro.Name;
                data.Description = pro.Description;
                data.Price = pro.Price;
                data.DiscountRange = pro.DiscountRange;
                _IE.SaveChanges();
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