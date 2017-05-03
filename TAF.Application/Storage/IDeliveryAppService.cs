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
    using System;
    using System.Collections.Generic;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 出库应用接口
    /// </summary>
    public interface IDeliveryAppService : IBaseEntityApplicationService
    {
        ProductStockListDto Entry(ProductStockQueryDto request);
    }
}



