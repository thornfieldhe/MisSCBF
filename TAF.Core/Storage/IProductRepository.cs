// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;

    using SCBF.Storage;

    /// <summary>
    /// 商品仓储接口
    /// </summary>
    public interface IProductRepository : IRepository<Product, Guid>
    {

    }
}



