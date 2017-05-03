// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeliveryBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System.Collections.Generic;

    using SCBF.Storage.Dto;
    using System.Threading.Tasks;

    /// <summary>
    /// 出库单应用接口
    /// </summary>
    public interface IDeliveryBillAppService : IBaseEntityApplicationService
    {
        Task<List<ProductStockListDto>> SaveAsync(StockBillEditDto input);

        StockBillEditDto New();
    }
}



