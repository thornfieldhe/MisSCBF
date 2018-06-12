// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITendererAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标人管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 投标人管理应用接口
    /// </summary>
    public interface ITendererAppService : IBaseEntityApplicationService
    {
        List<TendererDto> GetAll(Guid biddingManagementId);


        Task SaveAsync(List<TendererDto> inputs);

    }
}



