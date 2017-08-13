// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManHour.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   工时
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace SCBF.Car
{
    /// <summary>
    /// 工时
    /// </summary>
    public class ManHour : TAFEntity
    {
        /// <summary>
        /// 维修单据Id
        /// </summary>
        public Guid ApplyForVehicleMaintenanceId { get; set; }

        public virtual ApplyForVehicleMaintenance ApplyForVehicleMaintenance { get; set; }

        /// <summary>
        /// 部件Id
        /// </summary>
        public Guid PartId { get; set; }

        /// <summary>
        /// 工时Id
        /// </summary>
        public Guid ManHourId { get; set; }

        /// <summary>
        /// 预算工时
        /// </summary>
        public decimal Hours1 { get; set; }

        /// <summary>
        /// 结算工时
        /// </summary>
        public decimal Hours2 { get; set; }
    }
}