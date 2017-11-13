// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStageInfoeAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购阶段应用接口
    /// </summary>
    public interface IStageInfoeAppService : IBaseEntityApplicationService
    {
        ListResultDto<StageInfoListDto> GetAll(StageInfoeQueryDto request);

        StageInfoEditDto Get(Guid id);

        Task SaveAsync(StageInfoEditDto input);

        void Delete(Guid id);
    }
}



