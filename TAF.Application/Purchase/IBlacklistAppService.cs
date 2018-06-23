// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBlacklistAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   会质量评价体系应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using Abp.Application.Services.Dto;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 会质量评价体系应用接口
    /// </summary>
    public interface IBlacklistAppService : IBaseEntityApplicationService
    {
        ListResultDto<BlacklistListDto> GetAll(BlacklistQueryDto request);

        void Delete(Guid id);
        string ExportDoc();
    }
}



