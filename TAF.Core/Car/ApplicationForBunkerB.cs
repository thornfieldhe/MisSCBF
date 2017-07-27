// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerB.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ApplicationForBunkerB
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using SCBF.BaseInfo;
    using System;

    /// <summary>
    /// 实物油料加油审批单
    /// </summary>
    public class ApplicationForBunkerB : TAFEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 油料库Id
        /// </summary>
        public Guid OctaneStoreId { get; set; }

        /// <summary>
        /// 加油库
        /// </summary>
        public virtual OctaneStore OctaneStore { get; set; }

        /// <summary>
        /// 申请加油升数
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 库存量
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 审核升数
        /// </summary>
        public decimal AuditingAmount { get; set; }

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


        public Guid CarInfoId { get; set; }

        public virtual CarInfo CarInfo { get; set; }



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