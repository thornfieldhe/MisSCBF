// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISysDictionaryRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;

    using SCBF.BaseInfo;

    /// <summary>
    /// 系统配置仓储接口
    /// </summary>
    public interface ISysDictionaryRepository : IRepository<SysDictionary, Guid>
    {

    }
}



