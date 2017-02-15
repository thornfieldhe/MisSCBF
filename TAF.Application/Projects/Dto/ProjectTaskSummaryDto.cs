namespace SCBF.Projects.Dto
{
    using System.Collections.Generic;

    using Abp.AutoMapper;

    [AutoMap(typeof(ProjectTask))]
    public class ProjectTaskSummaryDto
    {
        public string Name
        {
            get; set;
        }

        public int Schedule
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }

        public List<DailyLogSummaryDto> DailyLogs
        {
            get; set;
        }
    }
}