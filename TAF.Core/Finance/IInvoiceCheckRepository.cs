// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInvoiceCheckRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   发票录入仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 发票录入仓储接口
    /// </summary>
    public interface IInvoiceCheckRepository : ITAFRepositoryBase<InvoiceCheck>
    {

    }
}



