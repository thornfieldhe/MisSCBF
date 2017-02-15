// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductListDto.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ProductListDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System;

    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Project))]
    public class ProjectListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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

        /// <summary>
        /// 进度
        /// </summary>
        public string Schedule
        {
            get; set;
        }

        /// <summary>
        /// 是否已完成
        /// </summary>
        public string IsCompleted
        {
            get; set;
        }

        /// <summary>
        /// 任务项
        /// </summary>
        public int TaskItems
        {
            get; set;
        }
    }
}