// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarOilQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆油料核算表查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 车辆油料核算表查询对象
    /// </summary>
    public class CarOilQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// CarInfoId
        /// </summary>
        public Guid? CarInfoId
        {
            get; set;
        }        
        
        /// <summary>
        /// Kilometres
        /// </summary>
        public decimal? Kilometres
        {
            get; set;
        }        
        
        /// <summary>
        /// Year
        /// </summary>
        public int? Year
        {
            get; set;
        }        
        
        /// <summary>
        /// Month
        /// </summary>
        public int? Month
        {
            get; set;
        }        
        
        /// <summary>
        /// Amount
        /// </summary>
        public decimal? Amount
        {
            get; set;
        }        
    } 
}



