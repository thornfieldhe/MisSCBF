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
        /// Category
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// ModuleId
        /// </summary>
        public Guid? ModuleId
        {
            get; set;
        }
    }
}



