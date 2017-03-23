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
    public class EntryBillMap : EntityTypeConfiguration<EntryBill>
    {
        public EntryBillMap()
        {
            this.HasRequired(r => r.Storage).WithMany(r => r.EntryBills).HasForeignKey(r => r.StorageId);
        }
    }
}