// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAttachmentAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   附件应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using TAF.Utility;

namespace SCBF.BaseInfo
{
    using System;
    using Abp.Application.Services.Dto;
    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 附件应用接口
    /// </summary>
    public interface IAttachmentAppService : IBaseEntityApplicationService
    {
        ListResultDto<AttachmentListDto> Get(AttachmentQueryDto request);

        List<KeyValue<Guid, string, string>> GetAll(Guid modelId);

        void Save(AttachmentEditDto input);

        void Download(AttachmentEditDto input);

        void Delete(Guid id);
    }
}



