// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   盘点查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 盘点查询对象
    /// </summary>
    public class CheckQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// ProductId
        /// </summary>
        public Guid? ProductId
        {
            get; set;
        }        
        
        /// <summary>
        /// StockAmount
        /// </summary>
        public decimal? StockAmount
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
        /// ChangedAmount
        /// </summary>
        public decimal? ChangedAmount
        {
            get; set;
        }        
        
        /// <summary>
        /// Reason
        /// </summary>
        public string Reason
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
    } 
}



