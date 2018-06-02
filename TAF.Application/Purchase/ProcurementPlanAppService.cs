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
    using Dto;
    using TAF.Utility;

    /// <summary>
    /// 采购计划服务
    /// </summary>
    [AbpAuthorize]
    public class ProcurementPlanAppService : TAFAppServiceBase, IProcurementPlanAppService
    {
        private readonly IProcurementPlanRepository _procurementPlanRepository;
        private readonly ISysDictionaryRepository   _sysDictionaryRepository;

        public ProcurementPlanAppService(IProcurementPlanRepository procurementPlanRepository,
            ISysDictionaryRepository                                sysDictionaryRepository)
        {
            this._procurementPlanRepository = procurementPlanRepository;
            this._sysDictionaryRepository   = sysDictionaryRepository;
        }

        public ListResultDto<ProcurementPlanListDto> GetAll(ProcurementPlanQueryDto request)
        {
            var query = this._procurementPlanRepository.GetAll()
                .Where(r=>r.Type==request.Type)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Category), r => r.Category == request.Category)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Mode), r => r.Mode         == request.Mode)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Code), r => r.Code.Contains(request.Code))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), r => r.Name.Contains(request.Name))
                .WhereIf(request.Department.HasValue, r => r.Department==request.Department.Value)
                .WhereIf(request.User.HasValue, r => r.User==request.User.Value)
                .WhereIf(request.Date.HasValue, r => r.Date   == request.Date.Value)
                .OrderByDescending(r => r.Code);
            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = list.MapTo<List<ProcurementPlanListDto>>();
            foreach (var dto in dtos)
            {
                dto.User = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == new Guid(dto.User))?.Value;
                dto.Department = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == new Guid(dto.Department))
                    ?.Value;
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
                item.Code = this.GetMaxCode(DateTime.Parse(input.Date) );
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
            var preCode = $"SCBF-{date:yyyy-MMdd-}";
            var maxCode =
                this._procurementPlanRepository.Get(r => r.Code.StartsWith(preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            return string.IsNullOrWhiteSpace(maxCode)
                ? $"{preCode}01"
                : $"{preCode}{(long.Parse(maxCode.Substring(16)) + 1):00}";
        }
    }
}
