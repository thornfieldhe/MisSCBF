// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerAAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡申请加油审批单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using Abp.UI;
    using AutoMapper;
    using SCBF.BaseInfo;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    /// <summary>
    /// 加油卡申请加油审批单服务
    /// </summary>
    [AbpAuthorize]
    public class ApplicationForBunkerAAppService : TAFAppServiceBase, IApplicationForBunkerAAppService
    {
        private readonly IApplicationForBunkerARepository applicationForBunkerARepository;
        private readonly IOilCardRepository oilCardRepository;

        public ApplicationForBunkerAAppService(IApplicationForBunkerARepository applicationForBunkerARepository,
                                               IOilCardRepository oilCardRepository)
        {
            this.applicationForBunkerARepository = applicationForBunkerARepository;
            this.oilCardRepository = oilCardRepository;
        }

        public ListResultDto<ApplicationForBunkerAListDto> GetAll(ApplicationForBunkerAQueryDto request)
        {
            var query = this.applicationForBunkerARepository.GetAll()

                .WhereIf(!string.IsNullOrWhiteSpace(request.Code), r => r.Code.Contains(request.Code))
                .WhereIf(request.OilCardId.HasValue, r => r.OilCardId == request.OilCardId.Value)
                .WhereIf(request.DriverId.HasValue, r => r.DriverId == request.DriverId.Value)
                .WhereIf(request.DateFrom.HasValue, r => r.Date >= request.DateFrom.Value)
                .WhereIf(request.DateTo.HasValue, r => r.Date <= request.DateTo.Value)
                .WhereIf(request.Status.HasValue, r => (int)r.Status == request.Status.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.OilCard.Code);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<ApplicationForBunkerAListDto>>();
            foreach (var item in dtos)
            {
                switch (item.Status)
                {
                    case "Pending":
                        item.Status = "等待审核";
                        break;
                    case "Approved":
                        item.Status = "审核通过";
                        break;
                    case "Refused":
                        item.Status = "审核拒绝";
                        break;
                }
            }

            return new PagedResultDto<ApplicationForBunkerAListDto>(count, dtos);
        }

        public ApplicationForBunkerAEditDto Get(Guid id)
        {
            var output = this.applicationForBunkerARepository.Get(id);
            return output.MapTo<ApplicationForBunkerAEditDto>();
        }

        public async Task SaveAsync(ApplicationForBunkerAEditDto input)
        {
            var item = input.MapTo<ApplicationForBunkerA>();
            if (!input.Id.HasValue)
            {
                item.Date = DateTime.Now;
                item.Code = GetMaxCode();
                item.Status = AuditingStatus.Pending;
                await this.applicationForBunkerARepository.InsertAsync(item);
            }
            else
            {
                var old = this.applicationForBunkerARepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this.applicationForBunkerARepository.UpdateAsync(old);
                var card = this.oilCardRepository.FirstOrDefault(r => r.Code == input.OilCardCode);
                if (card == null)
                {
                    throw new UserFriendlyException("加油卡不存在");
                }
                card.Amount -= input.AuditingAmount;
                this.oilCardRepository.Update(card);
            }
        }

        public void Delete(Guid id)
        {
            this.applicationForBunkerARepository.Delete(id);
        }

        private string GetMaxCode()
        {
            var preCode = DateTime.Today.ToString("yyyyMMdd");
            var maxCode =
                this.applicationForBunkerARepository.Get(r => r.Code.StartsWith("JYK" + preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"JYK{preCode}001";
            }
            else
            {
                return $"JYK{long.Parse(maxCode.Substring(3)) + 1}";
            }
        }
    }
}



