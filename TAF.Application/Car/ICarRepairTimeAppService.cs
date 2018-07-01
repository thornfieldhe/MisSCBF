// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICarRepairTimeAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace SCBF.Car
{
    using SCBF.Car.Dto;

    /// <summary>
    /// 车辆维修耗时管理应用接口
    /// </summary>
    public interface ICarRepairTimeAppService : IBaseEntityApplicationService
    {
        List<CarRepairTimeListDto> GetAll(CarRepairTimeQueryDto request);
    }
}



