// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuditManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购过程管理应用接口
    /// </summary>
    public interface IAuditManagementAppService : IBaseEntityApplicationService
    {
        List<AuditManagementDto> GetAll(Guid id);

        AuditPriceDto GetAuditInfo(Guid id);

        Task SaveAsync(AuditManagementDto input);

        void Delete(Guid id);
    }
}



