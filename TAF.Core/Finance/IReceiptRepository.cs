// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReceiptRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   预算仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 预算仓储接口
    /// </summary>
    public interface IReceiptRepository : ITAFRepositoryBase<Receipt>
    {

    }
}



