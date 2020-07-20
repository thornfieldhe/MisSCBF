// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHisStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace SCBF.Storage
{
    using System.Collections.Generic;

    using Abp.Application.Services.Dto;

    using SCBF.BaseInfo.Dto;
    using SCBF.Storage.Dto;

    /// <summary>
    /// 计划任务应用接口
    /// </summary>
    public interface IHisStockAppService : IBaseEntityApplicationService
    {
        void BackupData();

        List<HisStockReportListDto> GetHistory(int quarter);

        ListResultDto<HisStockListDto> GetAll(HisStockQueryDto request);

        ListResultDto<StockChangeListDto> GetStockChange(DateRangeQueryDto request);

        string ExportExs(DateTime dateFrom, DateTime dataTo);
    }
}



