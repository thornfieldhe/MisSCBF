// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 计划任务查询对象
    /// </summary>
    public class HisStockQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// ProductId
        /// </summary>
        public Guid? ProductId
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
        
        /// <summary>
        /// Price
        /// </summary>
        public decimal? Price
        {
            get; set;
        }        
        
        /// <summary>
        /// StorageId
        /// </summary>
        public Guid? StorageId
        {
            get; set;
        }        
        
        /// <summary>
        /// DateFrom
        /// </summary>
        public DateTime? DateFrom
        {
            get; set;
        } 
        
        /// <summary>
        /// DateTo
        /// </summary>
        public DateTime? DateTo
        {
            get; set;
        }  
    } 
}



