// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiddingManagement.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   招标管理
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace SCBF.Purchase
{
    /// <summary>
    /// 招标管理
    /// </summary>
    public class BiddingManagement: TAFEntity
    {
        /// <summary>
        /// 招标计划Id
        /// </summary>
        public Guid PlanId { get; set; }

        /// <summary>
        /// 是否已打印招标文件
        /// </summary>
        public bool HasPrint { get; set; }

        /// <summary>
        /// 招标代理机构
        /// </summary>
        public Guid BiddingAgencyId { get; set; }

        /// <summary>
        /// 评审专家
        /// </summary>
        public Guid ExpertId { get; set; }

        /// <summary>
        /// 招标时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 文件发售时间起
        /// </summary>
        public DateTime PlanDateFrom { get; set; }

        /// <summary>
        /// 文件发售时间止
        /// </summary>
        public DateTime PlanDateTo { get; set; }

        /// <summary>
        /// 投标截至时间
        /// </summary>
        public DateTime PlanDateEnd { get;  set; }

        /// <summary>
        /// 项目最高造价
        /// </summary>
        public decimal Total { get;  set; }

        /// <summary>
        /// 工期
        /// </summary>
        public int Schedule { get; set; }

    }
}
