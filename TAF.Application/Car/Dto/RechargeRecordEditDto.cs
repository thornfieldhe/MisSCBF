// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RechargeRecordEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   油料分配记录编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 油料分配记录编辑对象
    /// </summary>
    [AutoMap(typeof(RechargeRecord))]
    public class RechargeRecordEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// OilCardId
        /// </summary>
        public Guid OilCardId
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
        /// HisAmount
        /// </summary>
        public decimal HisAmount
        {
            get; set;
        }
    }
}



