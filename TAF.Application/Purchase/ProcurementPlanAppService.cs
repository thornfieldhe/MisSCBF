// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlanAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;
using Abp.UI;
using Aspose.Cells;
using SCBF.BaseInfo;
using SCBF.Common;
using SCBF.Finance;

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
        private readonly IProcurementPlanRepository      _procurementPlanRepository;
        private readonly IPlanWithBudgetOutlayRepository _planWithBudgetOutlayRepository;
        private readonly IProcessManagementRepository    _processManagementRepository;
        private readonly IBidOpeningManagementRepository _bidOpeningManagementRepository;
        private readonly ISysDictionaryRepository        _sysDictionaryRepository;

        public ProcurementPlanAppService(IProcurementPlanRepository procurementPlanRepository,
            IPlanWithBudgetOutlayRepository                         planWithBudgetOutlayRepository,
            IProcessManagementRepository                            processManagementRepository,
            IBidOpeningManagementRepository                         bidOpeningManagementRepository,
            ISysDictionaryRepository                                sysDictionaryRepository)
        {
            this._procurementPlanRepository      = procurementPlanRepository;
            this._planWithBudgetOutlayRepository = planWithBudgetOutlayRepository;
            this._processManagementRepository    = processManagementRepository;
            this._bidOpeningManagementRepository = bidOpeningManagementRepository;
            this._sysDictionaryRepository        = sysDictionaryRepository;
        }

        public ListResultDto<ProcurementPlanListDto> GetAll(ProcurementPlanQueryDto request)
        {
            var query = this._procurementPlanRepository.GetAll()
                .WhereIf(request.Type.HasValue, r => r.Type                            == request.Type)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Category), r => r.Category == request.Category)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Mode), r => r.Mode         == request.Mode)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Code), r => r.Code.Contains(request.Code))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), r => r.Name.Contains(request.Name))
                .WhereIf(request.Department.HasValue, r => r.Department == request.Department.Value)
                .WhereIf(request.User.HasValue, r => r.User             == request.User.Value)
                .WhereIf(request.Date.HasValue, r => r.Date             == request.Date.Value)
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

                switch (dto.Type)
                {
                    case "0":
                        dto.TypeName = "年度预算";
                        break;
                    case "1":
                        dto.TypeName = "调整后预算";
                        break;
                    case "2":
                        dto.TypeName = "调整后增加预算";
                        break;
                }
            }

            return new PagedResultDto<ProcurementPlanListDto>(count, dtos);
        }


        public string ExportExs()
        {
            var result = this.LoadData();

            return DownloadFileService.Load("procurementPlan.xls", "年度采购计划.xls", new string[] { })
                .ExcuteXls(result.OrderBy(r => r.Category).ToList(), this.ExportToXls);
        }


        public string ExportDoc()
        {
            var result = this.LoadData();
            return DownloadFileService.Load("procurementPlanReport.doc", "年度采购计划报告.doc", new string[] { })
                .ExcuteDoc(result.OrderBy(r => r.Category).ToList(), this.ExportToDoc);
        }

        public ProcurementPlanEditDto Get(Guid id)
        {
            var output = this._procurementPlanRepository.Get(id);
            return output.MapTo<ProcurementPlanEditDto>();
        }

        public async Task SaveAsync(ProcurementPlanEditDto input)
        {
            var item = input.MapTo<ProcurementPlan>();
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            item.Year = year;
            if (!input.Id.HasValue)
            {
                item.Code = this.GetMaxCode(DateTime.Parse(input.Date));
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

        public EqManagerEditDto GetInfo(Guid id)
        {
            var processes = this._processManagementRepository.Get(r => r.PurchaseId == id);
            var result = new EqManagerEditDto()
            {
                PlanId = id,
                Unit1  = processes.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_BiddingAgency).Unit,
                Unit2 = processes.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_ConstructionControlUnit)
                    .Unit,
                Unit3 = processes.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_CostUnit).Unit,
                Unit4 = processes.FirstOrDefault(r => r.Type == DictionaryCategory.Purchase_DesignUnit).Unit,
                Unit5 = this._bidOpeningManagementRepository.FirstOrDefault(r => r.PlanId == id).SuccessfulTender
            };

            result.UnitName1 = this._sysDictionaryRepository.Get(result.Unit1.Value).Value;
            result.UnitName2 = this._sysDictionaryRepository.Get(result.Unit2.Value).Value;
            result.UnitName3 = this._sysDictionaryRepository.Get(result.Unit3.Value).Value;
            result.UnitName4 = this._sysDictionaryRepository.Get(result.Unit4.Value).Value;
            return result;
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

        private WorkbookDesigner ExportToXls(WorkbookDesigner designer, List<ProcurementPlanListSummaryDto> list)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            designer.Workbook.Worksheets[0].Cells[0, 0].Value = $"{currentYearItem.Value}年度采购计划表";

            // 设置样式
            var st = new Style
            {
                Font                = {Size = 10, Name = "宋体"},
                Pattern             = BackgroundType.Solid,
                HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
            };
            st.Borders[BorderType.LeftBorder].LineStyle   = CellBorderType.Thin; //应用边界线 左边界线
            st.Borders[BorderType.RightBorder].LineStyle  = CellBorderType.Thin; //应用边界线 右边界线
            st.Borders[BorderType.TopBorder].LineStyle    = CellBorderType.Thin; //应用边界线 上边界线
            st.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            Cells cells = designer.Workbook.Worksheets[0].Cells;

            var numStart = 5;
            var index1   = numStart;
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].Details.Count > 0)
                {
                    var columnNum = list[i].Details.Count;
                    cells.Merge(index1, 0, columnNum, 1);
                    cells.Merge(index1, 1, columnNum, 1);
                    cells.Merge(index1, 2, columnNum, 1);
                    cells.Merge(index1, 9, columnNum, 1);
                    cells.Merge(index1, 10, columnNum, 1);
                    cells.Merge(index1, 11, columnNum, 1);
                    cells.Merge(index1, 12, columnNum, 1);

                    var cell0  = designer.Workbook.Worksheets[0].Cells[index1, 0];
                    var cell1  = designer.Workbook.Worksheets[0].Cells[index1, 1];
                    var cell2  = designer.Workbook.Worksheets[0].Cells[index1, 2];
                    var cell9  = designer.Workbook.Worksheets[0].Cells[index1, 9];
                    var cell10 = designer.Workbook.Worksheets[0].Cells[index1, 10];
                    var cell11 = designer.Workbook.Worksheets[0].Cells[index1, 11];
                    var cell12 = designer.Workbook.Worksheets[0].Cells[index1, 12];

                    cell0.Value  = list[i].Category;
                    cell1.Value  = list[i].Name;
                    cell2.Value  = list[i].TotalPrice.ToString("N");
                    cell9.Value  = list[i].Month + "月";
                    cell10.Value = list[i].Mode;
                    cell11.Value = list[i].Department;
                    cell12.Value = list[i].User;


                    index1 += columnNum;
                }
            }


            var categorie = list.GroupBy(r => r.Category)
                .Select(r => new KeyValue<string, int>() {Key = r.Key, Value = r.Sum(l => l.Details.Count)});
            var index2 = 5;
            foreach (var category in categorie)
            {
                cells.Merge(index2, 0, category.Value, 1);
                index2 += category.Value;
            }

            var details = list.SelectMany(r => r.Details).ToList();
            var index   = 5;
            for (var i = 0; i < details.Count; i++)
            {
                var cell3 = designer.Workbook.Worksheets[0].Cells[index, 3];
                var cell4 = designer.Workbook.Worksheets[0].Cells[index, 4];
                var cell5 = designer.Workbook.Worksheets[0].Cells[index, 5];
                var cell6 = designer.Workbook.Worksheets[0].Cells[index, 6];
                var cell7 = designer.Workbook.Worksheets[0].Cells[index, 7];
                var cell8 = designer.Workbook.Worksheets[0].Cells[index, 8];
                cell3.Value = details[i].Name;
                cell4.Value = details[i].Unit;
                cell5.Value = details[i].Amount.ToString("N");
                cell6.Value = details[i].Price.ToString("N");
                cell7.Value = details[i].Totale.ToString("N");
                cell8.Value = details[i].Code;
                index++;
            }

            for (var i = 5; i < 500; i++)
            {
                if (designer.Workbook.Worksheets[0].Cells[i, 4].StringValue == "")
                {
                    break;
                }

                for (var j = 0; j <= 12; j++)
                {
                    designer.Workbook.Worksheets[0].Cells[i, j].SetStyle(st);
                }
            }

            return designer;
        }

        private KeyValue<DataSet, string[], object[]> ExportToDoc(object ls)
        {
            List<ProcurementPlanListSummaryDto> list = ls as List<ProcurementPlanListSummaryDto>;
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var categorie = list.GroupBy(r => r.Category)
                .Select(r => new KeyValue<string, int>() {Key = r.Key, Value = r.Sum(l => l.Details.Count)});
            var keys = new string[] {"Year", "Category", "Project", "Date"};
            var values = new object[]
                {currentYearItem.Value, categorie.Count(), list.Count, DateTime.Now.ToString("yyy-MM-dd")};
            var ds = new DataSet();
            var dt = new DataTable("List");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Name");
            dt.Columns.Add("Month");
            dt.Columns.Add("Mode");
            dt.Columns.Add("Department");
            dt.Columns.Add("User");
            foreach (var item in list)
            {
                var row = dt.NewRow();
                row["Amount"]     = (item.TotalPrice / 10000).ToString("N");
                row["Name"]       = item.Name;
                row["Month"]      = item.Month;
                row["Mode"]       = item.Mode;
                row["Department"] = item.Department;
                row["User"]       = item.User;
                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);
            return new KeyValue<DataSet, string[], object[]>(ds, keys, values);
        }

        private List<ProcurementPlanListSummaryDto> LoadData()
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var dateFrom = new DateTime(int.Parse(currentYearItem.Value), 1, 1);
            var dateTo   = new DateTime(int.Parse(currentYearItem.Value) + 1, 1, 1);
            var list = this._procurementPlanRepository.GetAllList(r => r.Date >= dateFrom && r.Date < dateTo)
                .OrderByDescending(r => r.Code).ToList();


            var result = new List<ProcurementPlanListSummaryDto>();
            foreach (var item in list)
            {
                var s = new ProcurementPlanListSummaryDto()
                {
                    Code       = item.Code,
                    Name       = item.Name,
                    Category   = LoadCategory(item.Category),
                    Id         = item.Id,
                    User       = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == item.User)?.Value,
                    Department = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == item.Department)?.Value,
                    Type       = LoadType(item.Type),
                    Mode       = LoadModel(item.Mode),
                    Month      = item.Date.Month.ToString(),
                    Details    = new List<BudgetOutlaySummaryDto>()
                };
                var details = this._planWithBudgetOutlayRepository.GetAllList(r => r.ProcurementPlanId == item.Id)
                    .Select(r => r.BudgetOutlay);
                foreach (var detail in details)
                {
                    var d = new BudgetOutlaySummaryDto()
                    {
                        Code            = detail.Code,
                        Name            = detail.Name,
                        Amount          = detail.Amount,
                        BudgetReceiptId = detail.BudgetReceiptId.Value,
                        Price           = detail.Price,
                        Unit            = detail.Unit
                    };
                    s.Details.Add(d);
                }

                result.Add(s);
            }


            string LoadType(BungetType type)
            {
                switch (type)
                {
                    case BungetType.Year:
                        return "年度预算";
                    case BungetType.Adjust:
                        return "调整后预算";
                    case BungetType.Increase:
                        return "调整后增加预算";
                }

                return string.Empty;
            }

            string LoadCategory(string category)
            {
                switch (category)
                {
                    case "Zccg":
                        category = "资产采购";
                        break;
                    case "Fwcg":
                        category = "服务采购";
                        break;
                    case "Xxhcg":
                        category = "信息化采购";
                        break;
                    case "Gccg":
                        category = "工程采购";
                        break;
                }

                return category;
            }

            string LoadModel(string key)
            {
                switch (key)
                {
                    case "Yqzb":
                        return "邀请招标";
                    case "Jzxtp":
                        return "竞争性谈判";
                    case "Xjcg":
                        return "询价采购";
                    case "Bxcg":
                        return "比选采购";
                    case "GkzbZdjf":
                        return "公开招标(最低价法)";
                    case "GkzbZhpff":
                        return "公开招标(综合评分法)";
                    case "Dylycg":
                        return "单一来源采购";
                }

                return string.Empty;
            }

            return result;
        }
    }
}
