// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BidOpeningManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   开标管理服务
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
    /// 开标管理服务
    /// </summary>
    [AbpAuthorize]
    public class BidOpeningManagementAppService : TAFAppServiceBase, IBidOpeningManagementAppService
    {
        private readonly IBidOpeningManagementRepository _bidOpeningManagementRepository;
        private readonly IProcurementPlanRepository      _procurementPlanRepository;
        private readonly IBiddingManagementRepository    _biddingManagementRepository;
        private readonly ITendererRepository             _tendererRepository;
        private readonly ISysDictionaryRepository        _sysDictionaryRepository;

        public BidOpeningManagementAppService(IBidOpeningManagementRepository bidOpeningManagementRepository,
            IProcurementPlanRepository                                        procurementPlanRepository,
            IBiddingManagementRepository                                      biddingManagementRepository,
            ITendererRepository                                               tendererRepository,
            ISysDictionaryRepository                                          sysDictionaryRepository)
        {
            this._bidOpeningManagementRepository = bidOpeningManagementRepository;
            this._procurementPlanRepository      = procurementPlanRepository;
            this._biddingManagementRepository    = biddingManagementRepository;
            this._tendererRepository             = tendererRepository;
            this._sysDictionaryRepository        = sysDictionaryRepository;
        }

        public ListResultDto<BidOpeningManagementListDto> GetAll(BidOpeningManagementQueryDto request)
        {
            var query = (from b in this._bidOpeningManagementRepository.GetAll()
                join p in this._procurementPlanRepository.GetAll() on b.PlanId equals p.Id
                where (string.IsNullOrEmpty(request.Name)     || p.Name.Contains(request.Name))  &&
                      (string.IsNullOrEmpty(request.Code)     || p.Code.Contains(request.Code))  &&
                      (string.IsNullOrEmpty(request.Category) || p.Category == request.Category) &&
                      (string.IsNullOrEmpty(request.SuccessfulTender) ||
                       b.SuccessfulTender.Contains(request.SuccessfulTender)) &&
                      (string.IsNullOrEmpty(request.Mode) || p.Mode == request.Mode)
                select new
                {
                    Code             = p.Code,
                    Name             = p.Name,
                    Category         = p.Category,
                    Id               = b.Id,
                    Mode             = p.Mode,
                    PlanId           = p.Id,
                    SuccessfulTender = b.SuccessfulTender,
                    CreatedDate      = b.CreationTime,
                }).OrderByDescending(r => r.CreatedDate);
            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = new List<BidOpeningManagementListDto>();
            foreach (var l in list)
            {
                var item = new BidOpeningManagementListDto()
                {
                    Code   = l.Code,
                    Name   = l.Name,
                    Id     = l.Id,
                    PlanId = l.PlanId,
                    SuccessfulTender = l.SuccessfulTender
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

                dtos.Add(item);
            }

            return new PagedResultDto<BidOpeningManagementListDto>(count, dtos);
        }


        public List<string> GetTenders(Guid planId)
        {
            var result = (from b in this._biddingManagementRepository.GetAll()
                join
                    t in this._tendererRepository.GetAll() on b.Id equals t.BiddingManagementId
                where b.PlanId == planId
                select t.Name).ToList();
            return result;
        }

        public BidOpeningManagementEditDto Get(Guid id)
        {
            var output = this._bidOpeningManagementRepository.Get(id);
            var result = output.MapTo<BidOpeningManagementEditDto>();
            result.ExpertName = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == output.ExpertId)?.Value;
            result.Mode       = this._procurementPlanRepository.FirstOrDefault(r => r.Id == output.PlanId)?.Mode;
            result.SuccessfulTender.Remove("");
            return result;
        }

        public async Task<Guid> SaveAsync(BidOpeningManagementEditDto input)
        {
            input.SuccessfulTender = input.SuccessfulTender.Where(r => !string.IsNullOrWhiteSpace(r)).ToList();
            if (this._bidOpeningManagementRepository.Any(r =>
                r.PlanId == input.PlanId &&
                (input.Id != r.Id || !input.Id.HasValue)))
            {
                throw new UserFriendlyException("不能重复添加采购计划");
            }

            var item = input.MapTo<BidOpeningManagement>();
            if (!input.Id.HasValue)
            {
                item = await this._bidOpeningManagementRepository.InsertAsync(item);
            }
            else
            {
                item = this._bidOpeningManagementRepository.Get(input.Id.Value);
                Mapper.Map(input, item);


                await this._bidOpeningManagementRepository.UpdateAsync(item);
            }

            return item.Id;
        }

        public void Delete(Guid id)
        {
            this._bidOpeningManagementRepository.Delete(id);
        }
    }
}
