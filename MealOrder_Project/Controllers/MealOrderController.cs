using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MealOrder_Project.Models;
using MealOrder_Project.Tools;
using Newtonsoft.Json;


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
            
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateOrders(string formdata)
        {
            string restext = "";
            bool success_bool = true;

            // Convert string to DictionaryObject
            var Formdata = JsonConvert.DeserializeObject<Dictionary<string, string>>(formdata);
            
            OrdersGenerator neworders = new OrdersGenerator
            {
                Start = DateTime.Parse(Formdata["StartDate"]),
                End = DateTime.Parse(Formdata["EndDate"]),
                Category = int.Parse(Formdata["category"]),
                Type = int.Parse(Formdata["type"]),
                Sat = bool.Parse(Formdata["sat"]),
                Sun = bool.Parse(Formdata["sun"])
            };

            List<MealOrders> NewOrders = neworders.NewOrders();

            CompanyEntities.MealOrders.AddRange(NewOrders);

            try
            {
                CompanyEntities.SaveChanges();
            }
            catch
            {
                success_bool = false;
                restext = "訂單新增失敗，請聯絡相關單位。";
            }

            return Json(new { success = success_bool, responseText = restext }, JsonRequestBehavior.AllowGet);
        }



    }
}
