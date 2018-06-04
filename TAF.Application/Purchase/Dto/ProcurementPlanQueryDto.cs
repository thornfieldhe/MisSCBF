// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlanQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using SCBF.Finance;

namespace SCBF.Purchase.Dto
{

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 采购计划查询对象
    /// </summary>
    public class ProcurementPlanQueryDto : PagedAndSortedResultRequestDto
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
        /// 采购项目
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 责任部门
        /// </summary>
        public Guid? Department { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public Guid? User { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime? Date
        {
            get; set;
        }

        /// <summary>
        /// 关联的预算计划类型
        /// </summary>
        public BungetType? Type { get; set; }
    }
}



