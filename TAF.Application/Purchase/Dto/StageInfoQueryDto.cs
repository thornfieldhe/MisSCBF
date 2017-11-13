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
    public class StageInfoQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// 采购阶段
        /// </summary>
        public StageCategory Category
        {
            get; set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        public Guid? Company
        {
            get; set;
        }

        /// <summary>
        /// 阶段状态 0：未提交，1：已提交
        /// </summary>
        public int? Status
        {
            get; set;
        }

        /// <summary>
        /// 关联采购计划
        /// </summary>
        public Guid? ProcurementPlanId
        {
            get; set;
        }
    }
}



