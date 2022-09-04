using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealOrder_Project.Models;

namespace MealOrder_Project.Tools
{
    // Generator or process orders

    public class OrdersGenerator
    {
        public DateTime Start { private get; set; }
        public DateTime End { private get; set; }
        public int Category { private get; set; }
        public int Type { private get; set; }
        public bool Sat { private get; set; }
        public bool Sun { private get; set; }        


        // 產生日期區間與判斷是否要排除假日
        private List<DateTime> DiffDateList()
        {
            // 計算天數差
            int _diffdate = End.Subtract(Start).Days;

            List<DateTime> _diffDateList = new List<DateTime>();

            // 產生日期的List
            for (int i = 0; i <= _diffdate; i ++)
            {                
                _diffDateList.Add(Start.AddDays(i));
            }

            //  判斷是否排除六日
            if (Sat)
            {
                _diffDateList.RemoveAll(m => m.DayOfWeek.Equals(DayOfWeek.Saturday));
            }

            if (Sun)
            {
                _diffDateList.RemoveAll(m => m.DayOfWeek.Equals(DayOfWeek.Sunday));
            }
            
            return _diffDateList;

        }

        private decimal categoryamount()
        {
            using (MyCompanyEntities db = new MyCompanyEntities())
            {             
                return db.MealCategory_Detail.Find(Category).Amount;
            }
        }

        // 產生訂單
        public List<MealOrders> NewOrders()
        {
            List<MealOrders> orders = new List<MealOrders>();
            
            decimal amount = categoryamount();

            foreach (var date in DiffDateList())
            {
                MealOrders order = new MealOrders
                {
                    Emp_Id = 1,
                    Category = Category,
                    Type = Type,
                    Amount = amount,
                    DiningDate = date,
                    Status = 0,
                    OrderingDatetime = DateTime.Now
                };

                orders.Add(order);
            }        

            return orders;
        }

    }
}
