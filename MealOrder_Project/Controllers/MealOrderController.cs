using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MealOrder_Project.Models;
using MealOrder_Project;


namespace MealOrder_Project.Controllers
{
    public class MealOrderController : Controller
    {
        private readonly MyCompanyEntities CompanyEntities = new MyCompanyEntities();

        // Orders Detail
        public ActionResult OrdersDetail()
        {
            var orderdata = CompanyEntities.MealOrders.ToArray();
            
            return View(orderdata);
        }

        // Create Orders
        public ActionResult CreateOrders()
        {
            ViewBag.type = GetSelectListItem.Type();
            ViewBag.category = GetSelectListItem.Category();
            ViewBag.yesorno = GetSelectListItem.YesorNo();
            
            return View();
        }

       
    }
}
