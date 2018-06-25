// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqManagerAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   会质量评价体系服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.UI;
using SCBF.BaseInfo;

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
    /// 质量评价体系服务
    /// </summary>
    [AbpAuthorize]
    public class EqManagerAppService : TAFAppServiceBase, IEqManagerAppService
    {
        private readonly IEqManagerRepository       _eqManagerRepository;
        private readonly IProcurementPlanRepository _procurementPlanRepository;
        private readonly IBlacklistRepository       _blacklistRepository;
        private readonly ISysDictionaryRepository   _sysDictionaryRepository;

        public EqManagerAppService(IEqManagerRepository eqManagerRepository,
            IProcurementPlanRepository                  procurementPlanRepository,
            IBlacklistRepository                        blacklistRepository,
            ISysDictionaryRepository                    sysDictionaryRepository)
        {
            this._eqManagerRepository       = eqManagerRepository;
            this._procurementPlanRepository = procurementPlanRepository;
            this._blacklistRepository       = blacklistRepository;
            this._sysDictionaryRepository   = sysDictionaryRepository;
        }

        public ListResultDto<EqManagerListDto> GetAll(EqManagerQueryDto request)
        {
            var query = from a in this._eqManagerRepository.GetAll()
                join
                    b in this._procurementPlanRepository.GetAll() on a.PlanId equals b.Id
                where (string.IsNullOrEmpty(request.Name) || b.Name.Contains(request.Name)) &&
                      (string.IsNullOrEmpty(request.Code) || b.Name.Contains(request.Code))
                select new {A = a, B = b, C = a.CreationTime};
            var count  = query.Count();
            var list   = query.OrderByDescending(r => r.C).PageBy(request).ToList();
            var result = new List<EqManagerListDto>();
            foreach (var r in list)
            {
                var item = new EqManagerListDto()
                {
                    Code     = r.B.Code,
                    Id       = r.A.Id,
                    PlanName = r.B.Name,
                    Score1   = r.A.Score1,
                    Score2   = r.A.Score2,
                    Score3   = r.A.Score3,
                    Score4   = r.A.Score4,
                    Score5   = r.A.Score5,
                    Unit5    = r.A.Unit5
                };
                if (r.A.Unit1.HasValue)
                {
                    item.Unit1 = this._sysDictionaryRepository.Get(r.A.Unit1.Value).Value;
                }

                if (r.A.Unit2.HasValue)
                {
                    item.Unit2 = this._sysDictionaryRepository.Get(r.A.Unit2.Value).Value;
                }

                if (r.A.Unit3.HasValue)
                {
                    item.Unit3 = this._sysDictionaryRepository.Get(r.A.Unit3.Value).Value;
                }

                if (r.A.Unit4.HasValue)
                {
                    item.Unit4 = this._sysDictionaryRepository.Get(r.A.Unit4.Value).Value;
                }

                result.Add(item);
            }

            return new PagedResultDto<EqManagerListDto>(count, result);
        }

        public EqManagerEditDto Get(Guid id)
        {
            var output = this._eqManagerRepository.Get(id);
            var item   = output.MapTo<EqManagerEditDto>();
            if (output.Unit1.HasValue)
            {
                item.UnitName1 = this._sysDictionaryRepository.Get(output.Unit1.Value).Value;
            }

            if (output.Unit2.HasValue)
            {
                item.UnitName2 = this._sysDictionaryRepository.Get(output.Unit2.Value).Value;
            }

            if (output.Unit3.HasValue)
            {
                item.UnitName3 = this._sysDictionaryRepository.Get(output.Unit3.Value).Value;
            }

            if (output.Unit4.HasValue)
            {
                item.UnitName4 = this._sysDictionaryRepository.Get(output.Unit4.Value).Value;
            }

            return item;
        }

        public async Task SaveAsync(EqManagerEditDto input)
        {
            if (this._eqManagerRepository.Any(r => (!input.Id.HasValue && r.PlanId == input.PlanId)
                                                   || (input.Id.HasValue && r.Id != input.Id &&
                                                       r.PlanId                  == input.PlanId)))
            {
                throw new UserFriendlyException("采购计划已添加");
            }

            var item = input.MapTo<EqManager>();
            if (!input.Id.HasValue)
            {
                await this._eqManagerRepository.InsertAsync(item);
            }
            else
            {
                var old = this._eqManagerRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._eqManagerRepository.UpdateAsync(old);
            }


            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            var year = int.Parse(currentYearItem.Value);
            var scoreLevel = this._sysDictionaryRepository
                .Get(r => r.Category == DictionaryCategory.Purchase_SystemScore).FirstOrDefault();
            var baseScore = decimal.Parse(scoreLevel.Value3);
            if (item.Score1 <= baseScore)
            {
                this._blacklistRepository.Insert(new Blacklist()
                {
                    Name = input.Unit1.Value.ToString(),
                    Type = DictionaryCategory.Purchase_BiddingAgency,
                    Year = year
                });
            }

            if (item.Score2 <= baseScore)
            {
                this._blacklistRepository.Insert(new Blacklist()
                {
                    Name = input.Unit2.Value.ToString(),
                    Type = DictionaryCategory.Purchase_ConstructionControlUnit,
                    Year = year
                });
            }

            if (item.Score3 <= baseScore)
            {
                this._blacklistRepository.Insert(new Blacklist()
                {
                    Name = input.Unit3.Value.ToString(),
                    Type = DictionaryCategory.Purchase_CostUnit,
                    Year = year
                });
            }

            if (item.Score4 <= baseScore)
            {
                this._blacklistRepository.Insert(new Blacklist()
                {
                    Name = input.Unit4.Value.ToString(),
                    Type = DictionaryCategory.Purchase_DesignUnit,
                    Year = year
                });
            }

            if (item.Score5 <= baseScore)
            {
                this._blacklistRepository.Insert(new Blacklist()
                {
                    Name = input.Unit5,
                    Type = DictionaryCategory.Purchase_Supplier,
                    Year = year
                });
            }
        }

        public void Delete(Guid id)
        {
            this._eqManagerRepository.Delete(id);
        }
    }
}
