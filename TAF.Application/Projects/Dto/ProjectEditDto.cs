// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductEditDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ProductEditDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;

    /// <summary>
    /// 项目编辑对象
    /// </summary>
    [AutoMap(typeof(Project))]
    public class ProjectEditDto
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 项目目标
        /// </summary>
        [Required]
        public string Goal
        {
            get; set;
        }

        /// <summary>
        /// 是否已完成
        /// </summary>
        public bool IsCompleted
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
        /// 任务项
        /// </summary>
        public int TaskItems
        {
            get; set;
        }
    }
}