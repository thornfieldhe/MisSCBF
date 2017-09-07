// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcurementPlanAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using SCBF.Purchase.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 采购计划应用接口
    /// </summary>
    public interface IProcurementPlanAppService : IBaseEntityApplicationService
    {
        ListResultDto<ProcurementPlanListDto> GetAll(ProcurementPlanQueryDto request);

        ProcurementPlanEditDto Get(Guid id);

        Task SaveAsync(ProcurementPlanEditDto input);

        void Delete(Guid id);
    }
}



