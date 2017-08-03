// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarInfo.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   CarInfo
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using SCBF.BaseInfo;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 车辆信息
    /// </summary>
    public class CarInfo : TAFEntity
    {
        /// <summary>
        /// 车辆型号
        /// </summary>
        public string Clxh { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        public string Cjh { get; set; }

        /// <summary>
        /// 发动机号
        /// </summary>
        public string Fdjh { get; set; }

        /// <summary>
        /// 油料标号
        /// </summary>
        public Guid? OctaneRatingId { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string Cph { get; set; }

        /// <summary>
        /// 基础公里数
        /// </summary>
        public decimal Jcgls { get; set; }

        /// <summary>
        /// 装备时间
        /// </summary>
        public DateTime Zbsj { get; set; }

        /// <summary>
        /// 整备资料
        /// </summary>
        public string Zbzl { get; set; }

        /// <summary>
        /// 行驶证号
        /// </summary>
        public string Xszh { get; set; }

        /// <summary>
        /// 油箱限额
        /// </summary>
        public decimal Yxxe { get; set; }

        /// <summary>
        /// 车辆状况
        /// </summary>
        public Guid ClzkId { get; set; }

        /// <summary>
        /// 车辆状况
        /// </summary>
        public virtual SysDictionary Clzk { get; set; }

        /// <summary>
        /// 驾驶员Id
        /// </summary>
        public Guid? DriverId { get; set; }

        /// <summary>
        /// 夏季油耗
        /// </summary>
        public decimal? OilWearSummer { get; set; }

        /// <summary>
        /// 冬季油耗
        /// </summary>
        public decimal? OilWearWinter { get; set; }

        /// <summary>
        /// 驾驶员
        /// </summary>
        public virtual Driver Driver { get; set; }

        /// <summary>
        /// 油料卡
        /// </summary>
        public virtual List<OilCard> OilCards { get; set; }

        /// <summary>
        /// 实物油料加油记录
        /// </summary>
        public virtual List<ApplicationForBunkerB> ApplicationForBunkerBs { get; set; }

        /// <summary>
        /// 车辆维修记录
        /// </summary>
        public virtual List<ApplyForVehicleMaintenance> ApplyForVehicleMaintenances { get; set; }

    }
}