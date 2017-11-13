// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoActualOutlayRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段实际支出仓储
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
    /// 采购阶段实际支出仓储
    /// </summary>
    public class StageInfoActualOutlayRepository : TAFRepositoryBase<StageInfoActualOutlay, Guid>, IStageInfoActualOutlayRepository
    {
        public StageInfoActualOutlayRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



