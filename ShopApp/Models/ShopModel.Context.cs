﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopEntities : DbContext
    {
        public ShopEntities()
            : base("name=ShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblColor> tblColors { get; set; }
        public virtual DbSet<tblModel> tblModels { get; set; }
        public virtual DbSet<tblNew> tblNews { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblStorage> tblStorages { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblOrderDetail> tblOrderDetails { get; set; }
        public virtual DbSet<tblContactU> tblContactUs { get; set; }
    }
}
