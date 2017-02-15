// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDailyLogRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   工作日志仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;

    /// <summary>
    /// 工作日志仓储接口
    /// </summary>
    public interface IDailyLogRepository : IRepository<DailyLog, Guid>
    {

    }
}



