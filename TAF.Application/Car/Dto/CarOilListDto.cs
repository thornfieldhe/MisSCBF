// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarOilListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆油料核算表列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 车辆油料核算表列表对象
    /// </summary>
    [AutoMap(typeof(CarOil))]
    public class CarOilListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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
        
        /// <summary>
        /// Kilometres
        /// </summary>
        public decimal Kilometres
        {
            get; set;
        }        
        
        /// <summary>
        /// Year
        /// </summary>
        public int Year
        {
            get; set;
        }        
        
        /// <summary>
        /// Month
        /// </summary>
        public int Month
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
    } 
}



