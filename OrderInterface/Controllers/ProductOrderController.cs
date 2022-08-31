using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OrderInterface.Models;

namespace OrderInterface.Controllers
{
    public class ProductOrderController : Controller
    {
        MarketDatabaseEntities DB = new MarketDatabaseEntities();
        // GET: ProductOrder
        public ActionResult Index(int id = (0))
        {
            Order_ order = DB.Order_.FirstOrDefault(x => x.OrderID == id);
            if (order == null)
            {
                return RedirectToAction("CreateOrder", "Order");
            }
            ViewBag.AllProducts = DB.Product.ToList();
            ViewBag.OrderInfo = DB.OrderInfoByProducts.Where(x => x.OrderID == id).ToList();
            ViewBag.TotalPrice = CalculateTotal(id);
            return View(order);
        }

       
        public ActionResult AddProduct(ProductOrder Porder) 
        {
            Order_ O = DB.Order_.FirstOrDefault(x => x.OrderID == Porder.OrderID);
            if (Porder.ProductID == 0)
            {
                ViewBag.EmptySelection = "You have to select an item.";
                return RedirectToAction("Index", Porder.OrderID);
            }
            else
            {
                O.ProductOrder.Add(Porder);
                DB.SaveChanges();
                return RedirectToRoute(new { controller = "ProductOrder", action = "Index", id = Porder.OrderID });

            }

        }
        public ActionResult DeleteProduct(int id) //set foreign key to a null, Cascade?
        {
            OrderInfoByProducts PorderInfo = DB.OrderInfoByProducts.FirstOrDefault(x => x.ProductOrderID == id);
            Order_ order = DB.Order_.FirstOrDefault(x => x.OrderID == PorderInfo.OrderID);
            ProductOrder Porder = DB.ProductOrder.FirstOrDefault(x => x.ProductOrderID == id);
          
            order.ProductOrder.Remove(Porder);
            DB.SaveChanges();

            return RedirectToRoute(new { controller = "ProductOrder", action = "Index", id = order.OrderID });
        }

        public decimal CalculateTotal(int id)
        {
            decimal Total = 0;
            Order_ order = DB.Order_.FirstOrDefault(x => x.OrderID == id);
            List<OrderInfoByProducts> productOrder = DB.OrderInfoByProducts.Where(x => x.OrderID == order.OrderID).ToList();
            
            foreach (OrderInfoByProducts i in productOrder)
            {
                Total += i.Price;
            }

            order.TotalPrice = Total;
            DB.SaveChanges();
            return Total;
        }
    }
}