﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   库存列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 库存列表对象
    /// </summary>
    [AutoMap(typeof(Stock))]
    public class StockChangeListDto
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
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// Unit
        /// </summary>
        public string Unit
        {
            get; set;
        }

        /// <summary>
        /// Specifications
        /// </summary>
        public string Specifications
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
    }
}



