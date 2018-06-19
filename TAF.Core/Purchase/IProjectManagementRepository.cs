// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectManagementRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Purchase;
    
    /// <summary>
    /// 采购过程管理仓储接口
    /// </summary>
    public interface IProjectManagementRepository : ITAFRepositoryBase<ProjectManagement>
    {

    }
}



