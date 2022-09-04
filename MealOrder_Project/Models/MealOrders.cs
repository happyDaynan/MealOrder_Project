//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MealOrder_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MealOrders
    {
        public int Id { get; set; }
        public Nullable<int> Emp_Id { get; set; }
        public int Category { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime OrderingDatetime { get; set; }
        public System.DateTime DiningDate { get; set; }
    
        public virtual Company_Status_Detail Company_Status_Detail { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual MealType_Detail MealType_Detail { get; set; }
        public virtual MealCategory_Detail MealCategory_Detail { get; set; }
    }
}
