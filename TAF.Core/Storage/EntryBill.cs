// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryBill.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   EntryBill
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;
    using System.Collections.Generic;

    using SCBF.BaseInfo;

    /// <summary>
    /// 入库单
    /// </summary>
    public class EntryBill : TAFEntity
    {

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

        /// <summary>
        /// 入库单据号
        /// 规则:RK20170308001
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// Note
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

        public virtual List<Entry> Entries
        {
            get; set;
        }
    }
}