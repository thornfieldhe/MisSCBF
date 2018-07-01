// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarRepairTime.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆修理耗时
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace SCBF.Car
{
    /// <summary>
    /// 车辆修理耗时
    /// </summary>
    public class CarRepairTime : TAFEntity
    {
        /// <summary>
        /// 部件Id
        /// </summary>
        public Guid PartId { get;  set; }

        /// <summary>
        /// 维修单Id
        /// </summary>
        public Guid ApplyForVehicleMaintenanceId
        {
            get; set;
        }

        /// <summary>
        /// 维修厂Id
        /// </summary>
        public Guid ServiceDepotId
        {
            get; set;
        }

        /// <summary>
        /// 车辆Id
        /// </summary>
        public Guid CatInfoId { get; set; }

        /// <summary>
        /// 维修时间起
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// 维修时间止
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// 维修耗时
        /// </summary>
        public decimal Hours { get; set; }

        /// <summary>
        /// 工时Id
        /// </summary>
        public Guid ManHourId { get; set; }
    }
}
