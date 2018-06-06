// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanWithBudgetOutlayEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划预算关联表编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 采购计划预算关联表编辑对象
    /// </summary>
    [AutoMap(typeof(PlanWithBudgetOutlay))]
    public class PlanWithBudgetOutlayEditDto
    {
        /// <summary>
        /// PurchaseId
        /// </summary>
        public Guid ProcurementPlanId
        {
            get; set;
        }

        /// <summary>
        /// BudgetOutlayId
        /// </summary>
        public Guid BudgetOutlayId
        {
            get; set;
        }
    }
}



