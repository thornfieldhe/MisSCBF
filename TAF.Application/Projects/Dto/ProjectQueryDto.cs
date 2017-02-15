// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameQueryDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   NameQueryDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 项目查询
    /// </summary>
    public class ProjectQueryDto : PagedAndSortedResultRequestDto
    {
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 是否已完成
        /// </summary>
        public bool? IsCompleted
        {
            get; set;
        }

    }
}