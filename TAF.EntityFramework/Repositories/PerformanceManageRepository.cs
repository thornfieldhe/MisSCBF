// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceManageRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   履约保证金管理仓储
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
    /// 履约保证金管理仓储
    /// </summary>
    public class PerformanceManageRepository : TAFRepositoryBase<PerformanceManage, Guid>, IPerformanceManageRepository
    {
        public PerformanceManageRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



