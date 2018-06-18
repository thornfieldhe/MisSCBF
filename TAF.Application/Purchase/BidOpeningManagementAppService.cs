// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BidOpeningManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   开标管理服务
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
                    Price            = b.Price,
                    CreatedDate      = b.CreationTime,
                }).OrderByDescending(r => r.CreatedDate);
            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = new List<BidOpeningManagementListDto>();
            foreach (var l in list)
            {
                var item = new BidOpeningManagementListDto()
                {
                    Code             = l.Code,
                    Name             = l.Name,
                    Id               = l.Id,
                    PlanId           = l.PlanId,
                    SuccessfulTender = l.SuccessfulTender,
                    Price            = l.Price.ToString("N")
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

        public string ExportDoc1(Guid id)
        {
            // var item    = this._biddingManagementRepository.Get(id);
            // var plan    = this._procurementPlanRepository.Get(item.PlanId);
            // if (plan.Category ==ProcurementPlanCategory.Xxhcg)
            // {
            //     return DownloadFileService.Load("信息化采购模板.doc", $"中国人民武装警察部队四川省边防总队{plan.Name}招标文件.doc", new string[] { })
            //         .ExcuteDoc(result,this.ExportToDoc1);
            // }
            //
            // if (plan.Category ==ProcurementPlanCategory.Zccg)
            // {
            //     return DownloadFileService.Load("资产采购模板.doc", $"中国人民武装警察部队四川省边防总队{plan.Name}招标文件.doc", new string[] { })
            //         .ExcuteDoc(result,this.ExportToDoc1);
            // }
            //
            // //Todo: 处理其他报告类型
            throw new Exception("未处理");
        }

        public string ExportDoc2(Guid id)
        {
            var bid  = this._bidOpeningManagementRepository.Get(id);
            var plan = this._procurementPlanRepository.Get(bid.PlanId);

            var result = new KeyValue<BidOpeningManagement, ProcurementPlan>(bid, plan);

            return DownloadFileService.Load("中标通知书模板.doc", $"中标通知书.doc", new string[] { })
                .ExcuteDoc(result, this.ExportToDoc2);
        }

        public string ExportDoc3(Guid id)
        {
            var bid  = this._bidOpeningManagementRepository.Get(id);
            var plan = this._procurementPlanRepository.Get(bid.PlanId);
            var bil  = this._biddingManagementRepository.FirstOrDefault(r => r.PlanId == bid.PlanId);

            var result = new KeyValue<BidOpeningManagement, ProcurementPlan, BiddingManagement>(bid, plan, bil);

            return DownloadFileService.Load("招投标计划模板.docx", $"招投标计划.docx", new string[] { })
                .ExcuteDoc(result, this.ExportToDoc3);
        }

        private KeyValue<DataSet, string[], object[]> ExportToDoc1(object arg)
        {
            var result        = arg as KeyValue<BiddingManagement, ProcurementPlan, List<CostList>>;
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

            var year   = StringExtensions.NumberToChinese(DateTime.Now.Year.ToString());
            var mounth = StringExtensions.NumberToChinese(DateTime.Now.Month.ToString());
            var day    = StringExtensions.NumberToChinese(DateTime.Now.Day.ToString());
            if (mounth.Length == 2)
            {
                mounth = mounth[0] + "十" + mounth[1];
            }

            var item3 = new[]
            {
                result.Value.Code,
                biddingAgency.Value,
                result.Value.Name,
                $"{year}年{mounth}月{day}日",
                DateTime.Now.ToString("yyyy年M月d日"),
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

            var ds = new DataSet();
            var dt = new DataTable("CostList");
            dt.Columns.Add("Index");
            dt.Columns.Add("Category");
            dt.Columns.Add("Details");
            dt.Columns.Add("Unit");
            dt.Columns.Add("Amount");
            for (var i = 0; i < result.Item3.Count; i++)
            {
                var row = dt.NewRow();
                row["Index"]    = i + 1;
                row["Category"] = result.Item3[i].Category;
                row["Details"]  = result.Item3[i].Details;
                row["Unit"]     = result.Item3[i].Unit;
                row["Amount"]   = result.Item3[i].Amount;
                dt.Rows.Add(row);
            }


            ds.Tables.Add(dt);

            return new KeyValue<DataSet, string[], object[]>(ds, value, item3);
        }


        private KeyValue<DataSet, string[], object[]> ExportToDoc2(object arg)
        {
            var result = arg as KeyValue<BidOpeningManagement, ProcurementPlan>;
            var value = new[]
            {
                "Unit",
                "Project",
                "Date"
            };


            var item3 = new[]
            {
                result.Key.SuccessfulTender,
                result.Value.Name,
                DateTime.Now.ToString("yyyy年M月d日")
            };

            var ds = new DataSet();
            var dt = new DataTable();
            ds.Tables.Add(dt);

            return new KeyValue<DataSet, string[], object[]>(ds, value, item3);
        }


        private KeyValue<DataSet, string[], object[]> ExportToDoc3(object arg)
        {
            var result   = arg as KeyValue<BidOpeningManagement, ProcurementPlan, BiddingManagement>;
            var dateInfo = new ProcurementPlanManagement(result.Value.Mode, result.Item3.PlanDateEnd);
            var value = new[]
            {
                "项目名称",
                "主要内容",
                "年度预算",
                "招标控制价",
                "招标复审控制价",
                "招投标计划时间",
                "招标公告时间起",
                "招标公告时间止",
                "标书发售时间起",
                "标书发售时间止",
                "执行周期起",
                "执行周期止",
                "开标时间",
                "结果公告时间",
                "结果公示时间起",
                "结果公示时间止",
                "中标通知书时间",
                "合同签订时间起",
                "合同签订时间止",
                "采购方式"
            };


            string GetModel(string model)
            {
                switch (model)
                {
                    case "Yqzb":
                        return "邀请招标";
                        break;
                    case "Jzxtp":
                        return "竞争性谈判";
                        break;
                    case "Xjcg":
                        return "询价采购";
                        break;
                    case "Bxcg":
                        return "比选采购";
                        break;
                    case "GkzbZhpff":
                        return "公开招标(综合评分法)";
                        break;
                    case "GkzbZdjf":
                        return "公开招标(最低价法)";
                        break;
                    case "Dylycg":
                        return "单一来源采购";
                        break;
                    default:
                        return string.Empty;
                }
            }

            var item3 = new[]
            {
                result.Value.Name,
                result.Item3.Note,
                result.Value.PlanWithBudgetOutlays.Sum(r => r.BudgetOutlay.Price * r.BudgetOutlay.Amount)
                    .ToString("N2"),
                result.Item3.Total.ToString("N"),
                result.Item3.Total.ToString("N"),
                result.Value.Date.ToString("yyyy-M-d"),
                dateInfo.Date11.ToString("M.d"),
                dateInfo.Date12.ToString("M.d"),
                dateInfo.Date41.ToString("M.d"),
                dateInfo.Date42.ToString("M.d"),
                dateInfo.Date51.ToString("M.d"),
                dateInfo.Date52.ToString("M.d"),
                result.Item3.PlanDateEnd.ToString("yyyy-M-d"),
                dateInfo.Date2.ToString("M.d"),
                dateInfo.Date31.ToString("M.d"),
                dateInfo.Date32.ToString("M.d"),
                dateInfo.Date6.ToString("M.d"),
                dateInfo.Date71.ToString("M.d"),
                dateInfo.Date72.ToString("M.d"),
                GetModel(result.Value.Mode)
            };

            var ds = new DataSet();
            var dt = new DataTable();


            ds.Tables.Add(dt);

            return new KeyValue<DataSet, string[], object[]>(ds, value, item3);
        }
    }
}
