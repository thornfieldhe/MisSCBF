using System;
using Abp.AutoMapper;
using SCBF.Finance;

namespace SCBF.Purchase.Dto
{
    [AutoMap(typeof(BudgetOutlay))]
    public class BudgetOutlaySummaryDto
    {

        /// <summary>
        /// 关联预算收入Id
        /// </summary>
        public Guid BudgetReceiptId
        {
            get; set;
        }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit
        {
            get; set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 财务编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// 单价或金额标准或支出限额
        /// </summary>
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal Totale => this.Price * this.Amount;
    }
}