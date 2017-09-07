// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanWithBudgetOutlayListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划预算关联表列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 采购计划预算关联表列表对象
    /// </summary>
    [AutoMap(typeof(PlanWithBudgetOutlay))]
    public class PlanWithBudgetOutlayListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }        
        
        /// <summary>
        /// ProcurementPlanName
        /// </summary>
        public string ProcurementPlanName
        {
            get; set;
        }    
        
        /// <summary>
        /// BudgetOutlayName
        /// </summary>
        public string BudgetOutlayName
        {
            get; set;
        }    
    } 
}



