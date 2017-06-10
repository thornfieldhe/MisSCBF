// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOutlayRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   财务仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 财务仓储接口
    /// </summary>
    public interface IOutlayRepository : ITAFRepositoryBase<Outlay>
    {

    }
}



