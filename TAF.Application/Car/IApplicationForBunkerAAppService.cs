// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationForBunkerAAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡申请加油审批单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using SCBF.Car.Dto;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// 加油卡申请加油审批单应用接口
    /// </summary>
    public interface IApplicationForBunkerAAppService : IBaseEntityApplicationService
    {
        ListResultDto<ApplicationForBunkerAListDto> GetAll(ApplicationForBunkerAQueryDto request);

        ApplicationForBunkerAEditDto Get(Guid id);

        Task SaveAsync(ApplicationForBunkerAEditDto input);

        void Delete(Guid id);
    }
}



