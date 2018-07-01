// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICarInfoAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆信息应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using SCBF.Car.Dto;
    using TAF.Utility;

    /// <summary>
    /// 车辆信息应用接口
    /// </summary>
    public interface ICarInfoAppService : IBaseEntityApplicationService
    {
        ListResultDto<CarInfoListDto> GetAll(CarInfoQueryDto request);

        List<KeyValue<string, Guid>> GetSimple();

        CarInfoEditDto Get(Guid id);

        Task SaveAsync(CarInfoEditDto input);

        void Delete(Guid id);

        void ModifyStatus();
    }
}



