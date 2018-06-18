// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceAmountDetails.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   履约保证金扣除明细
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 履约保证金扣除明细
    /// </summary>
    public class PerformanceAmountDetail: TAFEntity
    {
        /// <summary>
        /// 履约管理Id
        /// </summary>
        public Guid PerformanceId { get; set; }

        /// <summary>
        /// 扣除金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 扣除原因
        /// </summary>
        public string Note { get; set; }
    }
}
