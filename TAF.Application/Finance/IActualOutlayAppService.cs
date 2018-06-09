// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActualOutlayAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实际支出应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using System;
    using System.Collections.Generic;
    using Abp.Application.Services.Dto;
    using SCBF.Finance.Dto;

    /// <summary>
    /// 实际支出应用接口
    /// </summary>
    public interface IActualOutlayAppService : IBaseEntityApplicationService
    {

        Guid LoadActualOutlayFile(string path,object param);

        List<ActualOutlayListDto> Get();

        List<ActualOutlayListDto> GetByOutlayId(Guid outlayId);

        void Update(OutlayEditDto input);

        ListResultDto<ActualOutlayListDto> LoadUnLinkOutlays(ActualAuditQueryDto request);

        ListResultDto<ActualOutlayListDto> LoadLinkedOutlays(ActualAuditQueryDto request);
    }
}



