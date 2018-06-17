// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BidOpeningManagementQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   开标管理查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 开标管理查询对象
    /// </summary>
    public class BidOpeningManagementQueryDto : PagedAndSortedResultRequestDto
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
        /// SuccessfulTender
        /// </summary>
        public string SuccessfulTender
        {
            get; set;
        }
    }
}



