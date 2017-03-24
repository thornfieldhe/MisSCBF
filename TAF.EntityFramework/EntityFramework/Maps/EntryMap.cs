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
    public class EntryMap : EntityTypeConfiguration<Entry>
    {
        public EntryMap()
        {
            this.HasRequired(r => r.EntryBill).WithMany(r => r.Entries).HasForeignKey(r => r.EntryBillId);
            this.HasRequired(r => r.Product).WithMany(r => r.Entries).HasForeignKey(r => r.ProductId);
            this.HasRequired(r => r.Storage).WithMany(r => r.Entries).HasForeignKey(r => r.StorageId);
        }
    }
}