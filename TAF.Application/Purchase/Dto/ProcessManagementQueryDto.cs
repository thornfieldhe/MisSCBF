// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessManagementQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   投标过程管理查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 投标过程管理查询对象
    /// </summary>
    public class ProcessManagementQueryDto : PagedAndSortedResultRequestDto
    {

        public Guid? ProcurementPlanId {get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get; set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        public Guid? Unit
        {
            get; set;
        }
    }
}



