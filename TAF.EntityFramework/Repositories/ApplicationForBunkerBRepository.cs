// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerBRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料加油审批单仓储
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
    /// 实物油料加油审批单仓储
    /// </summary>
    public class ApplicationForBunkerBRepository : TAFRepositoryBase<ApplicationForBunkerB, Guid>, IApplicationForBunkerBRepository
    {
        public ApplicationForBunkerBRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



