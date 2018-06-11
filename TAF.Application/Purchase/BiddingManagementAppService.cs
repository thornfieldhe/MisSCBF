// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiddingManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   招标文件管理服务
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
    /// 招标文件管理服务
    /// </summary>
    [AbpAuthorize]
    public class BiddingManagementAppService : TAFAppServiceBase, IBiddingManagementAppService
    {
        private readonly IBiddingManagementRepository _biddingManagementRepository;
        private readonly ICostListRepository          _costListRepository;
        private readonly IProcurementPlanRepository   _procurementPlanRepository;
        private readonly ISysDictionaryRepository     _sysDictionaryRepository;

        public BiddingManagementAppService(IBiddingManagementRepository biddingManagementRepository,
            ICostListRepository                                         costListRepository,
            IProcurementPlanRepository                                  procurementPlanRepository,
            ISysDictionaryRepository                                    sysDictionaryRepository)
        {
            this._biddingManagementRepository = biddingManagementRepository;
            this._costListRepository          = costListRepository;
            this._procurementPlanRepository   = procurementPlanRepository;
            this._sysDictionaryRepository     = sysDictionaryRepository;
        }

        public ListResultDto<BiddingManagementListDto> GetAll(BiddingManagementQueryDto request)
        {
            var query = (from b in this._biddingManagementRepository.GetAll()
                join p in this._procurementPlanRepository.GetAll() on b.PlanId equals p.Id
                where (string.IsNullOrEmpty(request.Name)     || p.Name.Contains(request.Name))  &&
                      (string.IsNullOrEmpty(request.Code)     || p.Code.Contains(request.Code))  &&
                      (string.IsNullOrEmpty(request.Category) || p.Category == request.Category) &&
                      (string.IsNullOrEmpty(request.Mode)     || p.Mode     == request.Mode)
                select new
                {
                    Code          = p.Code,
                    Name          = p.Name,
                    Category      = p.Category,
                    Id            = b.Id,
                    Mode          = p.Mode,
                    Total         = b.Total,
                    PlanId        = p.Id,
                    BiddingAgency = b.BiddingAgencyId,
                    PlanDateEnd   = b.PlanDateEnd,
                    CreatedDate   = b.CreationTime
                }).OrderByDescending(r => r.CreatedDate);
            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = new List<BiddingManagementListDto>();
            foreach (var l in list)
            {
                var item = new BiddingManagementListDto()
                {
                    Code        = l.Code,
                    Name        = l.Name,
                    Id          = l.Id,
                    PlanId      = l.PlanId,
                    PlanDateEnd = l.PlanDateEnd.ToString("yyyy-MM-dd"),
                    Total       = l.Total
                };
                switch (l.Mode)
                {
                    case "Yqzb":
                        item.Mode = "邀请招标";
                        break;
                    case "Jzxtp":
                        item.Mode = "竞争性谈判";
                        break;
                    case "Xjcg":
                        item.Mode = "询价采购";
                        break;
                    case "Bxcg":
                        item.Mode = "比选采购";
                        break;
                    case "GkzbZhpff":
                        item.Mode = "公开招标(综合评分法)";
                        break;
                    case "GkzbZdjf":
                        item.Mode = "公开招标(最低价法)";
                        break;
                    case "Dylycg":
                        item.Mode = "单一来源采购";
                        break;
                }

                switch (l.Category)
                {
                    case "Zccg":
                        item.Category = "资产采购";
                        break;
                    case "Fwcg":
                        item.Mode = "服务采购";
                        break;
                    case "Xxhcg":
                        item.Mode = "信息化采购";
                        break;
                    case "Gccg":
                        item.Mode = "工程采购";
                        break;
                }

                item.BiddingAgency = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == l.BiddingAgency)?.Value;
                dtos.Add(item);
            }


            return new PagedResultDto<BiddingManagementListDto>(count, dtos);
        }

        public BiddingManagementEditDto Get(Guid id)
        {
            var output = this._biddingManagementRepository.Get(id);
            var result = output.MapTo<BiddingManagementEditDto>();
            result.ExpertName = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == output.ExpertId)?.Value;
            result.CostList = this._costListRepository.GetAllList(r => r.BiddingManagementId == id)
                .MapTo<List<CostListDto>>();
            return result;
        }

        public async Task SaveAsync(BiddingManagementEditDto input)
        {
            if (this._biddingManagementRepository.Any(r =>
                r.PlanId == input.PlanId &&
                (input.Id != r.Id || !input.Id.HasValue)))
            {
                throw new UserFriendlyException("不能重复添加采购计划");
            }

            var item = input.MapTo<BiddingManagement>();
            if (!input.Id.HasValue)
            {
                await this._biddingManagementRepository.InsertAsync(item);
            }
            else
            {
                var old = this._biddingManagementRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._biddingManagementRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this._biddingManagementRepository.Delete(id);
        }
    }
}
