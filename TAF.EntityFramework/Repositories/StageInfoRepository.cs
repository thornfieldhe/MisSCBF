// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoeRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段仓储
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
    /// 采购阶段仓储
    /// </summary>
    public class StageInfoRepository : TAFRepositoryBase<StageInfo, Guid>, IStageInfoRepository
    {
        public StageInfoRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



