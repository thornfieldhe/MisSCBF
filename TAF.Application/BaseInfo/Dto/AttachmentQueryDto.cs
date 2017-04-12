// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachmentQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   附件查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;
    using System.Collections.Generic;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 附件查询对象
    /// </summary>
    public class AttachmentQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get; set;
        }        
        
        /// <summary>
        /// Size
        /// </summary>
        public decimal? Size
        {
            get; set;
        }        
        
        /// <summary>
        /// Path
        /// </summary>
        public string Path
        {
            get; set;
        }        
        
        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// ModuleIds
        /// </summary>
        public List<Guid> ModuleIds
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
    } 
}



