// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.UI;

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
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购过程管理服务
    /// </summary>
    [AbpAuthorize]
    public class ProjectManagementAppService : TAFAppServiceBase, IProjectManagementAppService
    {
        private readonly IProjectManagementRepository    _projectManagementRepository;
        private readonly IAuditManagementRepository      _auditManagementRepository;
        private readonly IBidOpeningManagementRepository _bidOpeningManagementRepository;
        private readonly IActualOutlayRepository         _actualOutlayRepository;
        private readonly IRelationshipRepository         _relationshipRepository;
        private readonly IProcurementPlanRepository      _procurementPlanRepository;

        public ProjectManagementAppService(IProjectManagementRepository projectManagementRepository,
            IAuditManagementRepository                                  auditManagementRepository,
            IBidOpeningManagementRepository                             bidOpeningManagementRepository,
            IActualOutlayRepository                                     actualOutlayRepository,
            IRelationshipRepository                                     relationshipRepository,
            IProcurementPlanRepository                                  procurementPlanRepository)
        {
            this._projectManagementRepository    = projectManagementRepository;
            this._auditManagementRepository      = auditManagementRepository;
            this._bidOpeningManagementRepository = bidOpeningManagementRepository;
            this._actualOutlayRepository         = actualOutlayRepository;
            this._relationshipRepository         = relationshipRepository;
            this._procurementPlanRepository      = procurementPlanRepository;
        }

        public ListResultDto<ProjectManagementListDto> GetAll(ProjectManagementQueryDto request)
        {
            var query = (from b in this._projectManagementRepository.GetAll()
                join p in this._procurementPlanRepository.GetAll() on b.PlanId equals p.Id
                join s in this._bidOpeningManagementRepository.GetAll() on b.PlanId equals s.PlanId
                where (string.IsNullOrEmpty(request.Name) || p.Name.Contains(request.Name)) &&
                      (string.IsNullOrEmpty(request.Code) || p.Code.Contains(request.Code))
                select new
                {
                    Code        = p.Code,
                    Name        = p.Name,
                    Id          = b.Id,
                    PlanId      = p.Id,
                    Date1       = b.Date1,
                    Price1      = s.Price,
                    CreatedDate = p.CreationTime
                }).OrderByDescending(r => r.CreatedDate);
            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = new List<ProjectManagementListDto>();
            foreach (var l in list)
            {
                var item = new ProjectManagementListDto
                {
                    Code   = l.Code,
                    Name   = l.Name,
                    Id     = l.Id,
                    PlanId = l.PlanId,
                    Price1 = l.Price1.ToString("N"),
                    Date1  = l.Date1.ToString("yyyy-MM-dd"),
                    Price2 = this._auditManagementRepository.GetAllList(r => r.ProjectId == l.Id)
                        .Sum(r => r.Price).ToString("N")
                };

                dtos.Add(item);
            }

            return new PagedResultDto<ProjectManagementListDto>(count, dtos);
        }

        public ProjectManagementEditDto Get(Guid id)
        {
            var output = this._projectManagementRepository.Get(id);
            return output.MapTo<ProjectManagementEditDto>();
        }

        public async Task SaveAsync(ProjectManagementEditDto input)
        {
            if (this._projectManagementRepository.Any(r =>
                r.PlanId == input.PlanId &&
                (input.Id != r.Id || !input.Id.HasValue)))
            {
                throw new UserFriendlyException("不能重复添加采购计划");
            }

            var item = input.MapTo<ProjectManagement>();
            if (!input.Id.HasValue)
            {
                item.HasPrint = 1;
                await this._projectManagementRepository.InsertAsync(item);
            }
            else
            {
                var old = this._projectManagementRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._projectManagementRepository.UpdateAsync(old);
            }
        }

        public ProjectManagementPriceDto ComputePrice(Guid id)
        {
            var price1 = (from a in this._projectManagementRepository.GetAll()
                join
                    b in this._bidOpeningManagementRepository.GetAll() on a.PlanId equals b.PlanId
                    where a.Id==id
                select b.Price).First();

            var price2 = (from a in this._relationshipRepository.GetAll()
                join b in this._actualOutlayRepository.GetAll() on a.ForeignKey equals b.Id
                where a.PrincipalKey == id
                select b.Amount).ToList().Sum();
            return new ProjectManagementPriceDto()
            {
                Id     = id,
                Price1 = price1,
                Price2 = price1 * 0.8M - price2,
                Price3 = price1        - price2
            };
        }

        public void Delete(Guid id)
        {
            this._projectManagementRepository.Delete(id);
        }
    }
}
