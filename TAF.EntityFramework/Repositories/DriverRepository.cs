// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriverRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   驾驶员仓储
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
    /// 驾驶员仓储
    /// </summary>
    public class DriverRepository : TAFRepositoryBase<Driver, Guid>, IDriverRepository
    {
        public DriverRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



