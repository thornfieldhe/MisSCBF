// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledTask.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ScheduledTask
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System.Collections.Generic;

    /// <summary>
    /// 计划任务
    /// </summary>
    public class ScheduledTask : TAFEntity
    {
        /// <summary>
        /// 计划名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 计划是否已启动
        /// </summary>
        public bool Started { get; set; }

        /// <summary>
        /// 计划间隔
        /// </summary>
        public string Schedule { get; set; }
        
    }
}