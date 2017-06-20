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
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using SCBF.Car.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 实物油料库应用接口
    /// </summary>
    public interface IOctaneStoreAppService : IBaseEntityApplicationService
    {
        ListResultDto<OctaneStoreListDto> GetAll(OctaneStoreQueryDto request);

        OctaneStoreEditDto Get(Guid id);

        Task SaveAsync(OctaneStoreEditDto input);

        void Delete(Guid id);
    }
}



