// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using Abp.AutoMapper;
    using SCBF.Storage;
    using System;

    /// <summary>
    /// 计划任务列表对象
    /// </summary>
    public class HisStockListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// ProductName
        /// </summary>
        public string ProductName
        {
            get; set;
        }

        /// <summary>
        /// ProductName
        /// </summary>
        public string Specifications
        {
            get; set;
        }

        /// <summary>
        /// Amount
        /// </summary>
        public string Amount
        {
            get; set;
        }

        /// <summary>
        /// Price
        /// </summary>
        public string Price
        {
            get; set;
        }

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }
        /// <summary>
        /// ProductCode
        /// </summary>
        public string ProductCode
        {
            get; set;
        }

        /// <summary>
        /// Total
        /// </summary>
        public string Total
        {
            get; set;
        }
        /// <summary>
        /// StorageName
        /// </summary>
        public string StorageName
        {
            get; set;
        }

        /// <summary>
        /// Date
        /// </summary>
        public string Date
        {
            get; set;
        }

        public string User { get; set; }


        public HisStoreReportCategory Category { get; set; }
    }
}



