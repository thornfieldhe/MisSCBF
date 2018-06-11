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
    using System.Collections.Generic;
    
    using SCBF.Purchase.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 招标文件管理应用接口
    /// </summary>
    public interface IBiddingManagementAppService : IBaseEntityApplicationService
    {
        ListResultDto<BiddingManagementListDto> GetAll(BiddingManagementQueryDto request);

        BiddingManagementEditDto Get(Guid id);

        Task SaveAsync(BiddingManagementEditDto input);

        void Delete(Guid id);
    }
}



