// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAttachmentAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   附件应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;
    using System.Threading.Tasks;
    
    using SCBF.BaseInfo.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 附件应用接口
    /// </summary>
    public interface IAttachmentAppService : IBaseEntityApplicationService
    {
        ListResultDto<AttachmentListDto> Get(AttachmentQueryDto request);

        void Save(AttachmentEditDto input);

        void Download(AttachmentEditDto input);

        void Delete(Guid id);
    }
}



