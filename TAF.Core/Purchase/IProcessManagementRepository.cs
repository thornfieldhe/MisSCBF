// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcessManagementRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标过程管理仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Purchase;
    
    /// <summary>
    /// 投标过程管理仓储接口
    /// </summary>
    public interface IProcessManagementRepository : ITAFRepositoryBase<ProcessManagement>
    {

    }
}



