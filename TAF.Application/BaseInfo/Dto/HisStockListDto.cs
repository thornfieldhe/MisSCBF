// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.AutoMapper;

    using SCBF.Storage;

    /// <summary>
    /// 计划任务列表对象
    /// </summary>
    [AutoMap(typeof(HisStock))]
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
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price
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
        public DateTime Date
        {
            get; set;
        }
    }
}



