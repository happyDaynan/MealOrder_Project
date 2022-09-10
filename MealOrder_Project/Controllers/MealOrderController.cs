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

        private bool success_bool = true;
        private string restext = "";

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
            }

            restext = (success_bool)? "訂餐成功。":"訂單新增失敗，請聯絡相關單位。";

            return Json(new { success = success_bool, responseText = restext }, JsonRequestBehavior.AllowGet);
        }

        // 刪除訂單
        [HttpPost]
        public ActionResult DelectOrders(string orderid)
        {
            OrdersGenerator delorder = new OrdersGenerator()
            {
                OrderId = Convert.ToInt32(orderid)
            };

            success_bool = delorder.DelectOrders();

            restext = (success_bool) ? "刪除成功" : "刪除失敗";

            return Json(new { success = success_bool, responseText = restext }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditOrders(string orderid)
        {                    
            
            var _orderid = Convert.ToInt32(orderid);

            var editdata = CompanyEntities.MealOrders.Where(m => m.Id.Equals(_orderid)).FirstOrDefault();

            if (editdata is null)
            {
                return JavaScript("alert(\"無此訂單!\")");
            }

            var selected_Category = editdata.Category;            

            ViewBag.diningdate = editdata.DiningDate.ToString("yyyy-MM-dd");
            ViewBag.type = editdata.MealType_Detail.Name;


            ViewBag.category = GetSelectListItem.Category(selected_Category);            
            

            return PartialView();
        }

        [HttpPost]
        public ActionResult EditOrders(string orderId, string categoryId)
        {                        
            OrdersGenerator editorder = new OrdersGenerator
            {
                OrderId = Convert.ToInt32(orderId),
                Category = Convert.ToInt32(categoryId)
            };

            success_bool = editorder.EditOrders();

            restext = (success_bool) ? "編輯成功" : "編輯失敗";

            return Json(new { success = success_bool, responseText = restext }, JsonRequestBehavior.AllowGet);
        }


    }
}
