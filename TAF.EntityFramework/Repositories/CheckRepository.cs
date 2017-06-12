// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   盘点仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Storage;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 盘点仓储
    /// </summary>
    public class CheckRepository : TAFRepositoryBase<Check, Guid>, ICheckRepository
    {
        public CheckRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



