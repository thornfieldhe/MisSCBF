// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetOutlayRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   支出预算仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Finance;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 支出预算仓储
    /// </summary>
    public class BudgetOutlayRepository : TAFRepositoryBase<BudgetOutlay, Guid>, IBudgetOutlayRepository
    {
        public BudgetOutlayRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



