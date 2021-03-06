//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            this.tblOrderDetails = new HashSet<tblOrderDetail>();
        }
    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> ColorId { get; set; }
        public Nullable<int> ModelId { get; set; }
        public Nullable<int> StorageId { get; set; }
        public Nullable<System.DateTime> SellStartDate { get; set; }
        public Nullable<System.DateTime> SellEndDate { get; set; }
        public Nullable<int> IsNew { get; set; }
    
        public virtual tblCategory tblCategory { get; set; }
        public virtual tblColor tblColor { get; set; }
        public virtual tblModel tblModel { get; set; }
        public virtual tblStorage tblStorage { get; set; }
        public virtual tblUser tblUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderDetail> tblOrderDetails { get; set; }
    }
}
