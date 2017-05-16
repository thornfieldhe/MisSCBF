// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledTaskListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 计划任务列表对象
    /// </summary>
    [AutoMap(typeof(ScheduledTask))]
    public class ScheduledTaskListDto
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
        /// Started
        /// </summary>
        public string Started
        {
            get; set;
        }        
        
        /// <summary>
        /// Schedule
        /// </summary>
        public string Schedule
        {
            get; set;
        }        
    } 
}



