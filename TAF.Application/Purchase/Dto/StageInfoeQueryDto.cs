// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoeQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 采购阶段查询对象
    /// </summary>
    public class StageInfoeQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// Category
        /// </summary>
        public int? Category
        {
            get; set;
        }

        /// <summary>
        /// Company
        /// </summary>
        public Guid? Company
        {
            get; set;
        }

        /// <summary>
        /// Cost
        /// </summary>
        public decimal? Cost
        {
            get; set;
        }

        /// <summary>
        /// Status
        /// </summary>
        public int? Status
        {
            get; set;
        }

        /// <summary>
        /// ProcurementPlanId
        /// </summary>
        public Guid? ProcurementPlanId
        {
            get; set;
        }
    }
}



