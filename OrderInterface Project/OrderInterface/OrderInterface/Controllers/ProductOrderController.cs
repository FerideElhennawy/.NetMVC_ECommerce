using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderInterface.Models;

namespace OrderInterface.Controllers
{
    public class ProductOrderController : Controller
    {
        MarketDatabaseEntities M = new MarketDatabaseEntities();
        // GET: ProductOrder
        public ActionResult Index(int id = 2)
        {
            ViewBag.AllProducts = M.Product.ToList();
            ViewBag.O = M.ProductOrder.Where(x => x.OrderID == id).ToList();
            ViewBag.OrderInfo = M.OrderInfoByProducts.Where(x => x.OrderID == id).ToList();
            return View();
        }

        public ActionResult AddProduct(Product product) 
        {
            if (product.ProductID == 0)
            {
                ViewBag.message = "You have to select an item.";
                return RedirectToAction("Index");
            }
            else
            {
                Product p = M.Product.FirstOrDefault(x => x.ProductID == product.ProductID);
                Order_ o = new Order_();
                return RedirectToAction("Index");
            }

        }
        public ActionResult DeleteProduct(Product product) 
        {
            Product p = M.Product.FirstOrDefault(x => x.ProductID == product.ProductID);

            return RedirectToAction("Index");
        }
    }
}