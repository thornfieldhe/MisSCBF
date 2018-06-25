// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;
using Abp.UI;
using SCBF.BaseInfo;
using SCBF.Common;
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
    /// 采购过程管理服务
    /// </summary>
    [AbpAuthorize]
    public class ProjectManagementAppService : TAFAppServiceBase, IProjectManagementAppService
    {
        private readonly IProjectManagementRepository       _projectManagementRepository;
        private readonly IAuditManagementRepository         _auditManagementRepository;
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IBidOpeningManagementRepository    _bidOpeningManagementRepository;
        private readonly IBiddingManagementRepository       _biddingManagementRepository;
        private readonly IActualOutlayRepository            _actualOutlayRepository;
        private readonly IPerformanceAmountDetailRepository _performanceAmountDetailRepository;
        private readonly IRelationshipRepository            _relationshipRepository;
        private readonly ISysDictionaryRepository           _sysDictionaryRepository;
        private readonly IProcessManagementRepository       _processManagementRepository;
        private readonly IEqManagerRepository _eqManagerRepository;
        private readonly ITendererRepository _tendererRepository;
        private readonly IProcurementPlanRepository         _procurementPlanRepository;

        public ProjectManagementAppService(IProjectManagementRepository projectManagementRepository,
            IAuditManagementRepository                                  auditManagementRepository,
            IBidOpeningManagementRepository bidOpeningManagementRepository,
            IBlacklistRepository blacklistRepository,
            IBiddingManagementRepository                                biddingManagementRepository,
            IActualOutlayRepository                                     actualOutlayRepository,
            IPerformanceAmountDetailRepository                          performanceAmountDetailRepository,
            IRelationshipRepository                                     relationshipRepository,
            ISysDictionaryRepository                                    sysDictionaryRepository,
            IProcessManagementRepository                                processManagementRepository,
            IEqManagerRepository eqManagerRepository,
            ITendererRepository tendererRepository,
            IProcurementPlanRepository                                  procurementPlanRepository)
        {
            this._projectManagementRepository       = projectManagementRepository;
            this._auditManagementRepository         = auditManagementRepository;
            this._blacklistRepository = blacklistRepository;
            this._bidOpeningManagementRepository    = bidOpeningManagementRepository;
            this._biddingManagementRepository       = biddingManagementRepository;
            this._actualOutlayRepository            = actualOutlayRepository;
            this._performanceAmountDetailRepository = performanceAmountDetailRepository;
            this._relationshipRepository            = relationshipRepository;
            this._sysDictionaryRepository           = sysDictionaryRepository;
            this._processManagementRepository       = processManagementRepository;
            this._eqManagerRepository = eqManagerRepository;
            this._tendererRepository = tendererRepository;
            this._procurementPlanRepository         = procurementPlanRepository;
        }

        public ListResultDto<ProjectManagementListDto> GetAll(ProjectManagementQueryDto request)
        {
            var query = (from b in this._projectManagementRepository.GetAll()
                join p in this._procurementPlanRepository.GetAll() on b.PlanId equals p.Id
                join s in this._bidOpeningManagementRepository.GetAll() on b.PlanId equals s.PlanId
                where (string.IsNullOrEmpty(request.Name) || p.Name.Contains(request.Name)) &&
                      (string.IsNullOrEmpty(request.Code) || p.Code.Contains(request.Code))
                select new
                {
                    Code        = p.Code,
                    Name        = p.Name,
                    Id          = b.Id,
                    PlanId      = p.Id,
                    Date1       = b.Date1,
                    Price1      = s.Price,
                    CreatedDate = p.CreationTime
                }).OrderByDescending(r => r.CreatedDate);
            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = new List<ProjectManagementListDto>();
            foreach (var l in list)
            {
                var item = new ProjectManagementListDto
                {
                    Code   = l.Code,
                    Name   = l.Name,
                    Id     = l.Id,
                    PlanId = l.PlanId,
                    Price1 = l.Price1.ToString("N"),
                    Date1  = l.Date1.ToString("yyyy-MM-dd"),
                    Price2 = this._auditManagementRepository.GetAllList(r => r.ProjectId == l.Id)
                        .Sum(r => r.Price).ToString("N")
                };

                dtos.Add(item);
            }

            return new PagedResultDto<ProjectManagementListDto>(count, dtos);
        }

        public ProjectManagementEditDto Get(Guid id)
        {
            var output = this._projectManagementRepository.Get(id);
            return output.MapTo<ProjectManagementEditDto>();
        }

        public async Task SaveAsync(ProjectManagementEditDto input)
        {
            if (this._projectManagementRepository.Any(r =>
                r.PlanId == input.PlanId &&
                (input.Id != r.Id || !input.Id.HasValue)))
            {
                throw new UserFriendlyException("不能重复添加采购计划");
            }

            var item = input.MapTo<ProjectManagement>();
            if (!input.Id.HasValue)
            {
                item.HasPrint = 1;
                await this._projectManagementRepository.InsertAsync(item);
            }
            else
            {
                var old = this._projectManagementRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._projectManagementRepository.UpdateAsync(old);
            }
        }

        public void SavePrice(ProjectManagementSavePriceDto item)
        {
            this._projectManagementRepository.Update(item.Id, r =>
            {
                r.HasPrint = item.HasPrint;
                r.Price    = item.Price;
            });
        }

        public string ExportDoc1(Guid id)
        {
            return DownloadFileService.Load("审计结果公示模板.doc", "审计结果公示.doc", new string[] { })
                .ExcuteDoc(id.ToString(), this.ExportToDoc1);
        }

        public string ExportDoc2(Guid id)
        {
            return DownloadFileService.Load("年度采购工作情况报告模板.doc", "年度采购工作情况报告.doc", new string[] { })
                .ExcuteDoc(id.ToString(), this.ExportToDoc2);
        }

        private KeyValue<DataSet, string[], object[]> ExportToDoc1(object arg)
        {
            var id = new Guid(arg.ToString());
            var value = new[]
            {
                "项目名称",
                "立项资金",
                "招标控制价",
                "招标方式",
                "中标单位",
                "合同金额",
                "报审价",
                "审定价",
                "审增减额",
                "审增减率",
                "节约资金",
                "招标代理单位",
                "招标代理费",
                "监理单位",
                "监理费",
                "造价单位",
                "造价费",
                "设计单位",
                "设计费",
                "时间",
            };

            var item  = this._projectManagementRepository.Get(id);
            var item1 = this._procurementPlanRepository.FirstOrDefault(r => r.Id          == item.PlanId);
            var item2 = this._biddingManagementRepository.FirstOrDefault(r => r.PlanId    == item.PlanId);
            var item4 = this._bidOpeningManagementRepository.FirstOrDefault(r => r.PlanId == item.PlanId);
            var units = (from a in this._processManagementRepository.GetAll()
                join b in this._sysDictionaryRepository.GetAll() on a.Unit equals b.Id
                where a.PurchaseId == item.PlanId
                select new {Type = a.Type, Name = b.Value, Price = a.Price}).ToList();
            var    price      = this._auditManagementRepository.GetAllList(r => r.ProjectId == id);
            var    auditPrice = item.Price ?? 0M;
            string mode;
            switch (item1.Mode)
            {
                case "Yqzb":
                    mode = "邀请招标";
                    break;
                case "Jzxtp":
                    mode = "竞争性谈判";
                    break;
                case "Xjcg":
                    mode = "询价采购";
                    break;
                case "Bxcg":
                    mode = "比选采购";
                    break;
                case "GkzbZhpff":
                    mode = "公开招标(综合评分法)";
                    break;
                case "GkzbZdjf":
                    mode = "公开招标(最低价法)";
                    break;
                case "Dylycg":
                    mode = "单一来源采购";
                    break;
                default:
                    mode = string.Empty;
                    break;
            }


            var item3 = new[]
            {
                item1.Name,
                item1.PlanWithBudgetOutlays.Sum(r => r.BudgetOutlay.Amount * r.BudgetOutlay.Price).ToString(),
                item2.Total.ToString(),
                mode,
                item4.SuccessfulTender,
                item4.Price.ToString(),
                item.Price.Value.ToString(),
                (auditPrice + price.Sum(r => r.Price)).ToString(),
                price.Sum(r => r.Price).ToString(),
                (auditPrice != 0 ? price.Sum(r => r.Price) / auditPrice * 100 : 0).ToFixed(2).ToString() + "%",
                price.Sum(r => -r.Price).ToString(),
                units.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_BiddingAgency)?.Name,
                units.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_BiddingAgency)?.Price.ToString(),
                units.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_ConstructionControlUnit)?.Name,
                units.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_ConstructionControlUnit)?.Price
                    .ToString(),
                units.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_CostUnit)?.Name,
                units.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_CostUnit)?.Price.ToString(),
                units.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_DesignUnit)?.Name,
                units.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_DesignUnit)?.Price.ToString(),
                DateTime.Now.ToString("yyyy年M月d日")
            };

            var ds = new DataSet();
            var dt = new DataTable();
            ds.Tables.Add(dt);

            return new KeyValue<DataSet, string[], object[]>(ds, value, item3);
        }

        public string ExportDoc3()
        {
            return DownloadFileService.Load("年度采购工作情况报告模板.doc", "年度采购工作情况报告.doc", new string[] { })
                .ExcuteDoc(null, this.ExportToDoc3);
        }

        private KeyValue<DataSet, string[], object[]> ExportToDoc3(object arg)
        {
            var value = new[]
            {
                "年度",
                "采购个数",
                "采购总预算",
                "执行个数",
                "执行预算",
                "执行率",
                "节约资金",
                "供应商黑名单",
                "服务机构数",
                "招标代理机构数",
                "监理机构数",
                "造价结构数",
                "设计机构数",
                "甲方代表数",
                "招标代理费",
                "监理费",
                "造价费",
                "设计费",
                "代表工资",
                "开支占比",
                "优质机构",
                "良好机构",
                "合格机构",
                "未达标机构",
                "时间"
            };

            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var plans = this._procurementPlanRepository.GetAllList(r => r.Year == year);
            var planIds = plans.Select(r => r.Id).ToList();
            var processes = this._processManagementRepository.GetAllList(r => planIds.Contains(r.PurchaseId));
            var bids=this._biddingManagementRepository.GetAllList(r => planIds.Contains(r.PlanId));
            var bios=this._bidOpeningManagementRepository.GetAllList(r => planIds.Contains(r.PlanId));
            var projects=this._projectManagementRepository.GetAllList(r => planIds.Contains(r.PlanId));
            var projectIds = projects.Select(r => r.Id).ToList();
            var audits = this._auditManagementRepository.GetAllList(r=>projectIds.Contains(r.ProjectId));//执行预算,审定造价总和

            var price1 = plans.SelectMany(r => r.PlanWithBudgetOutlays).Select(r => r.BudgetOutlay)
                .Sum(r => r.Price * r.Amount);// 采购预算
            var price2 = projects.Sum(r => r.Price??0) + audits.Sum(r => r.Price);//审定造价
            var blacklist = this._blacklistRepository.GetAllList(r => r.Year == year).ToList();
            var scoreLevel = this._sysDictionaryRepository
                .Get(r => r.Category == DictionaryCategory.Purchase_SystemScore).FirstOrDefault();
            var eqs = this._eqManagerRepository.GetAllList(r => planIds.Contains(r.PlanId));
            var unites = new List<KeyValue<Guid, decimal>> ();
            foreach (var eq in eqs)
            {
                var i1 = unites.FirstOrDefault(r => r.Key == eq.Unit1.Value);
                if (i1!=null && i1.Value>eq.Score1.Value)
                {
                    i1.Value = eq.Score1.Value;
                }
                else if (i1 == null)
                {
                    unites.Add(new KeyValue<Guid, decimal>(eq.Unit1.Value,eq.Score1.Value));
                }

                var i2 = unites.FirstOrDefault(r => r.Key == eq.Unit2.Value);
                if (i2 !=null && i2.Value>eq.Score2.Value)
                {
                    i2.Value = eq.Score2.Value;
                }
                else if (i2 == null)
                {
                    unites.Add(new KeyValue<Guid, decimal>(eq.Unit2.Value,eq.Score2.Value));
                }

                var i3 = unites.FirstOrDefault(r => r.Key == eq.Unit3.Value);
                if (i3 !=null && i3.Value>eq.Score3.Value)
                {
                    i3.Value = eq.Score3.Value;
                }
                else if (i3 == null)
                {
                    unites.Add(new KeyValue<Guid, decimal>(eq.Unit3.Value,eq.Score3.Value));
                }

                var i4 = unites.FirstOrDefault(r => r.Key == eq.Unit4.Value);
                if (i4 !=null && i4.Value>eq.Score4.Value)
                {
                    i4.Value = eq.Score4.Value;
                }
                else if (i4 == null)
                {
                    unites.Add(new KeyValue<Guid, decimal>(eq.Unit4.Value,eq.Score4.Value));
                }
            }

            var uids = unites.Select(r => r.Key).ToList();

            var uNames = this._sysDictionaryRepository.GetAllList(r => uids.Contains(r.Id))
                .Select(r=>new {Key = r.Id, Value = r.Value});

            var uN = from u in unites
                join un in uNames on u.Key equals un.Key
                select new {Id = u.Key, Score = u.Value, Name = un.Value};

            var unit1 = uN.Count(r=>r.Score==decimal.Parse(scoreLevel.Value))==0?"无":string.Join(",",uN.Where(r=>r.Score ==decimal.Parse(scoreLevel.Value)).Select(u=>u.Name));//优质机构
            var unit2 = uN.Count(r=>r.Score <decimal.Parse(scoreLevel.Value) && r.Score >=decimal.Parse(scoreLevel.Value2)) ==0?"无":string.Join(",",uN.Where(r=>r.Score <decimal.Parse(scoreLevel.Value) && r.Score >=decimal.Parse(scoreLevel.Value2)).Select(u=>u.Name));;//良好机构
            var unit3=uN.Count(r=>r.Score <decimal.Parse(scoreLevel.Value2) && r.Score >=decimal.Parse(scoreLevel.Value3)) ==0?"无":string.Join(",",uN.Where(r=>r.Score <decimal.Parse(scoreLevel.Value2) && r.Score >=decimal.Parse(scoreLevel.Value3)).Select(u=>u.Name));; //合格机构
            var unit4=uN.Count(r=>r.Score <decimal.Parse(scoreLevel.Value3)) ==0?"无":string.Join(",",uN.Where(r=>r.Score <decimal.Parse(scoreLevel.Value3)).Select(u=>u.Name)); //不合格机构
            var item3 = new[]
            {
                currentYearItem.Value,
                plans.Count.ToString(),
                price1.ToString(),
                projects.Count.ToString(),
                price2.ToString(),
                (price2/ price1*100).ToString("N0"),
                (projects.Sum(r=>r.Price) -price2).ToString(),
                string.Join(",",blacklist.Where(r=>r.Type==DictionaryCategory.Purchase_Supplier).Select(r=>r.Name)),
                processes.Select(r=>r.Unit).Distinct().Count().ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_BiddingAgency).Select(r=>r.Unit).Distinct().Count().ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_ConstructionControlUnit).Select(r=>r.Unit).Distinct().Count().ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_CostUnit).Select(r=>r.Unit).Distinct().Count().ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_DesignUnit).Select(r=>r.Unit).Distinct().Count().ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_PartyA).Select(r=>r.Unit).Distinct().Count().ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_BiddingAgency).Sum(r=>r.Price).ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_ConstructionControlUnit).Sum(r=>r.Price).ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_CostUnit).Sum(r=>r.Price).ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_DesignUnit).Sum(r=>r.Price).ToString(),
                processes.Where(r=>r.Type ==DictionaryCategory.Purchase_PartyA).Sum(r=>r.Price).ToString(),
                (processes.Sum((r=>r.Price)) /price1).ToString(),
                unit1,
                unit2,
                unit3,
                unit4,
                DateTime.Now.ToString("yyyy年M月d日")
            };

            var ds = new DataSet();
            var dt = new DataTable("Projects");
            dt.Columns.Add("项目名称");
            dt.Columns.Add("招标方式");
            dt.Columns.Add("投标单位数量");
            dt.Columns.Add("中标单位");
            dt.Columns.Add("合同价");
            dt.Columns.Add("开工时间");
            dt.Columns.Add("竣工时间");
            dt.Columns.Add("报审价");
            dt.Columns.Add("审定价");
            dt.Columns.Add("增减额");
            dt.Columns.Add("增减率");
            dt.Columns.Add("质保金");
            dt.Columns.Add("审计费");
            dt.Columns.Add("尾款");
            foreach (var pro in projects)
            {
                var plan = plans.First(r => r.Id == pro.PlanId);
                var bid = bids.First(r => r.PlanId == pro.PlanId);
                var tenders = this._tendererRepository.Count(r => r.BiddingManagementId == bid.Id);
                var row = dt.NewRow();
                row["项目名称"]=plan.Name;
                switch (plan.Mode)
                {
                    case "Yqzb":
                        row["招标方式"] = "邀请招标";
                        break;
                    case "Jzxtp":
                        row["招标方式"] = "竞争性谈判";
                        break;
                    case "Xjcg":
                        row["招标方式"] = "询价采购";
                        break;
                    case "Bxcg":
                        row["招标方式"] = "比选采购";
                        break;
                    case "GkzbZdjf":
                        row["招标方式"] = "公开招标(最低价法)";
                        break;
                    case "GkzbZhpff":
                        row["招标方式"] = "公开招标(综合评分法)";
                        break;
                    case "Dylycg":
                        row["招标方式"] = "单一来源采购";
                        break;
                }

                var usedPrice = (from a in this._projectManagementRepository.GetAll()
                    join b in this._relationshipRepository.GetAll() on a.Id equals b.PrincipalKey
                    join c in this._actualOutlayRepository.GetAll() on b.ForeignKey equals c.Id
                    select c.Amount).ToList().Sum();
                var auditPrice = pro.Price ?? 0M;
                var price = this._auditManagementRepository.GetAllList(r => r.ProjectId == pro.Id);

                row["投标单位数量"]= tenders.ToString();
                row["中标单位"]= bios.First(r=>r.PlanId ==pro.PlanId).SuccessfulTender;
                row["合同价"]= bios.First(r=>r.PlanId ==pro.PlanId).Price.ToString();
                row["开工时间"]=pro.Date1.ToString("yyyy年M月d日");
                row["竣工时间"]= pro.Date2.Value.ToString("yyyy年M月d日");
                row["报审价"]=pro.Price.Value.ToString();
                row["审定价"]= auditPrice + price.Sum(r => r.Price);
                row["增减额"]= price.Sum(r => r.Price);
                row["增减率"]= (auditPrice != 0 ? price.Sum(r => r.Price) / auditPrice *100 : 0).ToFixed(2);
                row["质保金"]= (auditPrice + price.Sum(r => r.Price)) * 0.05M;
                row["审计费"]= auditPrice == 0
                    ? 0
                    : (price.Sum(r => Math.Abs(r.Price)) / auditPrice > 0.03M
                        ? price.Sum(r => r.Price) * 0.05M
                        : 0M);
                row["尾款"]= auditPrice + price.Sum(r => r.Price) * 0.95M - usedPrice;
                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            return new KeyValue<DataSet, string[], object[]>(ds, value, item3);
        }

        private KeyValue<DataSet, string[], object[]> ExportToDoc2(object arg)
        {
            var id = new Guid(arg.ToString());
            var value = new[]
            {
                "项目名称",
                "竣工日期",
                "中标单位",
                "合同金额",
                "审定造价",
                "已扣质保金",
                "剩余质保金",
                "情况说明",
                "部门",
                "联系人",
                "电话",
                "扣除金额",
                "日期",
                "质保金",
                "已付金额"
            };
            var detail = this._performanceAmountDetailRepository.Get(id);
            var item   = this._projectManagementRepository.Get(detail.PerformanceManageId);
            var usedAmount = this._performanceAmountDetailRepository
                .GetAllList(r => r.PerformanceManageId == item.Id
                                 && r.CreationTime     < detail.CreationTime)
                .Sum(r => r.Amount);
            var bidOping = this._bidOpeningManagementRepository.FirstOrDefault(r => r.PlanId == item.PlanId);
            var project  = this._procurementPlanRepository.Get(bidOping.PlanId);
            var price    = this._auditManagementRepository.GetAllList(r => r.ProjectId == id);

            var price2 = (from a in this._relationshipRepository.GetAll()
                join b in this._actualOutlayRepository.GetAll() on a.ForeignKey equals b.Id
                where a.PrincipalKey == item.Id
                select b.Amount).ToList().Sum();
            var item3 = new[]
            {
                project.Name,
                item.Date2.Value.ToString("yyyy年MM月dd日"),
                bidOping.SuccessfulTender,
                bidOping.Price.ToString(),
                (price.Sum(r => r.Price) + item.Price ?? 0).ToString(),
                usedAmount.ToString(),
                ((item.Price ?? 0 + price.Sum(r => r.Price)) * 0.05M - usedAmount).ToString(),
                detail.Note,
                detail.Department,
                detail.User,
                detail.Phone,
                detail.Amount.ToString(),
                DateTime.Now.ToString("yyyy年MM月dd日"),
                ((item.Price ?? 0) * 0.05M).ToString(),
                price2.ToString()
            };

            var ds = new DataSet();
            var dt = new DataTable("");

            ds.Tables.Add(dt);

            return new KeyValue<DataSet, string[], object[]>(ds, value, item3);
        }

        public ProjectManagementPriceDto ComputePrice(Guid id)
        {
            var price1 = (from a in this._projectManagementRepository.GetAll()
                join
                    b in this._bidOpeningManagementRepository.GetAll() on a.PlanId equals b.PlanId
                where a.Id == id
                select b.Price).First();

            var price2 = (from a in this._relationshipRepository.GetAll()
                join b in this._actualOutlayRepository.GetAll() on a.ForeignKey equals b.Id
                where a.PrincipalKey == id
                select b.Amount).ToList().Sum();
            return new ProjectManagementPriceDto()
            {
                Id     = id,
                Price1 = price1,
                Price2 = price1 * 0.8M - price2,
                Price3 = price1        - price2
            };
        }

        public void Delete(Guid id)
        {
            this._projectManagementRepository.Delete(id);
        }

        public List<Guid> GetAttachments(Guid id)
        {
            var plan   = this._procurementPlanRepository.Get(id);
            var result = new List<Guid>();
            var l2 = this._processManagementRepository
                .FirstOrDefault(r => r.PurchaseId == id && r.Type == DictionaryCategory.Purchase_DesignUnit);
            var l3 = this._processManagementRepository
                .FirstOrDefault(r => r.PurchaseId == id && r.Type == DictionaryCategory.Purchase_CostUnit);
            var l4 = this._processManagementRepository
                .FirstOrDefault(
                    r => r.PurchaseId == id && r.Type == DictionaryCategory.Purchase_ConstructionControlUnit);
            var l5 = this._processManagementRepository
                .FirstOrDefault(r => r.PurchaseId == id && r.Type == DictionaryCategory.Purchase_BiddingAgency);
            var l6 = this._biddingManagementRepository.FirstOrDefault(r => r.PlanId    == id);
            var l7 = this._bidOpeningManagementRepository.FirstOrDefault(r => r.PlanId == id);
            var l8 = this._projectManagementRepository.FirstOrDefault(r => r.PlanId    == id);
            result.Add(l2 == null ? Guid.Empty : l2.Id);
            result.Add(l3 == null ? Guid.Empty : l3.Id);
            result.Add(l4 == null ? Guid.Empty : l4.Id);
            result.Add(l5 == null ? Guid.Empty : l5.Id);
            result.Add(l6 == null ? Guid.Empty : l6.Id);
            result.Add(l7 == null ? Guid.Empty : l7.Id);
            result.Add(l8 == null ? Guid.Empty : l8.Id);
            return result;
        }
    }
}
