using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderInterface.Models;

namespace OrderInterface.Controllers
{
    public class OrderInfoByProductController : Controller
    {
        MarketDatabaseEntities M = new MarketDatabaseEntities();
        // GET: OrderInfoByProject
        public ActionResult Index()
        {
            return View();
        }
    }
}