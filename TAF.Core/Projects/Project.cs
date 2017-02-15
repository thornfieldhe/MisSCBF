// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Product
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System.Collections.Generic;

    /// <summary>
    /// 项目
    /// </summary>
    public class Project : TAFEntity
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 项目目标
        /// </summary>
        public string Goal
        {
            get; set;
        }

        /// <summary>
        /// 任务项
        /// </summary>
        public virtual List<ProjectTask> Tasks
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
    }
}