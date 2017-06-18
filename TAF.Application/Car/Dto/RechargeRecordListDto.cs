// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RechargeRecordListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   油料分配记录列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 油料分配记录列表对象
    /// </summary>
    [AutoMap(typeof(RechargeRecord))]
    public class RechargeRecordListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }        
        
        /// <summary>
        /// OilCardName
        /// </summary>
        public string OilCardName
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
        
        /// <summary>
        /// Date
        /// </summary>
        public string Date
        {
            get; set;
        }        
    } 
}



