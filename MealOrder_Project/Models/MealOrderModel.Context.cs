﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyCompanyEntities : DbContext
    {
        public MyCompanyEntities()
            : base("name=MyCompanyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company_Status> Company_Status { get; set; }
        public virtual DbSet<Company_Status_Detail> Company_Status_Detail { get; set; }
        public virtual DbSet<MealCategory_Detail> MealCategory_Detail { get; set; }
        public virtual DbSet<MealOrders> MealOrders { get; set; }
        public virtual DbSet<MealType_Detail> MealType_Detail { get; set; }
    }
}