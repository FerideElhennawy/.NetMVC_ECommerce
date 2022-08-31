using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderInterface.Models;

namespace OrderInterface.Controllers
{
    public class OrderController : Controller
    {
        MarketDatabaseEntities DB = new MarketDatabaseEntities();
        
        // GET: ProductsList
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult CreateOrder()
        {
            Order_ NewOrder = new Order_();
            
            DB.Order_.Add(NewOrder);
            DB.SaveChanges();
            //return RedirectToAction("ProductOrder", "Index", NewOrder.OrderID);
            return RedirectToRoute(new { controller = "ProductOrder", action = "Index", id = NewOrder.OrderID });
        }

        public ActionResult IssueOrder(int id = 0)
        {
            Order_ order = DB.Order_.FirstOrDefault(x => x.OrderID == id);
            if (order != null && order.ProductOrder != null)
            {
                DB.Order_.Add(order);
                DB.SaveChanges();
            }

            return RedirectToAction("CreateOrder");
        }


    }
}