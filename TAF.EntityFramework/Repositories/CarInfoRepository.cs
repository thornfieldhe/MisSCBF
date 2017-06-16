// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarInfoRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆信息仓储
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
    /// 车辆信息仓储
    /// </summary>
    public class CarInfoRepository : TAFRepositoryBase<CarInfo, Guid>, ICarInfoRepository
    {
        public CarInfoRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



