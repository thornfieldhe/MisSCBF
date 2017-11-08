namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 阶段计划支出关联表
    /// </summary>
    public class StageInfoBudgetOutlay : TAFEntity
    {
        public Guid StageInfoId { get; set; }

        public Guid BudgetOutlayId { get; set; }
    }
}