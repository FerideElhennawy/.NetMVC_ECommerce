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
        MarketDatabaseEntities M = new MarketDatabaseEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
       
    }
}