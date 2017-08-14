// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeliveryAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using SCBF.Storage.Dto;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 出库应用接口
    /// </summary>
    public interface IDeliveryAppService : IBaseEntityApplicationService
    {
        ProductStockListDto Entry(ProductStockQueryDto request);

        List<ProductStockListDto> Get(Guid billId);
    }
}



