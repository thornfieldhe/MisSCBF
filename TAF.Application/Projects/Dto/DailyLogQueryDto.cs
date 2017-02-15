// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLogQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   工作日志查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 工作日志查询对象
    /// </summary>
    public class DailyLogQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// TaskId
        /// </summary>
        public Guid? TaskId
        {
            get; set;
        }

        /// <summary>
        /// DateFrom
        /// </summary>
        public DateTime? DateFrom
        {
            get; set;
        }

        /// <summary>
        /// DateTo
        /// </summary>
        public DateTime? DateTo
        {
            get; set;
        }

        /// <summary>
        /// ProjectId
        /// </summary>
        public Guid? ProjectId
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
        public int? TimeConsuming
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
        public int? Schedule
        {
            get; set;
        }
    }
}



