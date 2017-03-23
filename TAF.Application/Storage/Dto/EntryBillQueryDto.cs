// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryBillQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   入库单查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 入库单查询对象
    /// </summary>
    public class EntryBillQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// StorageId
        /// </summary>
        public Guid? StorageId
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
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }        
        
        /// <summary>
        /// IsSpecial
        /// </summary>
        public bool? IsSpecial
        {
            get; set;
        }        
    } 
}



