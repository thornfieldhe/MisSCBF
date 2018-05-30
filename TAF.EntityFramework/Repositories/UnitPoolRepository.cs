// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitPoolRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   模块附件关联仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.BaseInfo;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 模块附件关联仓储
    /// </summary>
    public class UnitPoolRepository : TAFRepositoryBase<UnitPool, Guid>, IUnitPoolRepository
    {
        public UnitPoolRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



