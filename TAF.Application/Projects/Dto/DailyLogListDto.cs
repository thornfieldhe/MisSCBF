// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLogListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   工作日志列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 工作日志列表对象
    /// </summary>
    [AutoMap(typeof(DailyLog))]
    public class DailyLogListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// TaskName
        /// </summary>
        public string TaskName
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
        /// ProjectName
        /// </summary>
        public string ProjectName
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
        public string ResponsiblePerson
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



