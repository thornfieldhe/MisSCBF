// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVoucherAuditAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   凭证审核归纳表应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SCBF.Finance.Dto;

namespace SCBF.Finance
{
	/// <summary>
    /// 凭证审核归纳表应用接口
    /// </summary>
    public interface IVoucherAuditAppService : IBaseEntityApplicationService
    {
        ListResultDto<VoucherAuditListDto> GetAll(VoucherAuditQueryDto request);

        VoucherAuditEditDto Get(Guid id);

        Task SaveAsync(VoucherAuditEditDto input);

        void Delete(Guid id);
    }
}



