// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiddingManagementListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   招标文件管理列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 招标文件管理列表对象
    /// </summary>
    [AutoMap(typeof(BiddingManagement))]
    public class BiddingManagementListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// PlanId
        /// </summary>
        public Guid PlanId
        {
            get; set;
        }

        /// <summary>
        /// PlanName
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Mode
        /// </summary>
        public string Mode
        {
            get; set;
        }

        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// 招标代理机构
        /// </summary>
        public string BiddingAgency { get; set; }


        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 项目最高造价
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// 开标时间
        /// </summary>
        public string PlanDateEnd { get; set; }
    }
}



