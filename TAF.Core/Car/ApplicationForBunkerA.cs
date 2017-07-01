// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerA.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ApplicationForBunkerA
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using SCBF.BaseInfo;
    using System;

    /// <summary>
    /// 加油卡申请加油审批单
    /// </summary>
    public class ApplicationForBunkerA : TAFEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 加油卡Id
        /// </summary>
        public Guid OilCardId { get; set; }

        /// <summary>
        /// 加油卡
        /// </summary>
        public virtual OilCard OilCard { get; set; }

        /// <summary>
        /// 申请金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 卡内余额
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 审核金额
        /// </summary>
        public decimal AuditingAmount { get; set; }

        /// <summary>
        /// 确认金额
        /// </summary>
        public decimal ConfirmAmount { get; set; }

        /// <summary>
        /// 驾驶员Id
        /// </summary>
        public Guid? DriverId { get; set; }

        /// <summary>
        /// 驾驶员
        /// </summary>
        public virtual Driver Driver { get; set; }

        /// <summary>
        /// 审核者Id
        /// </summary>
        public Guid? AuditorId { get; set; }

        /// <summary>
        /// 审核者
        /// </summary>
        public virtual SysDictionary Auditor { get; set; }


        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}