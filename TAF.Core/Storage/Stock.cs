// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stock.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Stock
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;

    using SCBF.BaseInfo;

    /// <summary>
    /// 库存
    /// </summary>
    public class Stock : TAFEntity
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


        public virtual SysDictionary Storage
        {
            get; set;
        }
    }
}