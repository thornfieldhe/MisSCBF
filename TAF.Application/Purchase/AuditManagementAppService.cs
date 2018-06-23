// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using TAF.Utility;

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using AutoMapper;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购过程管理服务
    /// </summary>
    [AbpAuthorize]
    public class AuditManagementAppService : TAFAppServiceBase, IAuditManagementAppService
    {
        private readonly IAuditManagementRepository      _auditManagementRepository;
        private readonly IBidOpeningManagementRepository _bidOpeningManagementRepository;
        private readonly IRelationshipRepository         _relationshipRepository;
        private readonly IActualOutlayRepository         _actualOutlayRepository;
        private readonly IProjectManagementRepository    _projectManagementRepository;

        public AuditManagementAppService(IAuditManagementRepository auditManagementRepository,
            IBidOpeningManagementRepository                         bidOpeningManagementRepository,
            IRelationshipRepository                                 relationshipRepository,
            IActualOutlayRepository                                 actualOutlayRepository,
            IProjectManagementRepository                            projectManagementRepository)
        {
            this._auditManagementRepository      = auditManagementRepository;
            this._bidOpeningManagementRepository = bidOpeningManagementRepository;
            this._relationshipRepository         = relationshipRepository;
            this._actualOutlayRepository         = actualOutlayRepository;
            this._projectManagementRepository    = projectManagementRepository;
        }

        public List<AuditManagementDto> GetAll(Guid id)
        {
            var query = this._auditManagementRepository.GetAllList(r => r.ProjectId == id);
            var dtos  = query.MapTo<List<AuditManagementDto>>();

            return dtos;
        }

        public AuditPriceDto GetAuditInfo(Guid id)
        {
            var proj  = this._projectManagementRepository.Get(id);
            var price = this._auditManagementRepository.GetAllList(r => r.ProjectId       == id);
            var bid   = this._bidOpeningManagementRepository.FirstOrDefault(r => r.PlanId == proj.PlanId);
            var usedPrice = (from a in this._projectManagementRepository.GetAll()
                join b in this._relationshipRepository.GetAll() on a.Id equals b.PrincipalKey
                join c in this._actualOutlayRepository.GetAll() on b.ForeignKey equals c.Id
                select c.Amount).ToList().Sum();
            var auditPrice = proj.Price ?? 0M;
            return new AuditPriceDto()
            {
                ProjectId = id,
                Price1    = bid.Price  - usedPrice,
                Price2    = auditPrice + price.Sum(r => r.Price),
                Price3 = auditPrice == 0
                    ? 0
                    : (price.Sum(r => Math.Abs(r.Price)) / auditPrice > 0.03M
                        ? price.Sum(r => r.Price) * 0.05M
                        : 0M),
                Price4   = (auditPrice + price.Sum(r => r.Price)) * 0.05M,
                Price5   = auditPrice + price.Sum(r => r.Price) * 0.95M - usedPrice,
                Price6   = (auditPrice != 0 ? price.Sum(r => r.Price) / auditPrice*100 : 0).ToFixed(2),
                HasPrint = proj.HasPrint,
                Price0   = auditPrice
            };
        }

        public async Task SaveAsync(AuditManagementDto input)
        {
            var item = input.MapTo<AuditManagement>();
            if (!input.Id.HasValue)
            {
                await this._auditManagementRepository.InsertAsync(item);
            }
            else
            {
                var old = this._auditManagementRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._auditManagementRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this._auditManagementRepository.Delete(id);
        }
    }
}
