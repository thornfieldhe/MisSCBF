// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManHourMap.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ManHourMap
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity.ModelConfiguration;
using SCBF.Car;

namespace SCBF.EntityFramework.Maps
{
    /// <summary>
    /// 
    /// </summary>
    public class MaintenanceDeliveryMap : EntityTypeConfiguration<MaintenanceDelivery>
    {
        public MaintenanceDeliveryMap()
        {
            this.HasRequired(r => r.ApplyForVehicleMaintenance).WithMany(r => r.MaintenanceDeliveries).HasForeignKey(r => r.ApplyForVehicleMaintenanceId);
        }
    }
}