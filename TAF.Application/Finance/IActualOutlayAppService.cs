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
    using System.Threading.Tasks;

    using SCBF.Finance.Dto;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 实际支出应用接口
    /// </summary>
    public interface IActualOutlayAppService : IBaseEntityApplicationService
    {

        Guid LoadActualOutlayFile(string path);

        List<ActualOutlayListDto> Get();

        void Update(OutlayEditDto input);

    }
}



