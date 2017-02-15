// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLog.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Product
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using SCBF.Users;

    /// <summary>
    /// 工作日志
    /// </summary>
    public class DailyLog : TAFEntity
    {
        /// <summary>
        /// 任务Id
        /// </summary>
        public Guid TaskId
        {
            get; set;
        }

        /// <summary>
        /// 任务
        /// </summary>
        public virtual ProjectTask Task
        {
            get; set;
        }

        /// <summary>
        /// 日志日期
        /// </summary>
        public DateTime Date
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
        /// 备注
        /// </summary>
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// 负责人Id
        /// </summary>
        public long ResponsiblePersonId
        {
            get; set;
        }


        /// <summary>
        /// 负责人
        /// </summary>
        public virtual User ResponsiblePerson
        {
            get; set;
        }

        /// <summary>
        /// 耗时
        /// </summary>
        public int TimeConsuming
        {
            get; set;
        }

        /// <summary>
        /// 进度0-100
        /// </summary>
        public int Schedule
        {
            get; set;
        }
    }
}