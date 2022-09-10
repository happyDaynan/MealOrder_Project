using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MealOrder_Project.Models;

namespace MealOrder_Project
{
    public class GetSelectListItem
    {
        public static List<SelectListItem> Category(int? selected_Category = null)
        {
            using (MyCompanyEntities CompanyEntities = new MyCompanyEntities())
            {
                var _CategoryList = CompanyEntities.MealCategory_Detail.ToArray();

                List<SelectListItem> _CategorySelectListItem = new List<SelectListItem>
                {
                    new SelectListItem { Text = "--請選擇--", Value = "", Selected = !selected_Category.HasValue}
                };

                foreach (var item in _CategoryList)
                {                   
                    _CategorySelectListItem.Add(new SelectListItem{ 
                            Text = item.Category,
                            Value = item.Id.ToString(),
                            Selected = selected_Category.HasValue && item.Id.Equals(selected_Category)
                    });
                }              


                return _CategorySelectListItem;

            }

        }


        public static List<SelectListItem> Type(int? selected_type = null)
        {
            using (MyCompanyEntities CompanyEntities = new MyCompanyEntities())
            {
                var _TypeList = CompanyEntities.MealType_Detail.ToArray();

                List<SelectListItem> _TypeSelectListItem = new List<SelectListItem>
                {
                    new SelectListItem{ Text = "--請選擇--", Value = "", Selected = !selected_type.HasValue }
                };

                foreach (var item in _TypeList)
                {
                    _TypeSelectListItem.Add(new SelectListItem { 
                        
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = selected_type.HasValue && item.Id.Equals(selected_type)
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
