﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoeAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;

    using AutoMapper;

    using SCBF.BaseInfo;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购阶段服务
    /// </summary>
    [AbpAuthorize]
    public class StageInfoeAppService : TAFAppServiceBase, IStageInfoeAppService
    {
        private readonly IStageInfoRepository stageInfoRepository;
        private readonly IStageInfoUserRepository stageInfoUserRepository;
        private readonly IModuleIdAttachmentRepository modelAttachmentRepository;
        private readonly IAttachmentRepository attachmentRepository;

        public StageInfoeAppService(
            IStageInfoRepository stageInfoRepository,
            IStageInfoUserRepository stageInfoUserRepository,
            IAttachmentRepository attachmentRepository,
            IModuleIdAttachmentRepository modelAttachmentRepository)
        {
            this.stageInfoRepository = stageInfoRepository;
            this.stageInfoUserRepository = stageInfoUserRepository;
            this.modelAttachmentRepository = modelAttachmentRepository;
            this.attachmentRepository = attachmentRepository;
        }

        public ListResultDto<StageInfoListDto> GetAll(StageInfoQueryDto request)
        {
            var query = this.stageInfoRepository.Get(r => r.Category == request.Category)
                .WhereIf(request.Company.HasValue, r => r.Company == request.Company.Value)
                .WhereIf(request.Status.HasValue, r => r.Status == request.Status.Value)
                .WhereIf(request.ProcurementPlanId.HasValue, r => r.ProcurementPlanId == request.ProcurementPlanId.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();

            var dtos = list.MapTo<List<StageInfoListDto>>();

            return new PagedResultDto<StageInfoListDto>(count, dtos);
        }

        public StageInfoEditDto Get(Guid id)
        {
            var output = this.stageInfoRepository.Get(id);
            var result = output.MapTo<StageInfoEditDto>();
            result.AttachmentIds = this.modelAttachmentRepository.Get(r => r.ModuleId == id).Select(r => r.AttachmentId).ToList();
            result.Attachments = this.attachmentRepository.Get(r => result.AttachmentIds.Contains(r.Id))
                .Select(r => r.Name).ToList();
            return result;
        }

        public async Task SaveAsync(StageInfoEditDto input)
        {
            Action<StageInfo> act = async (entity) =>
                 {
                     await stageInfoUserRepository.DeleteAsync(r => r.StageInfoId == entity.Id);
                     var users = input.Users.Select(r => new StageInfoUser() { StageInfoId = entity.Id, UserId = r })
                         .ToList();
                     stageInfoUserRepository.InsertRange(users);

                     await this.modelAttachmentRepository.DeleteAsync(r => r.ModuleId == entity.Id);
                     var attachments = input.AttachmentIds.Select(r => new ModuleIdAttachment() { ModuleId = entity.Id, AttachmentId = r })
                         .ToList();
                     this.modelAttachmentRepository.InsertRange(attachments);
                 };

            var item = input.MapTo<StageInfo>();
            if (!input.Id.HasValue)
            {
                item = await this.stageInfoRepository.InsertAsync(item);
                act(item);
            }
            else
            {
                var old = this.stageInfoRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this.stageInfoRepository.UpdateAsync(old);
                act(item);
            }
        }

        public void Delete(Guid id)
        {
            this.stageInfoRepository.Delete(id);
            stageInfoUserRepository.Delete(r => r.StageInfoId == id);
        }
    }
}



