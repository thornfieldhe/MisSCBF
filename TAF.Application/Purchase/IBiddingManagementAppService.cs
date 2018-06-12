// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBiddingManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   招标文件管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 招标文件管理应用接口
    /// </summary>
    public interface IBiddingManagementAppService : IBaseEntityApplicationService
    {
        ListResultDto<BiddingManagementListDto> GetAll(BiddingManagementQueryDto request);

        BiddingManagementEditDto Get(Guid id);

            Task<Guid> SaveAsync(BiddingManagementEditDto input);

        void Delete(Guid id);
        string ExportDoc(Guid id);
    }
}



