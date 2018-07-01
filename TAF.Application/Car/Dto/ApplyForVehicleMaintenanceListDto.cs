// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;
    using Abp.AutoMapper;

    /// <summary>
    /// 车辆送修申请单列表对象
    /// </summary>
    [AutoMap(typeof(ApplyForVehicleMaintenance))]
    public class ApplyForVehicleMaintenanceListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        public string Code { get; set; }

        /// <summary>
        /// 车辆型号
        /// </summary>
        public string Clxh
        {
            get; set;
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string Cph { get; set; }

        /// <summary>
        /// Killomiters
        /// </summary>
        public decimal Killomiters
        {
            get; set;
        }

        /// <summary>
        /// 维修单位
        /// </summary>
        public string ServiceDepot { get; set; }

        /// <summary>
        /// 维修单位Id
        /// </summary>
        public Guid? ServiceDepotId { get; set; }

        /// <summary>
        /// DriverId
        /// </summary>
        public Guid DriverId
        {
            get; set;
        }

        /// <summary>
        /// DriverName
        /// </summary>
        public string DriverName
        {
            get; set;
        }

        /// <summary>
        /// Date
        /// </summary>
        public string Date
        {
            get; set;
        }

        /// <summary>
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// Note2
        /// </summary>
        public string Note2
        {
            get; set;
        }

        /// <summary>
        /// Status
        /// </summary>
        public string Status
        {
            get; set;
        }
    }
}



