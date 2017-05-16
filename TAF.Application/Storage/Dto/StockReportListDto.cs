// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockReportListDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   StockReportListDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class StockReportListDto
    {
        /// <summary>
        /// 品名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 商品单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specifications
        {
            get; set;
        }

        /// <summary>
        /// 期初数数量
        /// </summary>
        public decimal Amount1 { get; set; }

        /// <summary>
        /// 增加数数量
        /// </summary>
        public decimal Amount2 { get; set; }

        /// <summary>
        /// 结余数数量
        /// </summary>
        public decimal Amount3 { get; set; }

        /// <summary>
        /// 期初数单价
        /// </summary>
        public decimal Price1 { get; set; }

        /// <summary>
        /// 增加数单价
        /// </summary>
        public decimal Price2 { get; set; }

        /// <summary>
        /// 结余数单价
        /// </summary>
        public decimal Price3 { get; set; }

        /// <summary>
        /// 期初数价值
        /// </summary>
        public decimal Total1 { get; set; }

        /// <summary>
        /// 增加数价值
        /// </summary>
        public decimal Total2 { get; set; }

        /// <summary>
        /// 结余数价值
        /// </summary>
        public decimal Total3 { get; set; }

    }
}