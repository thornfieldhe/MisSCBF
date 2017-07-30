// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationForBunkerBAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料加油审批单应用接口
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
    /// 实物油料加油审批单应用接口
    /// </summary>
    public interface IApplicationForBunkerBAppService : IBaseEntityApplicationService
    {
        ListResultDto<ApplicationForBunkerBListDto> GetAll(ApplicationForBunkerBQueryDto request);

        ApplicationForBunkerBEditDto Get(Guid id);

        Task SaveAsync(ApplicationForBunkerBEditDto input);

        List<ApplicationForBunkerBListDto> CheckApplicationForBunkerBList(string queryMonth);

        void Delete(List<Guid> ids);

        void Check(List<Guid> ids);
    }
}



