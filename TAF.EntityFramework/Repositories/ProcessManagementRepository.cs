// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessManagementRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标过程管理仓储
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
    /// 投标过程管理仓储
    /// </summary>
    public class ProcessManagementRepository : TAFRepositoryBase<ProcessManagement, Guid>, IProcessManagementRepository
    {
        public ProcessManagementRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



