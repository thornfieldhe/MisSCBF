// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoBudgetOutlayRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段预计支出仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;
    using Abp.EntityFramework;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;
    using SCBF.Purchase;

    /// <summary>
    /// 采购阶段预计支出仓储
    /// </summary>
    public class StageInfoBudgetOutlayRepository : TAFRepositoryBase<StageInfoBudgetOutlay, Guid>, IStageInfoBudgetOutlayRepository
    {
        public StageInfoBudgetOutlayRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



