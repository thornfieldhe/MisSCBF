// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetOutlayAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   支出预算服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using Aspose.Cells;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SCBF.Common;

namespace SCBF.Finance
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Dynamic;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;
    using BaseInfo;
    using Dto;
    using TAF.Utility;

    /// <summary>
    /// 支出预算服务
    /// </summary>
    [AbpAuthorize]
    public class BudgetOutlayAppService : TAFAppServiceBase, IBudgetOutlayAppService
    {
        private readonly IBudgetOutlayRepository  _budgetOutlayRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;
        private readonly IBudgetReceiptRepository _budgetReceiptRepository;
        private readonly IActualOutlayRepository  _actualOutlayRepository;
        private readonly ILayerRepository         _layerRepository;
        private readonly IOutlayRepository        _outlayRepository;
        private          IWorkbook                _workbook = null;

        public BudgetOutlayAppService(
            IBudgetOutlayRepository  budgetOutlayRepository,
            ISysDictionaryRepository sysDictionaryRepository,
            IBudgetReceiptRepository budgetReceiptRepository,
            ILayerRepository         layerRepository,
            IActualOutlayRepository  actualOutlayRepository,
            IOutlayRepository        outlayRepository)
        {
            this._budgetOutlayRepository  = budgetOutlayRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
            this._budgetReceiptRepository = budgetReceiptRepository;
            this._actualOutlayRepository  = actualOutlayRepository;
            this._layerRepository         = layerRepository;
            this._outlayRepository        = outlayRepository;
        }

        public List<BudgetOutlayListDto> Get(string sheetName, int type)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var result =
                this._budgetOutlayRepository.GetAllList(r =>
                        r.Year == year && r.SheetName == sheetName && !r.HasRelated && (int) r.Type == type)
                    .OrderBy(r => r.Code).ToList().MapTo<List<BudgetOutlayListDto>>();
            return result;
        }

        public List<OutlayListDto> GetAll()
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var result =
                this._budgetOutlayRepository.GetAllList(r => r.Year == year && r.HasRelated).OrderBy(r => r.Code)
                    .ToList().MapTo<List<OutlayListDto>>();
            return result;
        }

        public List<BudgetOutlaySimpleListDto> GetSimple()
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString()
                                                                                   && r.Category ==
                                                                                   DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var result =
                this._budgetOutlayRepository.GetAllList(r => r.Year == year
                                                            && r.HasRelated).OrderBy(r => r.Code).ToList()
                    .MapTo<List<BudgetOutlaySimpleListDto>>().Where(r => r.UnUsed > 0).ToList();
            return result;
        }

        public List<BudgetPerformanceListDto> GetBudgetPerformances()
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var accounts = this._layerRepository.GetAllList(r => r.Category == DictionaryCategory.Budget_Account);


            var result = this._budgetReceiptRepository.GetAllList(r => r.Year.ToString() == currentYearItem.Value)
                .OrderBy(r => r.Code).ToList();
            var result0 = this._budgetOutlayRepository
                .GetAllList(r => r.Year.ToString() == currentYearItem.Value && r.HasRelated).OrderBy(r => r.Code)
                .ToList();
            var codeList = result.Select(r => r.Code).Distinct().ToList();
            var list     = new List<BudgetPerformanceListDto>();
            foreach (var code in codeList)
            {
                var receipt = result.FirstOrDefault(r => r.Code == code);
                var outlay1 = result0.Where(r => r.Code == code && r.Type == BungetType.Year).ToList();
                var outlay2 = result0.Where(r => r.Code == code && r.Type == BungetType.Adjust).ToList();
                var outlay3 = result0.Where(r => r.Code == code && r.Type == BungetType.Increase).ToList();
                var outlay =
                    this._outlayRepository.FirstOrDefault(r =>
                        r.Code == code && r.Year.ToString() == currentYearItem.Value);

                if (receipt == null)
                {
                    throw new UserFriendlyException($"科目编码为[{code}]的年初预算收入不存在");
                }

                var performance = new BudgetPerformanceListDto
                {
                    Id     = receipt.Id,
                    Code   = code,
                    Name   = accounts.FirstOrDefault(r => r.LevelCode == code)?.Name,
                    Total2 = result.Where(r => r.Code == code).Sum(r => r.Column1),
                    Total3 = result.Where(r => r.Code == code).Sum(r => r.Column21 + r.Column22),
                    Total4 = result.Where(r => r.Code == code).Sum(r =>
                        r.Column31 + r.Column32 + r.Column33 + r.Column34 + r.Column35 + r.Column36 + r.Column37),
                    Total5 = result.Where(r => r.Code == code).Sum(r =>
                        r.Column41 + r.Column42 + r.Column43 + r.Column44 + r.Column45 + r.Column46 + r.Column47),
                    Total8  = outlay1.Any() ? outlay1.Sum(r => r.Column1) : 0,
                    Total9  = outlay1.Any() ? outlay1.Sum(r => r.Column2) : 0,
                    Total10 = outlay1.Any() ? outlay1.Sum(r => r.Column3) : 0,
                    Total12 = outlay2.Any() ? outlay2.Sum(r => r.Column1) : 0,
                    Total13 = outlay2.Any() ? outlay2.Sum(r => r.Column2) : 0,
                    Total14 = outlay2.Any() ? outlay2.Sum(r => r.Column3) : 0,
                    Total16 = outlay3.Any() ? outlay3.Sum(r => r.Column1) : 0,
                    Total17 = outlay3.Any() ? outlay3.Sum(r => r.Column2) : 0,
                    Total18 = outlay3.Any() ? outlay3.Sum(r => r.Column3) : 0,
                    Total19 = decimal.Round(
                        ((!outlay1.Any() ? 0 : outlay1.SelectMany(r => r.ActualOutlays).Sum(s => s.Amount))
                         + (!outlay2.Any() ? 0 : outlay2.SelectMany(r => r.ActualOutlays).Sum(s => s.Amount))
                         + (!outlay3.Any() ? 0 : outlay3.SelectMany(r => r.ActualOutlays).Sum(s => s.Amount))) / 10000,
                        2,
                        MidpointRounding.AwayFromZero),
                    Total22 = outlay == null ? 0 : outlay.Total1,
                    Total24 = outlay == null ? 0 : outlay.Total2,
                    Total25 = outlay == null ? 0 : outlay.Total3,
                    Note    = outlay?.Note,
                };

                list.Add(performance);
            }

            return list;
        }

        public string Export()
        {
            var codes = this._layerRepository.GetAll()
                .Where(r => r.Category == DictionaryCategory.Budget_Account)
                .OrderBy(r => r.LevelCode).Select(r => new {Code = r.LevelCode, Name = r.Name}).ToList();
            var list = this.GetBudgetPerformances();
            var newCodes = list.Select(r => r.Code).ToList();
            foreach (var item in list)
            {
                GetNewCode(item.Code);
            }


            void GetNewCode(string code)
            {
                if (!newCodes.Contains( code))
                {
                    newCodes.Add(code);
                }
                if (code.Length >1)
                {
                    var code2 = code.Substring(0,code.Length - 1);
                    GetNewCode(code2);
                }
            }

            newCodes.Sort();
            var result = new List<BudgetPerformanceListDto>
            {
                new BudgetPerformanceListDto()
                {
                    Code    = string.Empty,
                    Id      = Guid.NewGuid(),
                    Name    = string.Empty,
                    Total4  = list.Sum(r => r.Total4),
                    Total10 = list.Sum(r => r.Total10),
                    Total12 = list.Sum(r => r.Total12),
                    Total13 = list.Sum(r => r.Total13),
                    Total14 = list.Sum(r => r.Total14),
                    Total16 = list.Sum(r => r.Total16),
                    Total17 = list.Sum(r => r.Total17),
                    Total18 = list.Sum(r => r.Total18),
                    Total19 = list.Sum(r => r.Total19),
                    Total2  = list.Sum(r => r.Total2),
                    Total22 = list.Sum(r => r.Total22),
                    Total24 = list.Sum(r => r.Total24),
                    Total25 = list.Sum(r => r.Total25),
                    Total3  = list.Sum(r => r.Total3),
                    Total5  = list.Sum(r => r.Total5),
                    Total8  = list.Sum(r => r.Total8),
                    Total9  = list.Sum(r => r.Total9)
                }
            };
            foreach (var code in newCodes)
            {
                var item = list.FirstOrDefault(r => r.Code == code);
                if (item == null)
                {
                    var codeName = codes.FirstOrDefault(r => r.Code == code);
                    if (codeName == null) continue;

                    item = new BudgetPerformanceListDto()
                    {
                        Code   = codeName.Code,
                        Id     = Guid.NewGuid(),
                        Name   = codeName.Name,
                        Total4 = -1234, // 给个特定值,填充行数据时替换成空
                    };
                }

                result.Add(item);
            }

            return DownloadFileService.Load("budgetOutlay.xls", "预算执行情况.xls", new string[] { })
                .ExcuteXls(result, this.ExportToXls);
        }

        private WorkbookDesigner ExportToXls(WorkbookDesigner designer, List<BudgetPerformanceListDto> list)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            designer.Workbook.Worksheets[0].Cells[0, 0].Value = $"{currentYearItem.Value}年度预算编制及预算执行情况表";

            for (var i = 0; i < list.Count; i++)
            {
                var rowNum = i + 6;
                var cell0  = designer.Workbook.Worksheets[0].Cells[rowNum, 0];
                var cell1  = designer.Workbook.Worksheets[0].Cells[rowNum, 1];
                var cell2  = designer.Workbook.Worksheets[0].Cells[rowNum, 2];
                var cell3  = designer.Workbook.Worksheets[0].Cells[rowNum, 3];
                var cell4  = designer.Workbook.Worksheets[0].Cells[rowNum, 4];
                var cell5  = designer.Workbook.Worksheets[0].Cells[rowNum, 5];
                var cell6  = designer.Workbook.Worksheets[0].Cells[rowNum, 6];
                var cell7  = designer.Workbook.Worksheets[0].Cells[rowNum, 7];
                var cell8  = designer.Workbook.Worksheets[0].Cells[rowNum, 8];
                var cell9  = designer.Workbook.Worksheets[0].Cells[rowNum, 9];
                var cell10 = designer.Workbook.Worksheets[0].Cells[rowNum, 10];
                var cell11 = designer.Workbook.Worksheets[0].Cells[rowNum, 11];
                var cell12 = designer.Workbook.Worksheets[0].Cells[rowNum, 12];
                var cell13 = designer.Workbook.Worksheets[0].Cells[rowNum, 13];
                var cell14 = designer.Workbook.Worksheets[0].Cells[rowNum, 14];
                var cell15 = designer.Workbook.Worksheets[0].Cells[rowNum, 15];
                var cell16 = designer.Workbook.Worksheets[0].Cells[rowNum, 16];
                var cell17 = designer.Workbook.Worksheets[0].Cells[rowNum, 17];
                var cell18 = designer.Workbook.Worksheets[0].Cells[rowNum, 18];
                var cell19 = designer.Workbook.Worksheets[0].Cells[rowNum, 19];
                var cell20 = designer.Workbook.Worksheets[0].Cells[rowNum, 20];
                var cell21 = designer.Workbook.Worksheets[0].Cells[rowNum, 21];
                var cell22 = designer.Workbook.Worksheets[0].Cells[rowNum, 22];
                var cell23 = designer.Workbook.Worksheets[0].Cells[rowNum, 23];
                var cell24 = designer.Workbook.Worksheets[0].Cells[rowNum, 24];
                var cell25 = designer.Workbook.Worksheets[0].Cells[rowNum, 25];
                var cell26 = designer.Workbook.Worksheets[0].Cells[rowNum, 26];
                var cell27 = designer.Workbook.Worksheets[0].Cells[rowNum, 27];

                if (rowNum != 6)
                {
                    cell0.Value = list[i].Code;
                    cell1.Value = list[i].Name;
                }


                void SetStyle(Style s)
                {
                    cell0.SetStyle(s);
                    cell1.SetStyle(s);
                    cell2.SetStyle(s);
                    cell3.SetStyle(s);
                    cell4.SetStyle(s);
                    cell5.SetStyle(s);
                    cell6.SetStyle(s);
                    cell7.SetStyle(s);
                    cell8.SetStyle(s);
                    cell9.SetStyle(s);
                    cell10.SetStyle(s);
                    cell11.SetStyle(s);
                    cell12.SetStyle(s);
                    cell13.SetStyle(s);
                    cell14.SetStyle(s);
                    cell15.SetStyle(s);
                    cell16.SetStyle(s);
                    cell17.SetStyle(s);
                    cell18.SetStyle(s);
                    cell19.SetStyle(s);
                    cell20.SetStyle(s);
                    cell21.SetStyle(s);
                    cell22.SetStyle(s);
                    cell23.SetStyle(s);
                    cell24.SetStyle(s);
                    cell25.SetStyle(s);
                    cell26.SetStyle(s);
                    cell27.SetStyle(s);
                }

                var st = new Style
                {
                    Font                = {Size = 8, Name = "宋体"},
                    Pattern             = BackgroundType.Solid,
                    HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center
                };
                st.Borders[BorderType.LeftBorder].LineStyle   = CellBorderType.Thin; //应用边界线 左边界线
                st.Borders[BorderType.RightBorder].LineStyle  = CellBorderType.Thin; //应用边界线 右边界线
                st.Borders[BorderType.TopBorder].LineStyle    = CellBorderType.Thin; //应用边界线 上边界线
                st.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线
                if (list[i].Code.Length == 1)
                {
                    st.ForegroundColor = Color.Cyan;
                    st.Pattern = BackgroundType.Solid;
                }
                else if (list[i].Code.Length == 2)
                {
                    st.ForegroundColor = Color.Chartreuse;
                    st.Pattern = BackgroundType.Solid;
                }

                SetStyle(st);
                if (list[i].Total4 <= -1234) continue;

                cell2.Value  = list[i].Total1;
                cell3.Value  = list[i].Total2;
                cell4.Value  = list[i].Total3;
                cell5.Value  = list[i].Total4;
                cell6.Value  = list[i].Total5;
                cell7.Value  = list[i].Total6;
                cell8.Value  = list[i].Total7;
                cell9.Value  = list[i].Total8;
                cell10.Value = list[i].Total9;
                cell11.Value = list[i].Total10;
                cell12.Value = list[i].Total11;
                cell13.Value = list[i].Total12;
                cell14.Value = list[i].Total13;
                cell15.Value = list[i].Total14;
                cell16.Value = list[i].Total15;
                cell17.Value = list[i].Total16;
                cell18.Value = list[i].Total17;
                cell19.Value = list[i].Total18;
                cell20.Value = list[i].Total19;
                cell21.Value = list[i].Total20;
                cell22.Value = list[i].Total21;
                cell23.Value = list[i].Total22;
                cell24.Value = list[i].Total23;
                cell25.Value = list[i].Total24;
                cell26.Value = list[i].Total25;
                cell27.Value = list[i].Note;
            }

            return designer;
        }

        public void SaveOutlaySummary(OutlaySummaryEditDto item)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var outlay =
                this._outlayRepository.FirstOrDefault(r =>
                    r.Code == item.Code && r.Year.ToString() == currentYearItem.Value);
            if (outlay == null)
            {
                outlay = new Outlay()
                {
                    Code   = item.Code,
                    Year   = currentYearItem.Value.ToInt(),
                    Total1 = item.Total1,
                    Total2 = item.Total2,
                    Total3 = item.Total3,
                    Note   = item.Note,
                };
                this._outlayRepository.Insert(outlay);
            }
            else
            {
                outlay.Total1 = item.Total1;
                outlay.Total2 = item.Total2;
                outlay.Total3 = item.Total3;
                outlay.Note   = item.Note;
                this._outlayRepository.Update(outlay);
            }
        }

        public OutlaySummaryEditDto GetOutlaySummary(string code)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var account =
                this._layerRepository.FirstOrDefault(
                    r => r.Category == DictionaryCategory.Budget_Account && r.LevelCode == code);
            if (account == null)
            {
                throw new UserFriendlyException($"未知科目编码[{code}]");
            }

            var outlay =
                this._outlayRepository.FirstOrDefault(r => r.Code == code && r.Year.ToString() == currentYearItem.Value);
            if (outlay == null)
            {
                return new OutlaySummaryEditDto
                {
                    Code = code,
                    Year = currentYearItem.Value.ToInt(),
                    Name = account.Name
                };
            }

            var result = outlay.MapTo<OutlaySummaryEditDto>();
            result.Name = account.Name;
            return result;
        }

        public Guid LoadBudgetReceiptFile1(string path, object param)
        {
            return this.LoadBudgetReceiptFile(path, BungetType.Year);
        }

        public Guid LoadBudgetReceiptFile2(string path, object param)
        {
            return this.LoadBudgetReceiptFile(path, BungetType.Adjust);
        }

        public Guid LoadBudgetReceiptFile3(string path, object param)
        {
            return this.LoadBudgetReceiptFile(path, BungetType.Increase);
        }

        /// <summary>
        /// 获取导入sheet的名称
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// </returns>
        public List<KeyValue<string, string>> GetSheetNames(int type)
        {
            var currentYear = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }

            return this._budgetOutlayRepository.Get(r => r.Year.ToString() == currentYear.Value && (int) r.Type == type)
                .Select(r => new KeyValue<string, string> {Key = r.SheetName, Value = r.SheetName}).Distinct().ToList();
        }

        public void Update(OutlayEditDto input)
        {
            foreach (var value in input.OutlayIds)
            {
                var item = this._budgetOutlayRepository.FirstOrDefault(r => r.Id == value);
                if (item == null)
                {
                    throw new UserFriendlyException($"该预算支出项目不存在:{value}");
                }

                item.Code            = input.Code;
                item.BudgetReceiptId = input.Id;
                item.HasRelated      = true;
                this._budgetOutlayRepository.Update(item);
            }
        }

        /// <summary>
        /// 获取年度预算简表
        /// </summary>
        /// <returns></returns>
        public List<YearBudgetSummaryDto> GetSummary()
        {
            var currentYear = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }

            var year  = currentYear.Value.ToInt();
            var query = this._budgetReceiptRepository.GetAllList(r => r.Year == year).OrderBy(r => r.Code).ToList();

            var list = new List<YearBudgetSummaryDto>();
            foreach (var receipt in query)
            {
                var name =
                    this._layerRepository.FirstOrDefault(
                        r => r.Category == DictionaryCategory.Budget_Account && r.LevelCode == receipt.Code);
                if (name == null)
                {
                    throw new UserFriendlyException("未设置预算年度");
                }

                var dto = new YearBudgetSummaryDto
                {
                    Name    = name.Name,
                    Code    = name.LevelCode,
                    Column1 = receipt.Column1,
                    Column2 = receipt.Column21 + receipt.Column22,
                    Column3 = receipt.Column31 + receipt.Column32 + receipt.Column33 + receipt.Column34 +
                              receipt.Column35 + receipt.Column36 + receipt.Column37,
                    Column4 = receipt.Column41 + receipt.Column42 + receipt.Column43 + receipt.Column44 +
                              receipt.Column45 + receipt.Column46 + receipt.Column47,
                    Column8 = receipt.Column5,
                    Column5 = receipt.BudgetOutlaies.Sum(r => r.Column1),
                    Column6 = receipt.BudgetOutlaies.Sum(r => r.Column2),
                    Column7 = receipt.BudgetOutlaies.Sum(r => r.Column3),
                    Total2  = receipt.Column1 + receipt.Column21 + receipt.Column22,
                    Total1 = receipt.Column1    + receipt.Column21 + receipt.Column22
                             + receipt.Column31 + receipt.Column32 + receipt.Column33 + receipt.Column34 +
                             receipt.Column35   + receipt.Column36 + receipt.Column37
                             + receipt.Column41 + receipt.Column42 + receipt.Column43 + receipt.Column44 +
                             receipt.Column45   + receipt.Column46 + receipt.Column47 + receipt.Column5,
                    Total4 = receipt.BudgetOutlaies.Sum(r => r.Column2             + r.Column1),
                    Total3 = receipt.BudgetOutlaies.Sum(r => r.Column2 + r.Column1 + r.Column3),
                    Total5 = (receipt.Column1    + receipt.Column21 + receipt.Column22
                              + receipt.Column31 + receipt.Column32 + receipt.Column33 + receipt.Column34 +
                              receipt.Column35   + receipt.Column36 + receipt.Column37
                              + receipt.Column41 + receipt.Column42 + receipt.Column43 + receipt.Column44 +
                              receipt.Column45   + receipt.Column46 + receipt.Column47 + receipt.Column5)
                             - receipt.BudgetOutlaies.Sum(r => r.Column2 + r.Column1 + r.Column3)
                };
                list.Add(dto);
            }

            list = list.GroupBy(r => new {Code = r.Code, Name = r.Name}).Select(r =>
                    new YearBudgetSummaryDto()
                    {
                        Name    = r.Key.Name,
                        Code    = r.Key.Code,
                        Column1 = r.Sum(m => m.Column1),
                        Column2 = r.Sum(m => m.Column2),
                        Column3 = r.Sum(m => m.Column3),
                        Column4 = r.Sum(m => m.Column4),
                        Column5 = r.Sum(m => m.Column5),
                        Column6 = r.Sum(m => m.Column6),
                        Column7 = r.Sum(m => m.Column7),
                        Column8 = r.Sum(m => m.Column8),
                        Total1  = r.Sum(m => m.Total1),
                        Total2  = r.Sum(m => m.Total2),
                        Total3  = r.Sum(m => m.Total3),
                        Total4  = r.Sum(m => m.Total4),
                        Total5  = r.Sum(m => m.Total5)
                    })
                .ToList();

            return list;
        }

        private Guid LoadBudgetReceiptFile(string path, BungetType type)
        {
            var fs      = new FileStream(path, FileMode.Open, FileAccess.Read);
            var modelId = Guid.NewGuid();
            if (path.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0) // 2007版本
            {
                this._workbook = new XSSFWorkbook(fs);
            }
            else if (path.IndexOf(".xls", StringComparison.OrdinalIgnoreCase) > 0) // 2003版本
            {
                this._workbook = new HSSFWorkbook(fs);
            }
            else
            {
                throw new UserFriendlyException("上传文件格式不正确");
            }

            var currentYear = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }

            var list = new List<BudgetOutlay>();
            for (var j = 0; j < this._workbook.NumberOfSheets; j++)
            {
                var sheet = this._workbook.GetSheetAt(j);
                //最后一列的标号
                var rowCount = sheet.LastRowNum + 1;


                for (var i = 3; i < rowCount; i++)
                {
                    var row = sheet.GetRow(i);
                    if (!string.IsNullOrEmpty(row.GetCell(1).ToStr()))
                    {
                        var item = new BudgetOutlay()
                        {
                            Type      = type,
                            SheetName = sheet.SheetName,
                            Name      = row.GetCell(0).ToStr(),
                            Unit      = row.GetCell(1).ToStr(),
                            Amount    = decimal.Parse(row.GetCell(2).ToStr()),
                            Price     = decimal.Parse(row.GetCell(3).ToStr()),
                            Column1   = row.GetCell(6).ToStr().ToDecimal(),
                            Column2   = row.GetCell(7).ToStr().ToDecimal(),
                            Column3   = row.GetCell(8).ToStr().ToDecimal(),
                            FileId    = modelId,
                            Year      = currentYear.Value.ToInt()
                        };
                        list.Add(item);
                    }
                }
            }

            this._budgetOutlayRepository.Delete(r => r.Year.ToString() == currentYear.Value && r.Type == type);
            this._budgetOutlayRepository.InsertRange(list);
            return modelId;
        }
    }
}
