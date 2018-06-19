// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        private readonly IAuditManagementRepository _auditManagementRepository;

        public AuditManagementAppService(IAuditManagementRepository auditManagementRepository)
        {
            this._auditManagementRepository = auditManagementRepository;
        }

        public List<AuditManagementDto> GetAll(Guid id)
        {
            var query = this._auditManagementRepository.GetAllList(r => r.ProjectId == id);
            var dtos = query.MapTo<List<AuditManagementDto>>();

            return dtos;
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



