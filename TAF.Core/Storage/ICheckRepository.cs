// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICheckRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   盘点仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Storage;
    
    /// <summary>
    /// 盘点仓储接口
    /// </summary>
    public interface ICheckRepository : ITAFRepositoryBase<Check>
    {

    }
}



