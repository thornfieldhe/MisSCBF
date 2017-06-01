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
        /// ProductName
        /// </summary>
        public string ProductName
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



