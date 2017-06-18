// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   油料卡仓储
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
    /// 油料卡仓储
    /// </summary>
    public class OilCardRepository : TAFRepositoryBase<OilCard, Guid>, IOilCardRepository
    {
        public OilCardRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



