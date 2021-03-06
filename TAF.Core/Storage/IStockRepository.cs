﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStockRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   库存仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Storage;
    
    /// <summary>
    /// 库存仓储接口
    /// </summary>
    public interface IStockRepository : ITAFRepositoryBase<Stock>
    {

    }
}



