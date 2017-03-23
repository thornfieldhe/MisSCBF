// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntryRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Storage;
    
    /// <summary>
    /// 入库仓储接口
    /// </summary>
    public interface IEntryRepository : ITAFRepositoryBase<Entry>
    {

    }
}



