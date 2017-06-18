// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RechargeRecordAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   油料分配记录服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    /// <summary>
    /// 油料分配记录服务
    /// </summary>
    [AbpAuthorize]
    public class RechargeRecordAppService : TAFAppServiceBase, IRechargeRecordAppService
    {
        private readonly IRechargeRecordRepository rechargeRecordRepository;
        private readonly IOilCardRepository oilCardRepository;

        public RechargeRecordAppService(
            IRechargeRecordRepository rechargeRecordRepository,
                                        IOilCardRepository oilCardRepository)
        {
            this.rechargeRecordRepository = rechargeRecordRepository;
            this.oilCardRepository = oilCardRepository;
        }

        public ListResultDto<RechargeRecordListDto> GetAll(RechargeRecordQueryDto request)
        {
            var query = this.rechargeRecordRepository.GetAll()

                .WhereIf(request.OilCardId.HasValue, r => r.OilCardId == request.OilCardId.Value)
                .WhereIf(request.DateFrom.HasValue, r => r.Date >= request.DateFrom.Value)
                .WhereIf(request.DateTo.HasValue, r => r.Date <= request.DateTo.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<RechargeRecordListDto>>();

            return new PagedResultDto<RechargeRecordListDto>(count, dtos);
        }

        public RechargeRecordEditDto Get(Guid id)
        {
            var output = this.rechargeRecordRepository.Get(id);
            return output.MapTo<RechargeRecordEditDto>();
        }

        public async Task SaveAsync(RechargeRecordEditDto input)
        {
            var item = input.MapTo<RechargeRecord>();
            if (!input.Id.HasValue)
            {
                await this.rechargeRecordRepository.InsertAsync(item);
                var oilCard = this.oilCardRepository.Get(input.OilCardId);
                oilCard.Amount += item.Amount;
                this.oilCardRepository.Update(oilCard);
            }
        }

        public void Delete(Guid id)
        {
            this.rechargeRecordRepository.Delete(id);
        }
    }
}



