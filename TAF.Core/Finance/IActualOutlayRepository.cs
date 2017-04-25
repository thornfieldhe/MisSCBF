// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActualOutlayRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实际支出仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 实际支出仓储接口
    /// </summary>
    public interface IActualOutlayRepository : ITAFRepositoryBase<ActualOutlay>
    {

    }
}



