// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInvoiceCheckAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   发票录入应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SCBF.Finance.Dto;

namespace SCBF.Finance
{
	/// <summary>
    /// 发票录入应用接口
    /// </summary>
    public interface IInvoiceCheckAppService : IBaseEntityApplicationService
    {
        ListResultDto<InvoiceCheckListDto> GetAll(InvoiceCheckQueryDto request);

        InvoiceCheckEditDto Get(Guid id);

        Task SaveAsync(InvoiceCheckEditDto input);

        void Delete(Guid id);

        string Check(Guid id);
    }
}



