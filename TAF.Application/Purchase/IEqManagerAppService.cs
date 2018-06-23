// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEqManagerAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   质量评价体系应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 质量评价体系应用接口
    /// </summary>
    public interface IEqManagerAppService : IBaseEntityApplicationService
    {
        ListResultDto<EqManagerListDto> GetAll(EqManagerQueryDto request);

        EqManagerEditDto Get(Guid id);

        Task SaveAsync(EqManagerEditDto input);

        void Delete(Guid id);
    }
}



