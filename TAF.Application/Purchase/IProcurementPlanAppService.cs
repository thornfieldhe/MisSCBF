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
    using Abp.Application.Services.Dto;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购计划应用接口
    /// </summary>
    public interface IProcurementPlanAppService : IBaseEntityApplicationService
    {
        ListResultDto<ProcurementPlanListDto> GetAll(ProcurementPlanQueryDto request);

        ProcurementPlanEditDto Get(Guid id);

        Task SaveAsync(ProcurementPlanEditDto input);

        void Delete(Guid id);

        string ExportExs();

        string ExportDoc();
    }
}



