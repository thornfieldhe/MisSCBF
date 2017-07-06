// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardProofRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡消耗凭证单仓储
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
    /// 加油卡消耗凭证单仓储
    /// </summary>
    public class OilCardProofRepository : TAFRepositoryBase<OilCardProof, Guid>, IOilCardProofRepository
    {
        public OilCardProofRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



