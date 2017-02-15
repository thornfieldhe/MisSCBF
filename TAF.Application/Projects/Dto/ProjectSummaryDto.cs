// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectSummaryDto.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ProjectSummaryDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System.Collections.Generic;

    using Abp.AutoMapper;

    [AutoMap(typeof(Project))]
    public class ProjectSummaryDto
    {
        public string Name
        {
            get; set;
        }

        public bool IsCompleted
        {
            get; set;
        }

        public string Schedule
        {
            get; set;
        }

        public string Goal
        {
            get; set;
        }

        public List<ProjectTaskSummaryDto> Tasks
        {
            get; set;
        }
    }
}