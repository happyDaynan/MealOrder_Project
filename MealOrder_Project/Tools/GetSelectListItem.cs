using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MealOrder_Project.Models;

namespace MealOrder_Project
{
    public class GetSelectListItem
    {
        public static List<SelectListItem> Category()
        {
            using (MyCompanyEntities CompanyEntities = new MyCompanyEntities())
            {
                var _CategoryList = CompanyEntities.MealCategory_Detail.ToArray();

                List<SelectListItem> _CategorySelectListItem = new List<SelectListItem>
                {
                    new SelectListItem { Text = "--請選擇--", Value = "", Selected = true}
                };

                foreach (var item in _CategoryList)
                {
                    _CategorySelectListItem.Add(new SelectListItem{ 
                            Text = item.Category,
                            Value = item.Id.ToString(),
                            Selected = false
                    });
                }                

                return _CategorySelectListItem;

            }

        }


        public static List<SelectListItem> Type()
        {
            using (MyCompanyEntities CompanyEntities = new MyCompanyEntities())
            {
                var _TypeList = CompanyEntities.MealType_Detail.ToArray();

                List<SelectListItem> _TypeSelectListItem = new List<SelectListItem>
                {
                    new SelectListItem{ Text = "--請選擇--", Value = "", Selected = true }
                };

                foreach (var item in _TypeList)
                {
                    _TypeSelectListItem.Add(new SelectListItem { 
                        
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = false

                    });
                }               

                return _TypeSelectListItem;
            }
        }


        // Yes or No
        public static List<SelectListItem> YesorNo()
        {
            List<SelectListItem> _YesorNoSelectListItem = new List<SelectListItem>
            {
                new SelectListItem{ Text = "是", Value = "true", Selected = true },
                new SelectListItem{ Text = "否", Value = "false", Selected = false }
            };

            return _YesorNoSelectListItem;
        }

    }
}
