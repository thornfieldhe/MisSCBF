// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;

    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 商品仓储
    /// </summary>
    public class ProductRepository : TAFRepositoryBase<Product, Guid>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



