// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entry.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Entry
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;

    /// <summary>
    /// 入库单
    /// </summary>
    public class Entry : TAFEntity
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
        /// 规则:RK20170308001
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
        /// 是否是特殊入库
        /// </summary>
        public bool IsSpecial
        {
            get; set;
        }


    }
}