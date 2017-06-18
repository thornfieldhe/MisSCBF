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
    using SCBF.Car;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// 
    /// </summary>
    public class ApplicationForBunkerAMap : EntityTypeConfiguration<ApplicationForBunkerA>
    {
        public ApplicationForBunkerAMap()
        {
            this.HasRequired(r => r.OilCard).WithMany(r => r.ApplicationForBunkerAs).HasForeignKey(r => r.OilCardId);
            this.HasOptional(r => r.Driver).WithMany(r => r.ApplicationForBunkerAs).HasForeignKey(r => r.DriverId);
            this.HasOptional(r => r.Auditor).WithMany(r => r.ApplicationForBunkerAs).HasForeignKey(r => r.AuditorId);
        }
    }
}