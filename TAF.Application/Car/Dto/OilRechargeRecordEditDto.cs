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
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;

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
        public Guid Amount
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
    } 
}



