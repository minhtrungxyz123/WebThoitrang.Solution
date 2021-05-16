using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoitrang.Web.Models;

namespace WebThoitrang.Web.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            OrderList strBH = new OrderList();
            List<OrderViewModel> obj = strBH.getOrderViewModels(string.Empty);

            return View(obj);
        }
    }
}