// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLogSummaryDto.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the DailyLogSummaryDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using Abp.AutoMapper;

    [AutoMap(typeof(DailyLog))]
    public class DailyLogSummaryDto
    {
        public string Date
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }

        public string ResponsiblePerson
        {
            get; set;
        }

        public int TimeConsuming
        {
            get; set;
        }
    }
}