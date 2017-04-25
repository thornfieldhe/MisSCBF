// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualOutlayRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实际支出仓储
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
    /// 实际支出仓储
    /// </summary>
    public class ActualOutlayRepository : TAFRepositoryBase<ActualOutlay, Guid>, IActualOutlayRepository
    {
        public ActualOutlayRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



