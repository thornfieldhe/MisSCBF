// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHisStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using Abp.Application.Services.Dto;

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 计划任务应用接口
    /// </summary>
    public interface IHisStockAppService : IBaseEntityApplicationService
    {
        void BackupData();

        ListResultDto<HisStockListDto> GetAll(HisStockQueryDto request);
    }
}



