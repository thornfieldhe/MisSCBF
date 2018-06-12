// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TendererRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标人管理仓储
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
    /// 投标人管理仓储
    /// </summary>
    public class TendererRepository : TAFRepositoryBase<Tenderer, Guid>, ITendererRepository
    {
        public TendererRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



