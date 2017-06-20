// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctaneStoreRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料库仓储
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
    /// 实物油料库仓储
    /// </summary>
    public class OctaneStoreRepository : TAFRepositoryBase<OctaneStore, Guid>, IOctaneStoreRepository
    {
        public OctaneStoreRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



