// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqManagerRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   会质量评价体系仓储
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
    /// 会质量评价体系仓储
    /// </summary>
    public class EqManagerRepository : TAFRepositoryBase<EqManager, Guid>, IEqManagerRepository
    {
        public EqManagerRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



