// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectManagementRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Purchase;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 采购过程管理仓储
    /// </summary>
    public class ProjectManagementRepository : TAFRepositoryBase<ProjectManagement, Guid>, IProjectManagementRepository
    {
        public ProjectManagementRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



