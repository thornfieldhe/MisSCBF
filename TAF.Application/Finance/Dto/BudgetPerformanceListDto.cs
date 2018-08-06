// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetPerformanceListDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ReceiptListDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace SCBF.Finance.Dto
{
	/// <summary>
    /// 收入统计表
    /// </summary>
    public class BudgetPerformanceListDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 年度实际收入合计
        /// </summary>
        public decimal Total1 => this.Total2 + this.Total3 + this.Total4 + this.Total5;

        /// <summary>
        /// 年度实际收入向上请领标准经费
        /// </summary>
        public decimal Total2 { get; set; }

        /// <summary>
        /// 年度实际收入向上请领项目经费
        /// </summary>
        public decimal Total3 { get; set; }

        /// <summary>
        /// 年度实际收入经费弥补
        /// </summary>
        public decimal Total4 { get; set; }

        /// <summary>
        /// 年度实际收入上年结转
        /// </summary>
        public decimal Total5 { get; set; }

        /// <summary>
        /// 应执行预算数年初预算合计
        /// </summary>
        public decimal Total6 => this.Total7 + this.Total11 + this.Total15;

        /// <summary>
        /// 应执行预算数年初上报小计
        /// </summary>
        public decimal Total7 => this.Total8 + this.Total9 + this.Total10;

        /// <summary>
        /// 应执行预算数年初上报对下供应标准经费
        /// </summary>
        public decimal Total8 { get; set; }

        /// <summary>
        /// 应执行预算数年初上报对下供应项目经费
        /// </summary>
        public decimal Total9 { get; set; }

        /// <summary>
        /// 应执行预算数年初上报直接支出
        /// </summary>
        public decimal Total10 { get; set; }

        /// <summary>
        /// 应执行预算数年中调整小计
        /// </summary>
        public decimal Total11 => this.Total12 + this.Total13 + this.Total14;

        /// <summary>
        /// 应执行预算数年中调整调整支出
        /// </summary>
        public decimal Total12 { get; set; }

        /// <summary>
        /// 应执行预算数年中调整对下追加标准经费
        /// </summary>
        public decimal Total13 { get; set; }

        /// <summary>
        /// 应执行预算数年中调整对下追加项目经费
        /// </summary>
        public decimal Total14 { get; set; }

        /// <summary>
        /// 应执行预算数调整后支出小计
        /// </summary>
        public decimal Total15 => this.Total16 + this.Total17 + this.Total18;

        /// <summary>
        /// 应执行预算数调整后支出调整支出
        /// </summary>
        public decimal Total16 { get; set; }


        /// <summary>
        /// 应执行预算数调整后对下追加标准经费
        /// </summary>
        public decimal Total17 { get; set; }

        /// <summary>
        /// 应执行预算数调整后对下追加项目经费
        /// </summary>
        public decimal Total18 { get; set; }

        /// <summary>
        /// 实际支出
        /// </summary>
        public decimal Total19
        {
            get; set;
        }

        /// <summary>
        /// 预算执行结余
        /// </summary>
        public decimal Total20 => decimal.Round(this.Total6 - this.Total19, 2, MidpointRounding.AwayFromZero);

        /// <summary>
        /// 预算执行完成率
        /// </summary>
        public decimal Total21 => this.Total6 == 0 ? 0 : decimal.Round(this.Total19 / this.Total6 * 100, 2, MidpointRounding.AwayFromZero);

        /// <summary>
        /// 实际科目结余
        /// </summary>
        public decimal Total22 { get; set; }

        /// <summary>
        /// 结余使用合计
        /// </summary>
        public decimal Total23 => this.Total24 + this.Total25;

        /// <summary>
        /// 结余使用家底
        /// </summary>
        public decimal Total24
        {
            get; set;
        }

        /// <summary>
        /// 结余使用下年
        /// </summary>
        public decimal Total25 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get; set;
        }

    }
}