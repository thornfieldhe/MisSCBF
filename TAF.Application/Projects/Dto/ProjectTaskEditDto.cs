// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectTaskEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   项目任务编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;
    using Abp.Runtime.Validation;

    /// <summary>
    /// 项目任务编辑对象
    /// </summary>
    [AutoMap(typeof(ProjectTask))]
    public class ProjectTaskEditDto : ICustomValidate
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 项目Id
        /// </summary>
        public Guid ProjectId
        {
            get; set;
        }

        /// <summary>
        /// 进度
        /// </summary>
        public int Schedule
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get; set;
        }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (Schedule > 100 || Schedule < 0)
            {
                context.Results.Add(new ValidationResult("进度只能在0-100之间！"));
            }

        }
    }
}



