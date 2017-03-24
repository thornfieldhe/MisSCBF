// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   库存查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 库存查询对象
    /// </summary>
    public class StockQueryDto : PagedAndSortedResultRequestDto
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
        /// StorageId
        /// </summary>
        public Guid? StorageId
        {
            get; set;
        }        
    } 
}



