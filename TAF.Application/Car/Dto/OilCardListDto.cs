// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   油料卡列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 油料卡列表对象
    /// </summary>
    [AutoMap(typeof(OilCard))]
    public class OilCardListDto
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
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get; set;
        }        
        
        /// <summary>
        /// CarInfoName
        /// </summary>
        public string CarInfoName
        {
            get; set;
        }    
    } 
}



