// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILayerRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品类别仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;

    using SCBF.BaseInfo;

    /// <summary>
    /// 商品类别仓储接口
    /// </summary>
    public interface ILayerRepository : IRepository<Layer, Guid>
    {

    }
}



