// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBudgetReceiptRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   年初预算收入仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 年初预算收入仓储接口
    /// </summary>
    public interface IBudgetReceiptRepository : ITAFRepositoryBase<BudgetReceipt>
    {

    }
}



