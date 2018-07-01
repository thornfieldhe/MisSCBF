// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;
    using Abp.AutoMapper;

    /// <summary>
    /// 车辆送修申请单编辑对象
    /// </summary>
    [AutoMap(typeof(ApplyForVehicleMaintenance))]
    public class ApplyForVehicleMaintenanceEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        public string Code { get; set; }

        /// <summary>
        /// CarInfoId
        /// </summary>
        public Guid CarInfoId
        {
            get; set;
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string Cph { get; set; }

        /// <summary>
        /// 车辆型号
        /// </summary>
        public string Clxh { get; set; }

        /// <summary>
        /// Killomiters
        /// </summary>
        public decimal Killomiters
        {
            get; set;
        }

        /// <summary>
        /// 维修单位Id
        /// </summary>
        public Guid? ServiceDepotId { get; set; }

        /// <summary>
        /// 维修单位
        /// </summary>
        public string ServiceDepot { get; set; }

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
        /// Note3
        /// </summary>
        public string Note3
        {
            get; set;
        }

        /// <summary>
        /// Status
        /// </summary>
        public int Status
        {
            get; set;
        }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal? TotalPrice { get; set; }

        /// <summary>
        /// 修理类型
        /// </summary>
        public string RepairType { get; set; }
        /// <summary>
        /// 修理类型
        /// </summary>
        public string RepairTypeName { get; set; }
    }
}



