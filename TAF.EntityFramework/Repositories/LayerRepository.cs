// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayerRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品类别仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;

    using SCBF.BaseInfo;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 商品类别仓储
    /// </summary>
    public class LayerRepository : TAFRepositoryBase<Layer, Guid>, ILayerRepository
    {
        public LayerRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



