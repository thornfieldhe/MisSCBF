// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlan.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划表
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using SCBF.Finance;

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 采购计划表
    /// </summary>
    public class ProcurementPlan : TAFEntity
    {
        /// <summary>
        /// 采购类别 ProcurementPlanCategory
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 采购方式 ProcurementPlanMode
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 关联的预算计划类型
        /// </summary>
        public BungetType Type { get; set; }

        /// <summary>
        /// 采购项目
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 采购时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 责任部门
        /// </summary>
        public Guid Department { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public Guid User { get; set; }

        public virtual List<PlanWithBudgetOutlay> PlanWithBudgetOutlays { get; set; }

        public virtual List<StageInfo> StageInfos { get; set; }

    }
}