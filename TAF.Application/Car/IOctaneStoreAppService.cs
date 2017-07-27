// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOctaneStoreAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料库应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// 实物油料库应用接口
    /// </summary>
    public interface IOctaneStoreAppService : IBaseEntityApplicationService
    {
        ListResultDto<OctaneStoreListDto> GetAll(OctaneStoreQueryDto request);

        OctaneStoreEditDto Get(Guid id);

        Task SaveAsync(OctaneStoreEditDto input);

        void Delete(Guid id);

        List<TAF.Utility.KeyValue<string, Guid>> GetSimple();

        decimal GetAmount(Guid id);
    }
}



