// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilRechargeRecord.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   OilRechargeRecord
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;

    /// <summary>
    /// 油料入库单
    /// </summary>
    public class OilRechargeRecord : TAFEntity
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 油库Id
        /// </summary>
        public Guid OctanceId { get; set; }

        /// <summary>
        /// 油库
        /// </summary>
        public virtual OctaneStore Octance { get; set; }

        /// <summary>
        /// 入库量
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 附件Id
        /// </summary>
        public string AttachmentId { get; set; }
    }
}