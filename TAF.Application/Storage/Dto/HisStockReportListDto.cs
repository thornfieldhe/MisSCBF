// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStoreReport.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   HisStoreReport
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

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

        /// <summary>
        /// 仓库
        /// </summary>
        public string StorageName
        {
            get; set;
        }

        public string ProductName { get; set; }

        public string Unit { get; set; }

        public string Specifications { get; set; }

        public string Price1 { get; set; }

        public string Total1 { get; set; }

        public string Amount1 { get; set; }

        public string Price2 { get; set; }

        public string Total2 { get; set; }

        public string Amount2 { get; set; }

        public string Price3 { get; set; }

        public string Total3 { get; set; }

        public string Amount3 { get; set; }

        public string Price4 { get; set; }

        public string Total4 { get; set; }

        public string Amount4 { get; set; }

        public string Note { get; set; }

        public string Date { get; set; }

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
        Inital = 0,
        /// <summary>
        /// 增加数
        /// </summary>
        Add = 1,
        /// <summary>
        /// 减少数
        /// </summary>
        Reduce = 2,
        /// <summary>
        /// 期末数
        /// </summary>
        End = 3
    }
}