// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfo.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 采购阶段
    /// </summary>
    public class StageInfo : TAFEntity
    {
        /// <summary>
        /// 采购阶段
        /// </summary>
        public StageCategory Category { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public Guid Company { get; set; }

        /// <summary>
        /// 总费用
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 阶段状态 0：未提交，1：已提交
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 采购计划Id
        /// </summary>
        public Guid ProcurementPlanId { get; set; }

        /// <summary>
        /// 采购计划
        /// </summary>
        public virtual ProcurementPlan ProcurementPlan { get; set; }
    }
}