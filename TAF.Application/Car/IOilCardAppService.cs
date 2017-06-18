// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOilCardAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   油料卡应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TAF.Utility;

    /// <summary>
    /// 油料卡应用接口
    /// </summary>
    public interface IOilCardAppService : IBaseEntityApplicationService
    {
        ListResultDto<OilCardListDto> GetAll(OilCardQueryDto request);

        List<KeyValue<string, Guid>> GetSimple();

        decimal GetAmount(Guid id);

        OilCardEditDto Get(Guid id);

        Task SaveAsync(OilCardEditDto input);

        void Delete(Guid id);
    }
}



