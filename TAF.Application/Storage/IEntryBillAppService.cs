﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntryBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System.Threading.Tasks;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 入库单应用接口
    /// </summary>
    public interface IEntryBillAppService : IBaseEntityApplicationService
    {
        Task SaveAsync(StockBillEditDto input);

        StockBillEditDto New();
    }
}



