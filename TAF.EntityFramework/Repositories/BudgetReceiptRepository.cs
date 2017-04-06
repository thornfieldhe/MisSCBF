// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetReceiptRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   年度预算收入仓储
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
    /// 年度预算收入仓储
    /// </summary>
    public class BudgetReceiptRepository : TAFRepositoryBase<BudgetReceipt, Guid>, IBudgetReceiptRepository
    {
        public BudgetReceiptRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



