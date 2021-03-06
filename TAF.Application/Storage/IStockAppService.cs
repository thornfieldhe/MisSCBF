﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   库存应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 库存应用接口
    /// </summary>
    public interface IStockAppService : IBaseEntityApplicationService
    {
        ListResultDto<StockListDto> GetAll(StockQueryDto request);

        StockEditDto Get(Guid id);

        Task SaveAsync(StockEditDto input);

        void Delete(Guid id);

        string ExportExs();
    }
}



