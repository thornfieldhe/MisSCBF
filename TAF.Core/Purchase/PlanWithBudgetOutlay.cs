namespace SCBF.Purchase
{
    using System;

    using SCBF.Finance;

    /// <summary>
    /// 采购计划与年度预算关联表
    /// </summary>
    public class PlanWithBudgetOutlay : TAFEntity
    {
        public Guid ProcurementPlanId { get; set; }

        public virtual ProcurementPlan ProcurementPlan { get; set; }

        public Guid BudgetOutlayId { get; set; }

        public virtual BudgetOutlay BudgetOutlay { get; set; }

        /// <summary>
        /// 关联的预算计划类型
        /// </summary>
        public BungetType Type { get; set; }
    }
}