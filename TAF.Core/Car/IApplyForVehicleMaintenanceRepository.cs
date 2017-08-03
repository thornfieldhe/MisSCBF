// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplyForVehicleMaintenanceRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Car;
    
    /// <summary>
    /// 车辆送修申请单仓储接口
    /// </summary>
    public interface IApplyForVehicleMaintenanceRepository : ITAFRepositoryBase<ApplyForVehicleMaintenance>
    {

    }
}



