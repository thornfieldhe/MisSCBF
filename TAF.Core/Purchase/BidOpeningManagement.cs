// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BidOpeningManagement.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   开标管理
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 开标管理
    /// </summary>
    public class BidOpeningManagement: TAFEntity
    {
        /// <summary>
        /// 招标计划Id
        /// </summary>
        public Guid PlanId { get; set; }

        /// <summary>
        /// 是否已打印招标文件0:未打印,1:已打印,2:已结束
        /// </summary>
        public int HasPrint { get; set; }

        /// <summary>
        /// 复审专家
        /// </summary>
        public Guid ExpertId { get; set; }

        /// <summary>
        /// 中标人
        /// </summary>
        public string SuccessfulTender { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal Price { get; set; }
    }
}
