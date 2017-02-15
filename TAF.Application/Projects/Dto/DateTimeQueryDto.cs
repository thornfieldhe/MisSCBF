// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLogSummaryQueryDto.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the DailyLogSummaryQueryDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects.Dto
{
    using System;

    public class DateTimeQueryDto
    {
        public DateTime? DateFrom
        {
            get; set;
        }

        public DateTime? DateTo
        {
            get; set;
        }
    }
}