﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDriverAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   驾驶员应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using SCBF.Car.Dto;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// 驾驶员应用接口
    /// </summary>
    public interface IDriverAppService : IBaseEntityApplicationService
    {
        ListResultDto<DriverListDto> GetAll(PagedAndSortedResultRequestDto request);

        DriverEditDto Get(Guid id);

        Task SaveAsync(DriverEditDto input);

        void Delete(Guid id);
    }
}



