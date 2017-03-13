// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysDictionaryRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置仓储
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
    /// 系统配置仓储
    /// </summary>
    public class SysDictionaryRepository : TAFRepositoryBase<SysDictionary, Guid>, ISysDictionaryRepository
    {
        public SysDictionaryRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



