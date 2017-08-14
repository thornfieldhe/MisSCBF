// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepairCost.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   维修费用
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace SCBF.Car
{
    /// <summary>
    /// 维修费用
    /// </summary>
    public class RepairCost : TAFEntity
    {
        /// <summary>
        /// 费用类型
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 费用发生年
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 维修审批表Id
        /// </summary>
        public Guid ApplyForVehicleMaintenanceId { get; set; }
    }
}