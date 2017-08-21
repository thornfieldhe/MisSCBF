// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehicleMaintenanceReportDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   年度车辆维修情况表
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    /// <summary>
    /// 年度车辆维修情况表
    /// </summary>
    public class VehicleMaintenanceReportDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string Cph { get; set; }

        /// <summary>
        /// 装备时间
        /// </summary>
        public string Zbsj { get; set; }

        /// <summary>
        /// 维修凭证号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 预计工时费
        /// </summary>
        public decimal Ysgsf { get; set; }

        /// <summary>
        /// 实际工时费
        /// </summary>
        public decimal Sjgsf { get; set; }

        /// <summary>
        /// 预计维修材料费
        /// </summary>
        public decimal Ysclf { get; set; }

        /// <summary>
        /// 实际维修材料费
        /// </summary>
        public decimal Sjclf { get; set; }

        /// <summary>
        /// 自有材料费
        /// </summary>
        public decimal Zyclf { get; set; }

        /// <summary>
        /// 故障描述
        /// </summary>
        public string Note { get; set; }
    }
}