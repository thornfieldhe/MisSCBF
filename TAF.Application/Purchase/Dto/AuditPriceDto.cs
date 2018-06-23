// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditPriceDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   审计金额汇总
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    /// <summary>
    /// 审计金额汇总
    /// </summary>
    public class AuditPriceDto
    {
        public Guid ProjectId { get; set; }

        /// <summary>
        /// 报审价
        /// </summary>
        public decimal Price0 { get; set; }

        /// <summary>
        /// 剩余资金
        /// </summary>
        public decimal Price1 { get; set; }

        /// <summary>
        /// 审定金额
        /// </summary>
        public decimal Price2 { get; set; }

        /// <summary>
        /// 审计费
        /// </summary>
        public decimal Price3 { get; set; }

        /// <summary>
        /// 质量保证金
        /// </summary>
        public decimal Price4 { get; set; }
        /// <summary>
        /// 应付尾款
        /// </summary>
        public decimal Price5 { get; set; }

        /// <summary>
        /// 审增减率
        /// </summary>
        public decimal Price6 { get; set; }

        /// <summary>
        /// 打印状态
        /// </summary>
        public int HasPrint { get; set; }

    }
}
