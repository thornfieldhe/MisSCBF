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
    using SCBF.Storage;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// 
    /// </summary>
    public class CheckMap : EntityTypeConfiguration<Check>
    {
        public CheckMap()
        {
            this.HasRequired(r => r.Product).WithMany(r => r.Checks).HasForeignKey(r => r.ProductId);
        }
    }
}