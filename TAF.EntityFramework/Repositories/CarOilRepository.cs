// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarOilRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆油料核算表仓储
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
    /// 车辆油料核算表仓储
    /// </summary>
    public class CarOilRepository : TAFRepositoryBase<CarOil, Guid>, ICarOilRepository
    {
        public CarOilRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



