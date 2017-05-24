// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHisStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using Abp.Application.Services.Dto;

    using SCBF.BaseInfo.Dto;
    using SCBF.Storage.Dto;

    /// <summary>
    /// 计划任务应用接口
    /// </summary>
    public interface IHisStockAppService : IBaseEntityApplicationService
    {
        void BackupData();

        ListResultDto<HisStockListDto> GetAll(HisStockQueryDto request);
    }
}



