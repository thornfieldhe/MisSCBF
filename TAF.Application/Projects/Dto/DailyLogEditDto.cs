// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLogEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   工作日志编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 工作日志编辑对象
    /// </summary>
    [AutoMap(typeof(DailyLog))]
    public class DailyLogEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// TaskId
        /// </summary>
        public Guid TaskId
        {
            get; set;
        }

        /// <summary>
        /// Date
        /// </summary>
        public string Date
        {
            get; set;
        }

        /// <summary>
        /// ProjectId
        /// </summary>
        public Guid ProjectId
        {
            get; set;
        }

        /// <summary>
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// TimeConsuming
        /// </summary>
        public int TimeConsuming
        {
            get; set;
        }

        /// <summary>
        /// ResponsiblePersonId
        /// </summary>
        public long ResponsiblePersonId
        {
            get; set;
        }

        /// <summary>
        /// Schedule
        /// </summary>
        public int Schedule
        {
            get; set;
        }
    }
}



