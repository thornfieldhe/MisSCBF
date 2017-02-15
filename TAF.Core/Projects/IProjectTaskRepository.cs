// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectTaskRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   项目任务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;

    /// <summary>
    /// 项目任务
    /// </summary>
    public interface IProjectTaskRepository : IRepository<ProjectTask, Guid>
    {

    }
}



