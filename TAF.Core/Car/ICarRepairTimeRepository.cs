// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICarRepairTimeRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Car;
    
    /// <summary>
    /// 车辆维修耗时管理仓储接口
    /// </summary>
    public interface ICarRepairTimeRepository : ITAFRepositoryBase<CarRepairTime>
    {

    }
}



