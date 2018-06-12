// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiddingManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   招标文件管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;
using Abp.UI;
using SCBF.Common;
using SCBF.Tools;
using TAF.Utility;

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
            result.Tenderers = new List<TendererDto>();
            return result;
        }

        public async Task<Guid> SaveAsync(BiddingManagementEditDto input)
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
              item=  await this._biddingManagementRepository.InsertAsync(item);
            }
            else
            {
                item= this._biddingManagementRepository.Get(input.Id.Value);
                this._costListRepository.Delete(r=>r.BiddingManagementId==item.Id);
                Mapper.Map(input, item);


                await this._biddingManagementRepository.UpdateAsync(item);
            }
            input.CostList.ForEach(r=>r.BiddingManagementId=item.Id);
            var details = input.CostList.MapTo<List<CostList>>();
            this._costListRepository.InsertRange(details);
            return item.Id;
        }


        public void Delete(Guid id)
        {
            this._biddingManagementRepository.Delete(id);
        }

        public string ExportDoc(Guid id)
        {
            var item = this._biddingManagementRepository.Get(id);
            var plan = this._procurementPlanRepository.Get(item.PlanId);
            var details = this._costListRepository.GetAllList(r => r.BiddingManagementId == id);
            var result = new KeyValue<BiddingManagement,ProcurementPlan,List<CostList>>( item,  plan,  details);
            return DownloadFileService.Load("信息化采购模板.doc", $"中国人民武装警察部队四川省边防总队{plan.Name}招标文件.doc", new string[] { })
                .ExcuteDoc(result,this.ExportToDoc);
        }

        private KeyValue<DataSet, string[], object[]> ExportToDoc(object arg)
        {
            var result = arg as KeyValue<BiddingManagement, ProcurementPlan, List<CostList>>;
            var biddingAgency = this._sysDictionaryRepository.Get(result.Key.BiddingAgencyId);
            var value = new[]
            {
                "采购项目编号",
                "招标代理机构",
                "项目名称",
                "招标时间大写",
                "招标时间",
                "文件发售时间起",
                "文件发售时间止",
                "招标代理公司地址",
                "开标截止时间",
                "招标代理公司银行",
                "招标代理公司账号",
                "招标代理公司联系人2",
                "招标代理公司电话",
                "招标代理公司邮箱",
                "最高限价",
                "招标代理公司联系人",
                "工期"
            };

            var year = StringExtensions.NumberToChinese(DateTime.Now.Year.ToString());
            var mounth = StringExtensions.NumberToChinese(DateTime.Now.Month.ToString());
            var day = StringExtensions.NumberToChinese(DateTime.Now.Day.ToString());
            if (mounth.Length == 2)
            {
                mounth = mounth[0] + "十" + mounth[1];
            }

            if (day.Length == 2)
            {
                day = day[0] + "十" + day[1];
            }

            var item3 = new[]
            {
                result.Value.Code,
                biddingAgency.Value,
                result.Value.Name,
                $"{year}年{mounth}月{day}日",
                DateTime.Now.ToString("yyyy年M月d日"),
                result.Key.PlanDateFrom.ToString("yyyy年M月d日"),
                result.Key.PlanDateTo.ToString("yyyy年M月d日"),
                biddingAgency.Value4,
                result.Key.PlanDateEnd.ToString("yyyy年M月d日"),
                biddingAgency.Value2,
                biddingAgency.Value3,
                $"{biddingAgency.Value8},{biddingAgency.Value9}",
                $"{biddingAgency.Value11}   {biddingAgency.Value15}",
                biddingAgency.Value16,
                result.Key.Total.ToString("N2"),
                biddingAgency.Value11,
                result.Key.Schedule.ToString()
            };

            var ds=new DataSet();
            var dt=new DataTable("CostList");
            dt.Columns.Add("Index");
            dt.Columns.Add("Category");
            dt.Columns.Add("Details");
            dt.Columns.Add("Unit");
            dt.Columns.Add("Amount");
            for (var i = 0; i < result.Item3.Count; i++)
            {
                var row = dt.NewRow();
                row["Index"] = i+1;
                row["Category"] = result.Item3[i].Category;
                row["Details"]  = result.Item3[i].Details;
                row["Unit"]     = result.Item3[i].Unit;
                row["Amount"]   = result.Item3[i].Amount;
                dt.Rows.Add(row);
            }


            ds.Tables.Add(dt);

            return new KeyValue<DataSet, string[], object[]>(ds,value,item3);
        }
    }
}
