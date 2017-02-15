// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectTaskEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   项目任务列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 项目任务列表对象
    /// </summary>
    [AutoMap(typeof(ProjectTask))]
    public class ProjectTaskListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get; set;
        }

        /// <summary>
        /// 进度
        /// </summary>
        public string Schedule
        {
            get; set;
        }
    }
}



