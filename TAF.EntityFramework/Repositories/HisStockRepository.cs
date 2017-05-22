// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockRepository.cs" company="" author="何翔华">
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
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;
    using SCBF.Storage;

    /// <summary>
    /// 计划任务仓储
    /// </summary>
    public class HisStockRepository : TAFRepositoryBase<HisStock, Guid>, IHisStockRepository
    {
        public HisStockRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



