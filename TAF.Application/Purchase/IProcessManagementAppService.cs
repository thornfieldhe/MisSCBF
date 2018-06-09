// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcessManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标过程管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using TAF.Utility;

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 投标过程管理应用接口
    /// </summary>
    public interface IProcessManagementAppService : IBaseEntityApplicationService
    {
        ListResultDto<ProcessManagementListDto> GetAll(ProcessManagementQueryDto request);

        ProcessManagementEditDto Get(Guid id);

        Task<Guid> SaveAsync(ProcessManagementEditDto input);

        void Delete(Guid id);

        Guid UploadAttachment(string path, object id);

        ProcessManagementEditDto SavePrice(KeyValue<Guid, decimal> price);

        string Print(Guid id);

        List<KeyValue<Guid, string>> GetPurchases();
    }
}



