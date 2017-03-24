// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryMap.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   EntryMap
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EntityFramework
{
    using System.Data.Entity.ModelConfiguration;

    using SCBF.Storage;

    /// <summary>
    /// 
    /// </summary>
    public class DeliveryMap : EntityTypeConfiguration<Delivery>
    {
        public DeliveryMap()
        {
            this.HasRequired(r => r.DeliveryBill).WithMany(r => r.Deliveries).HasForeignKey(r => r.DeliveryBillId);
            this.HasRequired(r => r.Product).WithMany(r => r.Deliveries).HasForeignKey(r => r.ProductId);
            this.HasRequired(r => r.Storage).WithMany(r => r.Deliveries).HasForeignKey(r => r.StorageId);
        }
    }
}