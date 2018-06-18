// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceAmountDetailRepository.cs" company="" author="何翔华">
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
    public class PerformanceAmountDetailRepository : TAFRepositoryBase<PerformanceAmountDetail, Guid>, IPerformanceAmountDetailRepository
    {
        public PerformanceAmountDetailRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



