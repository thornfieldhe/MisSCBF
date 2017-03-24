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
    public class StockMap : EntityTypeConfiguration<Stock>
    {
        public StockMap()
        {
            this.HasRequired(r => r.Storage).WithMany(r => r.Stocks).HasForeignKey(r => r.StorageId);
            this.HasRequired(r => r.Product).WithMany(r => r.Stocks).HasForeignKey(r => r.ProductId);
        }
    }
}