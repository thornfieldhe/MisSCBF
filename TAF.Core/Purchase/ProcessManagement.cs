// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessManagement.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   流程管理
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 流程管理
    /// </summary>
    public class ProcessManagement : TAFEntity
    {
        /// <summary>
        /// 采购项目Id
        /// </summary>
        public Guid PurchaseId { get; set; }

        /// <summary>
        /// 流程类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public Guid Unit { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public ProcessStatus Status { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public int Year { get; set; }

    }
}
