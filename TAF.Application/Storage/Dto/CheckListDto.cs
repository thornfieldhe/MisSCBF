// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   盘点列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 盘点列表对象
    /// </summary>
    [AutoMap(typeof(Check))]
    public class CheckListDto
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
        /// ProductCode
        /// </summary>
        public string ProductCode
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
        /// 规格
        /// </summary>
        public string Specifications
        {
            get; set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get; set;
        }

        /// <summary>
        /// StockAmount
        /// </summary>
        public decimal StockAmount
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
        /// ChangedAmount
        /// </summary>
        public decimal ChangedAmount
        {
            get; set;
        }

        /// <summary>
        /// Reason
        /// </summary>
        public string Reason
        {
            get; set;
        }

        /// <summary>
        /// Year
        /// </summary>
        public int Year
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
    }
}



