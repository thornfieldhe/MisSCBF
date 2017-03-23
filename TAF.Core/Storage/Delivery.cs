// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Delivery.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Delivery
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;

    /// <summary>
    /// 出库单
    /// </summary>
    public class Delivery : TAFEntity
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public Guid ProductId
        {
            get; set;
        }

        /// <summary>
        /// 入库量
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public Guid StorageId
        {
            get; set;
        }

        /// <summary>
        /// 入库单据号
        /// 规则:CK20170308001
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get; set;
        }


        /// <summary>
        /// 是否是特殊出库
        /// </summary>
        public bool IsSpecial
        {
            get; set;
        }
    }
}