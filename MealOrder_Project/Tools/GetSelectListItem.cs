using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MealOrder_Project.Models;

namespace MealOrder_Project.Tools
{
    public class GetSelectListItem
    {
        public static List<SelectListItem> Category()
        {
            using (MyCompanyEntities CompanyEntities = new MyCompanyEntities())
            {
                var _CategoryList = CompanyEntities.MealCategory_Detail.ToArray();

                List<SelectListItem> _CategorySelectListItem = new List<SelectListItem>();

                foreach (var item in _CategoryList)
                {
                    _CategorySelectListItem.Add(new SelectListItem{ 
                            Text = item.Category,
                            Value = item.Id.ToString()                    
                    });
                }

                _CategorySelectListItem.Add(new SelectListItem
                {
                    Text = "--請選擇--",
                    Value = null,
                    Selected = true
                });

                return _CategorySelectListItem;

            }

        }


        public static List<SelectListItem> Type()
        {
            using (MyCompanyEntities CompanyEntities = new MyCompanyEntities())
            {
                var _TypeList = CompanyEntities.MealType_Detail.ToArray();

                List<SelectListItem> _TypeSelectListItem = new List<SelectListItem>();

                foreach(var item in _TypeList)
                {
                    _TypeSelectListItem.Add(new SelectListItem { 
                        
                        Text = item.Name,
                        Value = item.Id.ToString()
                    
                    });
                }

                _TypeSelectListItem.Add(new SelectListItem
                {
                    Text = "--請選擇--",
                    Value = null,
                    Selected = true
                });

                return _TypeSelectListItem;
            }
        }
    }
}
