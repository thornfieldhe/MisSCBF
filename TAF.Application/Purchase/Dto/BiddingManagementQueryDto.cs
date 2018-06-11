// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiddingManagementQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   招标文件管理查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 招标文件管理查询对象
    /// </summary>
    public class BiddingManagementQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 采购类别:ProcurementPlanCategory
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// 采购方式
        /// </summary>
        public string Mode
        {
            get; set;
        }

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// BiddingAgencyId
        /// </summary>
        public Guid? BiddingAgencyId
        {
            get; set;
        }
    }
}



