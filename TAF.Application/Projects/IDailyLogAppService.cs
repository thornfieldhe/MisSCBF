// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDailyLogAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   工作日志应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects
{
    using System.Collections.Generic;

    using SCBF.Projects.Dto;

    /// <summary>
    /// 工作日志应用接口
    /// </summary>
    public interface IDailyLogAppService : IDefaultEntityApplicationService<DailyLogListDto, DailyLogEditDto, DailyLogQueryDto>
    {
        List<ProjectSummaryDto> GetDailyLogs(DateTimeQueryDto query);
    }
}



