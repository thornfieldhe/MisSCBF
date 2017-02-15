// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectTaskEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   项目任务查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 项目任务查询对象
    /// </summary>
    public class ProjectTaskQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// ProjectId
        /// </summary>
        public Guid? ProjectId
        {
            get; set;
        }

        /// <summary>
        /// IsCompleted
        /// </summary>
        public bool? IsCompleted
        {
            get; set;
        }
    }
}



