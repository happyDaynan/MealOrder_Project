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
    
    public partial class Company_Status
    {
        public int Id { get; set; }
        public int Class_Id { get; set; }
        public int Status_Id { get; set; }
    
        public virtual Company_Status_Detail Company_Status_Detail { get; set; }
    }
}
