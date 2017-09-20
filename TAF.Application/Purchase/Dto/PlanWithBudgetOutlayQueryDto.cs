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
        /// Name
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Pid
        /// </summary>
        public Guid? Pid
        {
            get; set;
        }

        /// <summary>
        /// Year
        /// </summary>
        public int? Year
        {
            get; set;
        }

    }
}



