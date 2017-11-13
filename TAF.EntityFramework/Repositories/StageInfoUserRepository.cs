// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoUserRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段用户仓储
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
    /// 采购阶段用户仓储
    /// </summary>
    public class StageInfoUserRepository : TAFRepositoryBase<StageInfoUser, Guid>, IStageInfoUserRepository
    {
        public StageInfoUserRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



