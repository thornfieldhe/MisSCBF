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

    using SCBF.BaseInfo;

    /// <summary>
    /// 出库
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


        public virtual Product Product
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Unit
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
        /// 金额
        /// </summary>

        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// 出库单据Id
        /// </summary>
        public Guid DeliveryBillId
        {
            get; set;
        }


        public virtual DeliveryBill DeliveryBill
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