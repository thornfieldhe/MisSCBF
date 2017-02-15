namespace SCBF
{
    using System;
    using System.Collections.Generic;

    public class ProjectTask : TAFEntity
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 项目
        /// </summary>
        public virtual Project Project
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
        /// 日志
        /// </summary>
        public virtual List<DailyLog> DailyLogs
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

        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get; set;
        }
    }
}