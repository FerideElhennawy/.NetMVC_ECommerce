using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderInterface.Models;

namespace OrderInterface.Controllers
{
    public class ProductController : Controller
    {
        MarketDatabaseEntities DB = new MarketDatabaseEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductByBarcode(string barcode, int orderID)
        {
            Product ScanedProduct = DB.Product.FirstOrDefault(x => x.Barcode == barcode);
            if (ScanedProduct == null)
            {
                ViewBag.WrongBarcode = "Product does not exist, please try again.";
                return RedirectToRoute(new { controller = "ProductOrder", action = "Index", id = orderID });
            }

            ProductOrder Porder = new ProductOrder();
            Porder.ProductID = ScanedProduct.ProductID;
            Porder.OrderID = orderID;


            return RedirectToAction("AddProduct", "ProductOrder", Porder);
        }
    }
}