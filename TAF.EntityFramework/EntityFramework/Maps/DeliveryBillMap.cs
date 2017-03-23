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
    public class DeliveryBillMap : EntityTypeConfiguration<DeliveryBill>
    {
        public DeliveryBillMap()
        {
            this.HasRequired(r => r.Storage).WithMany(r => r.DeliveryBills).HasForeignKey(r => r.StorageId);
        }
    }
}