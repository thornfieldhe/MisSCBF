// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStoreReport.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   HisStoreReport
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 历史报表列表
    /// </summary>
    public class HisStockReportListDto
    {
        public Guid ProductId { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public Guid StorageId
        {
            get; set;
        }

        public string ProductName { get; set; }

        public string Unit { get; set; }

        public string Specifications { get; set; }

        public decimal Price1 { get; set; }

        public decimal Total1 { get; set; }

        public decimal Amount1 { get; set; }

        public decimal Price2 { get; set; }

        public decimal Total2 { get; set; }

        public decimal Amount2 { get; set; }

        public decimal Price3 { get; set; }

        public decimal Total3 { get; set; }

        public decimal Amount3 { get; set; }

        public string Note { get; set; }

        public HisStoreReportCategory Category { get; set; }
    }

    /// <summary>
    /// 季度报表枚举
    /// </summary>
    public enum HisStoreReportCategory
    {
        /// <summary>
        /// 期初数
        /// </summary>
        Inital,
        /// <summary>
        /// 增加数
        /// </summary>
        Add,
        /// <summary>
        /// 期末数
        /// </summary>
        End
    }
}