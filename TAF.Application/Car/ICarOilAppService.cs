// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICarOilAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆油料核算表应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using SCBF.Car.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 车辆油料核算表应用接口
    /// </summary>
    public interface ICarOilAppService : IBaseEntityApplicationService
    {
        ListResultDto<CarOilListDto> GetAll(CarOilQueryDto request);

        CarOilEditDto Get(Guid id);

        Task SaveAsync(CarOilEditDto input);

        void Delete(Guid id);
    }
}



