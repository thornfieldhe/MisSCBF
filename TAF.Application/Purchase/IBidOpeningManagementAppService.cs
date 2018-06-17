// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBidOpeningManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   开标管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 开标管理应用接口
    /// </summary>
    public interface IBidOpeningManagementAppService : IBaseEntityApplicationService
    {
        ListResultDto<BidOpeningManagementListDto> GetAll(BidOpeningManagementQueryDto request);

        BidOpeningManagementEditDto Get(Guid id);

        List<string> GetTenders(Guid planId);

        Task<Guid> SaveAsync(BidOpeningManagementEditDto input);

        void Delete(Guid id);
    }
}



