// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVoucherAuditAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   凭证审核归纳表应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using SCBF.Finance.Dto;
    
   using Abp.Application.Services.Dto;
    
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



