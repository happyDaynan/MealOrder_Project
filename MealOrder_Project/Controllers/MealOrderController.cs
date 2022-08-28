using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MealOrder_Project.Models;


namespace MealOrder_Project.Controllers
{
    public class MealOrderController : Controller
    {
        private MyCompanyEntities CompanyEntities = new MyCompanyEntities();

        // Orders Detail
        public ActionResult OrdersDetail()
        {
            var orderdata = CompanyEntities.MealOrders.ToArray();
            
            return View(orderdata);
        }

        // Create Orders
        public ActionResult CreateOrders()
        {
            return View();
        }

       
    }
}
