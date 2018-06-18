// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceManage.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   履约管理
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace SCBF.Purchase
{
    /// <summary>
    /// 履约管理
    /// </summary>
    public class PerformanceManage: TAFEntity
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
        /// 保证金金额
        /// </summary>
        public decimal MarginAmount { get; set; }

        /// <summary>
        /// 没收通知
        /// </summary>
        public string Note { get; set; }

    }
}
