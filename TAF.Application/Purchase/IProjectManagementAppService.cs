// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购过程管理应用接口
    /// </summary>
    public interface IProjectManagementAppService : IBaseEntityApplicationService
    {
        ListResultDto<ProjectManagementListDto> GetAll(ProjectManagementQueryDto request);

        ProjectManagementEditDto Get(Guid id);

        Task SaveAsync(ProjectManagementEditDto input);

        void Delete(Guid id);

        /// <summary>
        /// 计算付款进度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProjectManagementPriceDto ComputePrice(Guid id);

        List<Guid> GetAttachments(Guid id);

        void SavePrice(ProjectManagementSavePriceDto item);

        string ExportDoc1(Guid id);

        string ExportDoc2(Guid id);
    }
}



