// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledTaskRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.BaseInfo;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 计划任务仓储
    /// </summary>
    public class ScheduledTaskRepository : TAFRepositoryBase<ScheduledTask, Guid>, IScheduledTaskRepository
    {
        public ScheduledTaskRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



