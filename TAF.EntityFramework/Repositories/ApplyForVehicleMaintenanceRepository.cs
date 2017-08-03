// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单仓储
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
    /// 车辆送修申请单仓储
    /// </summary>
    public class ApplyForVehicleMaintenanceRepository : TAFRepositoryBase<ApplyForVehicleMaintenance, Guid>, IApplyForVehicleMaintenanceRepository
    {
        public ApplyForVehicleMaintenanceRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



