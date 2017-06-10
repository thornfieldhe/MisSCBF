// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OutlayQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   财务查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 财务查询对象
    /// </summary>
    public class OutlayQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// Year
        /// </summary>
        public int? Year
        {
            get; set;
        }        
        
        /// <summary>
        /// Total1
        /// </summary>
        public decimal? Total1
        {
            get; set;
        }        
        
        /// <summary>
        /// Total2
        /// </summary>
        public decimal? Total2
        {
            get; set;
        }        
        
        /// <summary>
        /// Total3
        /// </summary>
        public decimal? Total3
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
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }        
    } 
}



