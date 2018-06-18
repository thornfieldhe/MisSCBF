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
        public Guid PerformanceManageId { get; set; }

        /// <summary>
        /// 扣除金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 情况说明
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }
    }
}
