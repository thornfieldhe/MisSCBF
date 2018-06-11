// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICostListAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   造价清单管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 造价清单管理应用接口
    /// </summary>
    public interface ICostListAppService : IBaseEntityApplicationService
    {
        List<CostListDto> GetAll(Guid biddingManagementId);

        CostListDto Get(Guid id);

        Task SaveAsync(CostListDto input);

        void Delete(Guid id);
    }
}



