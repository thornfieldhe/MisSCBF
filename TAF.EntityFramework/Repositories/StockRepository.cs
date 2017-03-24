// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   库存仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Storage;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 库存仓储
    /// </summary>
    public class StockRepository : TAFRepositoryBase<Stock, Guid>, IStockRepository
    {
        public StockRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



