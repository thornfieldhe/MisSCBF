// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLogRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   工作日志仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;

    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 工作日志仓储
    /// </summary>
    public class DailyLogRepository : TAFRepositoryBase<DailyLog, Guid>, IDailyLogRepository
    {
        public DailyLogRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



