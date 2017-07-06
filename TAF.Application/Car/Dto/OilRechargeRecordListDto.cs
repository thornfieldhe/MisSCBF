// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilRechargeRecordListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料入库单列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 实物油料入库单列表对象
    /// </summary>
    [AutoMap(typeof(OilRechargeRecord))]
    public class OilRechargeRecordListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// OctanceName
        /// </summary>
        public string OctanceStore
        {
            get; set;
        }

        /// <summary>
        /// OctanceName
        /// </summary>
        public string Rating
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
        /// Date
        /// </summary>
        public DateTime Date
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
        public string AttachmentName
        {
            get; set;
        }

        /// <summary>
        /// AttachmentPath
        /// </summary>
        public string AttachmentPath
        {
            get; set;
        }
    }
}


