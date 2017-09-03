// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoucherAuditAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   凭证审核归纳表服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
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

    using SCBF.Finance.Dto;

    /// <summary>
    /// 凭证审核归纳表服务
    /// </summary>
    [AbpAuthorize]
    public class VoucherAuditAppService : TAFAppServiceBase, IVoucherAuditAppService
    {
        private readonly IVoucherAuditRepository _voucherAuditRepository;

        public VoucherAuditAppService(IVoucherAuditRepository _voucherAuditRepository)
        {
            this._voucherAuditRepository = _voucherAuditRepository;
        }

        public ListResultDto<VoucherAuditListDto> GetAll(VoucherAuditQueryDto request)
        {
            var query = this._voucherAuditRepository.GetAll()

                .WhereIf(!string.IsNullOrWhiteSpace(request.Code), r => r.Code.Contains(request.Code));

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Code);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<VoucherAuditListDto>>();

            return new PagedResultDto<VoucherAuditListDto>(count, dtos);
        }

        public VoucherAuditEditDto Get(Guid id)
        {
            var output = this._voucherAuditRepository.Get(id);
            return output.MapTo<VoucherAuditEditDto>();
        }

        public async Task SaveAsync(VoucherAuditEditDto input)
        {
            var item = input.MapTo<VoucherAudit>();
            if (!input.Id.HasValue)
            {
                await this._voucherAuditRepository.InsertAsync(item);
            }
            else
            {
                var old = this._voucherAuditRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._voucherAuditRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this._voucherAuditRepository.Delete(id);
        }
    }
}



