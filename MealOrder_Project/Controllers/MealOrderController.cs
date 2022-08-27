using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MealOrder_Project.Controllers
{
    public class MealOrderController : Controller
    {
        // Orders Detail
        public ActionResult OrdersDetail()
        {
            return View();
        }

        // Create Orders
        public ActionResult CreateOrders()
        {
            return View();
        }

       
    }
}
