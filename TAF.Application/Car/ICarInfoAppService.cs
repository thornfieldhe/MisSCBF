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
    using System.Threading.Tasks;
    
    using SCBF.Car.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 车辆信息应用接口
    /// </summary>
    public interface ICarInfoAppService : IBaseEntityApplicationService
    {
        ListResultDto<CarInfoListDto> GetAll(CarInfoQueryDto request);

        CarInfoEditDto Get(Guid id);

        Task SaveAsync(CarInfoEditDto input);

        void Delete(Guid id);
    }
}



