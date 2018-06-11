// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBiddingManagementRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   招标文件管理仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Purchase;
    
    /// <summary>
    /// 招标文件管理仓储接口
    /// </summary>
    public interface IBiddingManagementRepository : ITAFRepositoryBase<BiddingManagement>
    {

    }
}



