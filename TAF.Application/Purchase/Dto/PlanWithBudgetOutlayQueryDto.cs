// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanWithBudgetOutlayQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划预算关联表查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 采购计划预算关联表查询对象
    /// </summary>
    public class PlanWithBudgetOutlayQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// ProcurementPlanId
        /// </summary>
        public Guid? ProcurementPlanId
        {
            get; set;
        }        
        
        /// <summary>
        /// BudgetOutlayId
        /// </summary>
        public Guid? BudgetOutlayId
        {
            get; set;
        }        
    } 
}



