// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualOutlayMap.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ActualOutlayMap
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EntityFramework
{
    using SCBF.Car;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// 
    /// </summary>
    public class ApplyForVehicleMaintenanceMap : EntityTypeConfiguration<ApplyForVehicleMaintenance>
    {
        public ApplyForVehicleMaintenanceMap()
        {
            this.HasRequired(r => r.CarInfo).WithMany(r => r.ApplyForVehicleMaintenances).HasForeignKey(r => r.CarInfoId);
        }
    }
}