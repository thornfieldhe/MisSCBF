// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlanRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   年度采购计划仓储
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
    /// 年度采购计划仓储
    /// </summary>
    public class ProcurementPlanRepository : TAFRepositoryBase<ProcurementPlan, Guid>, IProcurementPlanRepository
    {
        public ProcurementPlanRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



