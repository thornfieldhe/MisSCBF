// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlanAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划服务
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

    using SCBF.Purchase.Dto;

    using TAF.Utility;

    /// <summary>
    /// 采购计划服务
    /// </summary>
    [AbpAuthorize]
    public class ProcurementPlanAppService : TAFAppServiceBase, IProcurementPlanAppService
    {
        private readonly IProcurementPlanRepository _procurementPlanRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;

        public ProcurementPlanAppService(IProcurementPlanRepository procurementPlanRepository, ISysDictionaryRepository sysDictionaryRepository)
        {
            this._procurementPlanRepository = procurementPlanRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
        }

        public ListResultDto<ProcurementPlanListDto> GetAll(ProcurementPlanQueryDto request)
        {
            var query = this._procurementPlanRepository.GetAll()

                .WhereIf(!string.IsNullOrWhiteSpace(request.Category), r => r.Category == request.Category)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Mode), r => r.Mode == request.Mode)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Code), r => r.Code.Contains(request.Code))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), r => r.Name.Contains(request.Name))
                .WhereIf(request.Year.HasValue, r => r.Year == request.Year.Value)
                .WhereIf(request.Month.HasValue, r => r.Month == request.Month.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<ProcurementPlanListDto>>();
            foreach (var dto in dtos)
            {
                dto.User = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == new Guid(dto.User))?.Value;
                dto.Department = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == new Guid(dto.Department))?.Value;
                switch (dto.Category)
                {
                    case "Zccg":
                        dto.Category = "资产采购";
                        break;
                    case "Fwcg":
                        dto.Category = "服务采购";
                        break;
                    case "Xxhcg":
                        dto.Category = "信息化采购";
                        break;
                    case "Gccg":
                        dto.Category = "工程采购";
                        break;
                }
                switch (dto.Mode)
                {
                    case "Yqzb":
                        dto.Mode = "邀请招标";
                        break;
                    case "Jzxtp":
                        dto.Mode = "竞争性谈判";
                        break;
                    case "Xjcg":
                        dto.Mode = "询价采购";
                        break;
                    case "Bxcg":
                        dto.Mode = "比选采购";
                        break;
                    case "GkzbZdjf":
                        dto.Mode = "公开招标(最低价法)";
                        break;
                    case "GkzbZhpff":
                        dto.Mode = "公开招标(综合评分法)";
                        break;
                    case "Dylycg":
                        dto.Mode = "单一来源采购";
                        break;
                }
            }

            return new PagedResultDto<ProcurementPlanListDto>(count, dtos);
        }

        public ProcurementPlanEditDto Get(Guid id)
        {
            var output = this._procurementPlanRepository.Get(id);
            return output.MapTo<ProcurementPlanEditDto>();
        }

        public async Task SaveAsync(ProcurementPlanEditDto input)
        {
            var item = input.MapTo<ProcurementPlan>();
            if (!input.Id.HasValue)
            {
                item.Code = GetMaxCode(new DateTime(input.Year,input.Month,1));
                await this._procurementPlanRepository.InsertAsync(item);
            }
            else
            {
                var old = this._procurementPlanRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._procurementPlanRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this._procurementPlanRepository.Delete(id);
        }


        private string GetMaxCode(DateTime date)
        {
            var preCode = date.ToString("SCBF-yyyy-MMdd-");
            var maxCode =
                this._procurementPlanRepository.Get(r => r.Code.StartsWith(preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"{preCode}01";
            }
            else
            {
                return $"{preCode}{(long.Parse(maxCode.Substring(15)) + 1):00}";
            }
        }
    }
}



