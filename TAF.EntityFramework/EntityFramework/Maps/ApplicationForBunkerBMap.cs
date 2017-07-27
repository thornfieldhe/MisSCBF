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
    public class ApplicationForBunkerBMap : EntityTypeConfiguration<ApplicationForBunkerB>
    {
        public ApplicationForBunkerBMap()
        {
            this.HasRequired(r => r.OctaneStore).WithMany(r => r.ApplicationForBunkerBs).HasForeignKey(r => r.AuditorId);
            this.HasOptional(r => r.Driver).WithMany(r => r.ApplicationForBunkerBs).HasForeignKey(r => r.DriverId);
            this.HasOptional(r => r.Auditor).WithMany(r => r.ApplicationForBunkerBs).HasForeignKey(r => r.AuditorId);
            this.HasRequired(r => r.CarInfo).WithMany(r => r.ApplicationForBunkerBs).HasForeignKey(r => r.CarInfoId);
        }
    }
}