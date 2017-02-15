// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectTaskRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   项目任务仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;

    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 项目任务仓储
    /// </summary>
    public class ProjectTaskRepository : TAFRepositoryBase<ProjectTask, Guid>, IProjectTaskRepository
    {
        public ProjectTaskRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



