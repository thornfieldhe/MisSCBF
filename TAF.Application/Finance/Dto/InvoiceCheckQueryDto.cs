// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceCheckQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   发票录入查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.Application.Services.Dto;

namespace SCBF.Finance.Dto
{
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



