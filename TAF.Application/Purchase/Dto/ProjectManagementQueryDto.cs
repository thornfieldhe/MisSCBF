// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectManagementQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 采购过程管理查询对象
    /// </summary>
    public class ProjectManagementQueryDto : PagedAndSortedResultRequestDto
    {  

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            get; set;
        }
    }
}



