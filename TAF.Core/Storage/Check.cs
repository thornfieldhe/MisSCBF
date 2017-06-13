// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Check.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Check
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;

    /// <summary>
    /// 盘点明细表
    /// </summary>
    public class Check : TAFEntity
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal StockAmount { get; set; }

        /// <summary>
        /// 盘点数量
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 盈亏原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 盈亏单位价值
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 盘点表Id
        /// </summary>
        public Guid CheckBillId
        {
            get; set;
        }

        /// <summary>
        /// 盘点表
        /// </summary>
        public virtual CheckBill CheckBill { get; set; }
    }
}