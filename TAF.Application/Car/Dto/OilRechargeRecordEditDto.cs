// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilRechargeRecordEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料入库单编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 实物油料入库单编辑对象
    /// </summary>
    [AutoMap(typeof(OilRechargeRecord))]
    public class OilRechargeRecordEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// OctanceId
        /// </summary>
        public Guid OctanceId
        {
            get; set;
        }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount
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
        /// AttachmentId
        /// </summary>
        public string AttachmentId
        {
            get; set;
        }

        /// <summary>
        /// StoreId
        /// </summary>
        public Guid StoreId
        {
            get; set;
        }
    }
}



