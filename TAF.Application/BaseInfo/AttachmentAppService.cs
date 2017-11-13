// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachmentAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   附件服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 附件服务
    /// </summary>
    [AbpAuthorize]
    public class AttachmentAppService : TAFAppServiceBase, IAttachmentAppService
    {
        private readonly IAttachmentRepository attachmentRepository;

        private readonly IModuleIdAttachmentRepository moduleIdAttachmentRepository;

        public AttachmentAppService(IAttachmentRepository attachmentRepository, IModuleIdAttachmentRepository moduleIdAttachmentRepository)
        {
            this.attachmentRepository = attachmentRepository;
            this.moduleIdAttachmentRepository = moduleIdAttachmentRepository;
        }

        public ListResultDto<AttachmentListDto> Get(AttachmentQueryDto request)
        {
            var relation = this.moduleIdAttachmentRepository.GetAll().WhereIf(
                request.ModuleId.HasValue,
                r => r.ModuleId == request.ModuleId.Value).Select(r => r.AttachmentId);
            var query = this.attachmentRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), r => r.Name.Contains(request.Name)).WhereIf(
                    !string.IsNullOrWhiteSpace(request.Category),
                    r => r.Path.Contains(request.Category))
                    .WhereIf(relation.Any(), r => relation.Contains(r.Id));

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<AttachmentListDto>>();

            return new PagedResultDto<AttachmentListDto>(count, dtos);
        }

        public void Save(AttachmentEditDto input)
        {
            var item = new Attachment();
            this.attachmentRepository.Insert(input.MapTo(item));
        }

        public void Download(AttachmentEditDto input)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            this.attachmentRepository.Delete(id);
        }
    }
}



