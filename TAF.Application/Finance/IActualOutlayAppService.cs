﻿// --------------------------------------------------------------------------------------------------------------------
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

        Guid LoadActualOutlayFile(string path,object param);

        List<ActualOutlayListDto> Get();

        List<ActualOutlayListDto> GetByOutlayId(Guid outlayId);

        void Update(OutlayEditDto input);

    }
}



