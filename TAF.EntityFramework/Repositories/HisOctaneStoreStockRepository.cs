// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisOctaneStoreStockRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料加油审批单仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Car;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 实物油料加油审批单仓储
    /// </summary>
    public class HisOctaneStoreStockRepository : TAFRepositoryBase<HisCarStoreStock, Guid>, IHisOctaneStoreStockRepository
    {
        public HisOctaneStoreStockRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



