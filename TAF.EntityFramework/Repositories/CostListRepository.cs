// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CostListRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   造价清单管理仓储
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
    /// 造价清单管理仓储
    /// </summary>
    public class CostListRepository : TAFRepositoryBase<CostList, Guid>, ICostListRepository
    {
        public CostListRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



