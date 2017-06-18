// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerARepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡申请加油审批单仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Car;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 加油卡申请加油审批单仓储
    /// </summary>
    public class ApplicationForBunkerARepository : TAFRepositoryBase<ApplicationForBunkerA, Guid>, IApplicationForBunkerARepository
    {
        public ApplicationForBunkerARepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



