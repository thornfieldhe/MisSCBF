// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenance.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ApplyForVehicleMaintenance
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace SCBF.Car
{
    using System;

    /// <summary>
    /// 车辆维修申请
    /// </summary>
    public class ApplyForVehicleMaintenance : TAFEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 车辆Id
        /// </summary>
        public Guid CarInfoId { get; set; }

        /// <summary>
        /// 车辆
        /// </summary>
        public virtual CarInfo CarInfo { get; set; }

        /// <summary>
        /// 行驶公里数
        /// </summary>
        public decimal Killomiters { get; set; }

        /// <summary>
        /// 驾驶员Id
        /// </summary>
        public Guid DriverId { get; set; }

        /// <summary>
        /// 故障描述
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 车场日鉴定意见
        /// </summary>
        public string Note2 { get; set; }

        /// <summary>
        /// 维修厂意见
        /// </summary>
        public string Note3 { get; set; }

        /// <summary>
        /// 审核状态AuditingStatus
        /// </summary>
        public int Status { get; set; }

        public virtual List<ManHour> ManHours { get; set; }

        public virtual List<MaintenanceDelivery> MaintenanceDeliveries { get; set; }

        public virtual List<ServicingMaterial> ServicingMaterials { get; set; }
        
    }
}