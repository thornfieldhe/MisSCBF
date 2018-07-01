// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarRepairTimeRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理仓储
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
    /// 车辆维修耗时管理仓储
    /// </summary>
    public class CarRepairTimeRepository : TAFRepositoryBase<CarRepairTime, Guid>, ICarRepairTimeRepository
    {
        public CarRepairTimeRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



