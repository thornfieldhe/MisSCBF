// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeliveryBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.Application.Services.Dto;
using System;

namespace SCBF.Storage
{
    using SCBF.Storage.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// 出库单应用接口
    /// </summary>
    public interface IDeliveryBillAppService : IBaseEntityApplicationService
    {
        Task<List<ProductStockListDto>> SaveAsync(StockBillEditDto input);

        StockBillEditDto New();

        PagedResultDto<TAF.Utility.KeyValue<Guid, string>> GetSimpleList(DeliveryBillQueryDto query);
    }
}



