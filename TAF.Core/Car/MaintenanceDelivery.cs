// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaintenanceDeliveries.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   维修出库单
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SCBF.Storage;

namespace SCBF.Car
{
    using System;

    /// <summary>
    /// 维修出库单
    /// </summary>
    public class MaintenanceDelivery : TAFEntity
    {
        /// <summary>
        /// 维修单据Id
        /// </summary>
        public Guid ApplyForVehicleMaintenanceId { get; set; }

        public virtual ApplyForVehicleMaintenance ApplyForVehicleMaintenance { get; set; }

        /// <summary>
        /// 出库单据Id
        /// </summary>
        public Guid DeliveryId { get; set; }

    }
}