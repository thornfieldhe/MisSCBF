// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceCheckQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   发票录入查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 发票录入查询对象
    /// </summary>
    public class InvoiceCheckQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// From
        /// </summary>
        public long? From
        {
            get; set;
        }        
        
        /// <summary>
        /// To
        /// </summary>
        public long? To
        {
            get; set;
        }        
    } 
}



