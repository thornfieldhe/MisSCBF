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
    public class ManHourMap : EntityTypeConfiguration<ManHour>
    {
        public ManHourMap()
        {
            this.HasRequired(r => r.ApplyForVehicleMaintenance).WithMany(r => r.ManHours).HasForeignKey(r => r.ApplyForVehicleMaintenanceId);
        }
    }
}