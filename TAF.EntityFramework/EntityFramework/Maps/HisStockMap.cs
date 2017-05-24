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
    public class HisStockMap : EntityTypeConfiguration<HisStock>
    {
        public HisStockMap()
        {
            this.HasRequired(r => r.Product).WithMany(r => r.HisStocks).HasForeignKey(r => r.ProductId);
            this.HasRequired(r => r.Storage).WithMany(r => r.HisStocks).HasForeignKey(r => r.ProductId);
        }
    }
}