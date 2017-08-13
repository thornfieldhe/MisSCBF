// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManHourRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修审批单仓储
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
    /// 车辆维修审批单仓储
    /// </summary>
    public class ManHourRepository : TAFRepositoryBase<ManHour, Guid>, IManHourRepository
    {
        public ManHourRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



