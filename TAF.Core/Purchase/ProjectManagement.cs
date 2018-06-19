// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectManagement.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   项目过程管理
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 项目过程管理
    /// </summary>
    public class ProjectManagement: TAFEntity
    {
        /// <summary>
        /// 招标计划Id
        /// </summary>
        public Guid PlanId { get; set; }

        /// <summary>
        /// 开工时间
        /// </summary>
        public DateTime Date1 { get; set; }

        /// <summary>
        /// 竣工时间
        /// </summary>
        public DateTime? Date2 { get; set; }

        /// <summary>
        /// 报审价
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// 是否已打印招标文件1:已录入开工时间,1:已录入竣工时间,2:已录入审计金额
        /// </summary>
        public int HasPrint { get; set; }
    }
}
