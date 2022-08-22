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
        MarketDatabaseEntities M = new MarketDatabaseEntities();
        
        // GET: ProductsList
        public ActionResult Index()
        {
            
            return View();
        }

       
    }
}