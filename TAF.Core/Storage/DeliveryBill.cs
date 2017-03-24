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
    using System.Collections.Generic;

    /// <summary>
    /// 出库单
    /// </summary>
    public class DeliveryBill : TAFEntity
    {
        /// <summary>
        /// 出库单据号
        /// 规则:CK20170308001
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
        /// 是否是特殊出库
        /// </summary>
        public bool IsSpecial
        {
            get; set;
        }


        public virtual List<Delivery> Deliveries
        {
            get; set;
        }
    }
}