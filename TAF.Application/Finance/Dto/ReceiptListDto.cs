// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReceiptListDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ReceiptListDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance.Dto
{
    using System;

    /// <summary>
    /// 预算执行情况表
    /// </summary>
    public class ReceiptListDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 预算收入合计
        /// </summary>
        public decimal Total2
        {
            get { return this.Total3 + this.Total10 + this.Total17; }
        }

        /// <summary>
        /// 年初收入小计
        /// </summary>
        public decimal Total3
        {
            get
            {
                return this.Total4 + this.Total7 + this.Total8 + this.Total9;
            }
        }

        /// <summary>
        /// 年初收入向上请领小计
        /// </summary>
        public decimal Total4
        {
            get
            {
                return this.Total5 + this.Total6;
            }
        }

        /// <summary>
        /// 年初收入向上请领标准经费
        /// </summary>
        public decimal Total5 { get; set; }

        /// <summary>
        /// 年初收入向上请领项目经费
        /// </summary>
        public decimal Total6 { get; set; }

        /// <summary>
        /// 年初收入留用经费弥补
        /// </summary>
        public decimal Total7 { get; set; }

        /// <summary>
        /// 年初收入上年结转
        /// </summary>
        public decimal Total8 { get; set; }

        /// <summary>
        /// 年初收入当年预算外收入
        /// </summary>
        public decimal Total9 { get; set; }

        /// <summary>
        /// 预算调整合计
        /// </summary>
        public decimal Total10
        {
            get { return this.Total11 + this.Total14 + this.Total15 + this.Total16; }
        }

        /// <summary>
        /// 预算调整向上请领小计
        /// </summary>
        public decimal Total11
        {
            get { return this.Total12 + this.Total13; }
        }

        /// <summary>
        /// 预算调整向上请领标准经费
        /// </summary>
        public decimal Total12 { get; set; }

        /// <summary>
        /// 预算调整向上请领项目经费
        /// </summary>
        public decimal Total13 { get; set; }

        /// <summary>
        /// 预算调整留用经费弥补
        /// </summary>
        public decimal Total14 { get; set; }

        /// <summary>
        /// 预算调整上年结转
        /// </summary>
        public decimal Total15 { get; set; }

        /// <summary>
        /// 预算调整当年预算外收入
        /// </summary>
        public decimal Total16 { get; set; }

        /// <summary>
        /// 调整后升级增加小计
        /// </summary>
        public decimal Total17
        {
            get
            {
                return this.Total18 + this.Total19;
            }
        }

        /// <summary>
        /// 调整后增加标准经费
        /// </summary>
        public decimal Total18 { get; set; }

        /// <summary>
        /// 调整后增加项目经费
        /// </summary>
        public decimal Total19 { get; set; }

        /// <summary>
        /// 实际收入合计
        /// </summary>
        public decimal Total20
        {
            get
            {
                return this.Total24 + this.Total25 + this.Total26;
            }
        }

        /// <summary>
        /// 实际收入向上请领小计
        /// </summary>
        public decimal Total21 => this.Total22 + this.Total23;

        /// <summary>
        /// 实际收入向上请领标准经费
        /// </summary>
        public decimal Total22 => this.Total5 + this.Total12 + this.Total18;

        /// <summary>
        /// 实际收入向上请领项目经费
        /// </summary>
        public decimal Total23 => this.Total6 + this.Total13 + this.Total19;

        /// <summary>
        /// 实际收入留用经费弥补
        /// </summary>
        public decimal Total24 => this.Total7 + this.Total14;

        /// <summary>
        /// 实际收入上年结转
        /// </summary>
        public decimal Total25 => this.Total8 + this.Total15;

        /// <summary>
        /// 实际收入预算外收入
        /// </summary>
        public decimal Total26 { get; set; }

        /// <summary>
        /// 收入完成率
        /// </summary>
        public decimal Total27 => this.Total3 == 0 ? 0 : decimal.Round(this.Total20 / this.Total3, 2, MidpointRounding.AwayFromZero);
    }
}