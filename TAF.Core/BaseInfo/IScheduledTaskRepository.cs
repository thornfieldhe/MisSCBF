// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScheduledTaskRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.BaseInfo;
    
    /// <summary>
    /// 计划任务仓储接口
    /// </summary>
    public interface IScheduledTaskRepository : ITAFRepositoryBase<ScheduledTask>
    {

    }
}



