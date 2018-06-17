// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BidOpeningManagementListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   开标管理列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 开标管理列表对象
    /// </summary>
    [AutoMap(typeof(BidOpeningManagement))]
    public class BidOpeningManagementListDto
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
        /// Code
        /// </summary>
        public string Code
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
        /// SuccessfulTender
        /// </summary>
        public string SuccessfulTender
        {
            get; set;
        }
    }
}



