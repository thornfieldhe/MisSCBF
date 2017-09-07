// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanWithBudgetOutlayRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划预算关联表仓储
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
    /// 采购计划预算关联表仓储
    /// </summary>
    public class PlanWithBudgetOutlayRepository : TAFRepositoryBase<PlanWithBudgetOutlay, Guid>, IPlanWithBudgetOutlayRepository
    {
        public PlanWithBudgetOutlayRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



