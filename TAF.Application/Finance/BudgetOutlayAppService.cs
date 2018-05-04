// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetOutlayAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   支出预算服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using SCBF.BaseInfo;
    using SCBF.Finance.Dto;
    using TAF.Utility;

    /// <summary>
    /// 支出预算服务
    /// </summary>
    [AbpAuthorize]
    public class BudgetOutlayAppService : TAFAppServiceBase, IBudgetOutlayAppService
    {
        private readonly IBudgetOutlayRepository  budgetOutlayRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IBudgetReceiptRepository budgetReceiptRepository;
        private readonly IActualOutlayRepository  actualOutlayRepository;
        private readonly ILayerRepository         layerRepository;
        private readonly IOutlayRepository        outlayRepository;
        private          IWorkbook                workbook = null;

        public BudgetOutlayAppService(
            IBudgetOutlayRepository  budgetOutlayRepository,
            ISysDictionaryRepository sysDictionaryRepository,
            IBudgetReceiptRepository budgetReceiptRepository,
            ILayerRepository         layerRepository,
            IActualOutlayRepository  actualOutlayRepository,
            IOutlayRepository        outlayRepository)
        {
            this.budgetOutlayRepository  = budgetOutlayRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.budgetReceiptRepository = budgetReceiptRepository;
            this.actualOutlayRepository  = actualOutlayRepository;
            this.layerRepository         = layerRepository;
            this.outlayRepository        = outlayRepository;
        }

        public List<BudgetOutlayListDto> Get(string sheetName, int type)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var result =
                this.budgetOutlayRepository.GetAllList(r =>
                        r.Year == year && r.SheetName == sheetName && !r.HasRelated && (int) r.Type == type)
                    .OrderBy(r => r.Code).ToList().MapTo<List<BudgetOutlayListDto>>();
            return result;
        }

        public List<OutlayListDto> GetAll()
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var result =
                this.budgetOutlayRepository.GetAllList(r => r.Year == year && r.HasRelated).OrderBy(r => r.Code)
                    .ToList().MapTo<List<OutlayListDto>>();
            return result;
        }

        public List<BudgetOutlaySimpleListDto> GetSimple()
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString()
                                                                                   && r.Category ==
                                                                                   DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var result =
                this.budgetOutlayRepository.GetAllList(r => r.Year == year
                                                            && r.HasRelated).OrderBy(r => r.Code).ToList()
                    .MapTo<List<BudgetOutlaySimpleListDto>>();
            return result;
        }

        public List<BudgetPerformanceListDto> GetBudgetPerformances()
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var accounts = this.layerRepository.GetAllList(r => r.Category == DictionaryCategory.Budget_Account);


            var result = this.budgetReceiptRepository.GetAllList(r => r.Year.ToString() == currentYearItem.Value)
                .OrderBy(r => r.Code);
            var result0 = this.budgetOutlayRepository
                .GetAllList(r => r.Year.ToString() == currentYearItem.Value && r.HasRelated).OrderBy(r => r.Code);
            var codeList = result.Select(r => r.Code).Distinct().ToList();
            var result1 = this.actualOutlayRepository.GetAllList(r => r.Year.ToString() == currentYearItem.Value)
                .OrderBy(r => r.VoucherNo);
            var list = new List<BudgetPerformanceListDto>();
            foreach (var code in codeList)
            {
                var receipt = result.FirstOrDefault(r => r.Code  == code && r.Type == BungetType.Year);
                var outlay1 = result0.FirstOrDefault(r => r.Code == code && r.Type == BungetType.Year);
                var outlay2 = result0.FirstOrDefault(r => r.Code == code && r.Type == BungetType.Adjust);
                var outlay3 = result0.FirstOrDefault(r => r.Code == code && r.Type == BungetType.Increase);
                var outlay =
                    this.outlayRepository.FirstOrDefault(r =>
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
                    Total8  = outlay1 != null ? outlay1.Column1 : 0,
                    Total9  = outlay1 != null ? outlay1.Column2 : 0,
                    Total10 = outlay1 != null ? outlay1.Column3 : 0,
                    Total12 = outlay2 != null ? outlay2.Column1 : 0,
                    Total13 = outlay2 != null ? outlay2.Column2 : 0,
                    Total14 = outlay2 != null ? outlay2.Column3 : 0,
                    Total16 = outlay3 != null ? outlay3.Column1 : 0,
                    Total17 = outlay3 != null ? outlay3.Column2 : 0,
                    Total18 = outlay3 != null ? outlay3.Column3 : 0,
                    Total19 = decimal.Round(
                        ((outlay1   == null ? 0 : outlay1.ActualOutlays.Sum(r => r.Amount))
                         + (outlay2 == null ? 0 : outlay2.ActualOutlays.Sum(r => r.Amount))
                         + (outlay3 == null ? 0 : outlay3.ActualOutlays.Sum(r => r.Amount))) / 10000,
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

        public void SaveOutlaySummary(OutlaySummaryEditDto item)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var outlay =
                this.outlayRepository.FirstOrDefault(r =>
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
                this.outlayRepository.Insert(outlay);
            }
            else
            {
                outlay.Total1 = item.Total1;
                outlay.Total2 = item.Total2;
                outlay.Total3 = item.Total3;
                outlay.Note   = item.Note;
                this.outlayRepository.Update(outlay);
            }
        }

        public OutlaySummaryEditDto GetOutlaySummary(string code)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var account =
                this.layerRepository.FirstOrDefault(
                    r => r.Category == DictionaryCategory.Budget_Account && r.LevelCode == code);
            if (account == null)
            {
                throw new UserFriendlyException($"未知科目编码[{code}]");
            }

            var outlay =
                this.outlayRepository.FirstOrDefault(r => r.Code == code && r.Year.ToString() == currentYearItem.Value);
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
            var currentYear = this.sysDictionaryRepository.FirstOrDefault(r =>
                r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }

            return this.budgetOutlayRepository.Get(r => r.Year.ToString() == currentYear.Value && (int) r.Type == type)
                .Select(r => new KeyValue<string, string> {Key = r.SheetName, Value = r.SheetName}).Distinct().ToList();
        }

        public void Update(OutlayEditDto input)
        {
            foreach (var value in input.OutlayIds)
            {
                var item = this.budgetOutlayRepository.FirstOrDefault(r => r.Id == value);
                if (item == null)
                {
                    throw new UserFriendlyException($"该预算支出项目不存在:{value}");
                }

                item.Code            = input.Code;
                item.BudgetReceiptId = input.Id;
                item.HasRelated      = true;
                this.budgetOutlayRepository.Update(item);
            }
        }

        /// <summary>
        /// 获取年度预算简表
        /// </summary>
        /// <returns></returns>
        public List<YearBudgetSummaryDto> GetSummary()
        {
            var currentYear = this.sysDictionaryRepository.FirstOrDefault(r =>
                r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }

            var year  = currentYear.Value.ToInt();
            var query = this.budgetReceiptRepository.GetAllList(r => r.Year == year).OrderBy(r => r.Code).ToList();

            var list = new List<YearBudgetSummaryDto>();
            foreach (var receipt in query)
            {
                var name =
                    this.layerRepository.FirstOrDefault(
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
            }

            return list;
        }

        private Guid LoadBudgetReceiptFile(string path, BungetType type)
        {
            var fs      = new FileStream(path, FileMode.Open, FileAccess.Read);
            var modelId = Guid.NewGuid();
            if (path.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0) // 2007版本
            {
                this.workbook = new XSSFWorkbook(fs);
            }
            else if (path.IndexOf(".xls", StringComparison.OrdinalIgnoreCase) > 0) // 2003版本
            {
                this.workbook = new HSSFWorkbook(fs);
            }
            else
            {
                throw new UserFriendlyException("上传文件格式不正确");
            }

            var currentYear = this.sysDictionaryRepository.FirstOrDefault(r =>
                r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }

            var list = new List<BudgetOutlay>();
            for (var j = 0; j < this.workbook.NumberOfSheets; j++)
            {
                var sheet = this.workbook.GetSheetAt(j);
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

            this.budgetOutlayRepository.Delete(r => r.Year.ToString() == currentYear.Value && r.Type == type);
            this.budgetOutlayRepository.InsertRange(list);
            return modelId;
        }
    }
}
