// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BidOpeningManagementEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   开标管理编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 开标管理编辑对象
    /// </summary>
    [AutoMap(typeof(BidOpeningManagement))]
    public class BidOpeningManagementEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
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
        /// HasPrint
        /// </summary>
        public int HasPrint
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
        /// ExpertId
        /// </summary>
        public Guid ExpertId
        {
            get; set;
        }

        /// <summary>
        /// 评审专家姓名
        /// </summary>
        public string ExpertName { get; set; }

        /// <summary>
        /// SuccessfulTender
        /// </summary>
        public List<string>  SuccessfulTender
        {
            get; set;
        }
        
        /// <summary>
        /// 合同金额
        /// </summary>
        public string Price { get; set; }
    }
}



