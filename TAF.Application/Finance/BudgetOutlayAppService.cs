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
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using SCBF.BaseInfo;
    using SCBF.Finance.Dto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Dynamic;
    using TAF.Utility;

    /// <summary>
    /// 支出预算服务
    /// </summary>
    [AbpAuthorize]
    public class BudgetOutlayAppService : TAFAppServiceBase, IBudgetOutlayAppService
    {
        private readonly IBudgetOutlayRepository budgetOutlayRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IBudgetReceiptRepository budgetReceiptRepository;
        private readonly ILayerRepository layerRepository;
        private IWorkbook workbook = null;

        public BudgetOutlayAppService(
            IBudgetOutlayRepository budgetOutlayRepository,
            ISysDictionaryRepository sysDictionaryRepository,
            IBudgetReceiptRepository budgetReceiptRepository,
            ILayerRepository layerRepository)
        {
            this.budgetOutlayRepository = budgetOutlayRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.budgetReceiptRepository = budgetReceiptRepository;
            this.layerRepository = layerRepository;
        }

        public List<BudgetOutlayListDto> Get(string sheetName, int type)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);
            var result =
                this.budgetOutlayRepository.GetAllList(r => r.Year == year && r.SheetName == sheetName && !r.HasRelated && (int)r.Type == type)
                .OrderBy(r => r.Code).ToList().MapTo<List<BudgetOutlayListDto>>();
            return result;
        }

        public List<OutlayListDto> GetAll()
        {

            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);
            var result =
                this.budgetOutlayRepository.GetAllList(r => r.Year == year && r.HasRelated).OrderBy(r => r.Code).ToList().MapTo<List<OutlayListDto>>();
            return result;
        }

        public List<BudgetOutlaySimpleListDto> GetSimple()
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString()
            && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);
            var result =
                this.budgetOutlayRepository.GetAllList(r => r.Year == year
                && r.HasRelated).OrderBy(r => r.Code).ToList().MapTo<List<BudgetOutlaySimpleListDto>>();
            return result;
        }

        public Guid LoadBudgetReceiptFile1(string path)
        {
            return this.LoadBudgetReceiptFile(path, BungetType.Year);
        }

        public Guid LoadBudgetReceiptFile2(string path)
        {
            return this.LoadBudgetReceiptFile(path, BungetType.Adjust);
        }

        public Guid LoadBudgetReceiptFile3(string path)
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
            var currentYear = this.sysDictionaryRepository.FirstOrDefault(r => r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }
            return this.budgetOutlayRepository.Get(r => r.Year.ToString() == currentYear.Value && (int)r.Type == type)
                .Select(r => new KeyValue<string, string> { Key = r.SheetName, Value = r.SheetName }).Distinct().ToList();
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
                item.Code = input.Code;
                item.BudgetReceiptId = input.Id;
                item.HasRelated = true;
                this.budgetOutlayRepository.Update(item);
            }
        }

        /// <summary>
        /// 获取年度预算简表
        /// </summary>
        /// <returns></returns>
        public List<YearBudgetSummaryDto> GetSummary()
        {
            var currentYear = this.sysDictionaryRepository.FirstOrDefault(r => r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }
            var year = currentYear.Value.ToInt();
            var query = this.budgetReceiptRepository.GetAllList(r => r.Year == year && r.Type == BungetType.Year).OrderBy(r => r.Code).ToList();

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
                    Name = name.Name,
                    Column1 = receipt.Column1,
                    Column2 = receipt.Column21 + receipt.Column22,
                    Column3 = receipt.Column31 + receipt.Column32 + receipt.Column33 + receipt.Column34 + receipt.Column35 + receipt.Column36 + receipt.Column37,
                    Column4 = receipt.Column41 + receipt.Column42 + receipt.Column43 + receipt.Column44 + receipt.Column45 + receipt.Column46 + receipt.Column47,
                    Column5 = receipt.BudgetOutlaies.Sum(r => r.Column1),
                    Column6 = receipt.BudgetOutlaies.Sum(r => r.Column2),
                    Column7 = receipt.BudgetOutlaies.Sum(r => r.Column3),
                    Total2 = receipt.Column1 + receipt.Column21 + receipt.Column22,
                    Total1 = receipt.Column1 + receipt.Column21 + receipt.Column22
                    + receipt.Column31 + receipt.Column32 + receipt.Column33 + receipt.Column34 + receipt.Column35 + receipt.Column36 + receipt.Column37
                    + receipt.Column41 + receipt.Column42 + receipt.Column43 + receipt.Column44 + receipt.Column45 + receipt.Column46 + receipt.Column47,
                    Total4 = receipt.BudgetOutlaies.Sum(r => r.Column2 + r.Column1),
                    Total3 = receipt.BudgetOutlaies.Sum(r => r.Column2 + r.Column1 + r.Column3),
                    Total5 = (receipt.Column1 + receipt.Column21 + receipt.Column22
                    + receipt.Column31 + receipt.Column32 + receipt.Column33 + receipt.Column34 + receipt.Column35 + receipt.Column36 + receipt.Column37
                    + receipt.Column41 + receipt.Column42 + receipt.Column43 + receipt.Column44 + receipt.Column45 + receipt.Column46 + receipt.Column47)
                    - receipt.BudgetOutlaies.Sum(r => r.Column2 + r.Column1 + r.Column3)
                };
                list.Add(dto);
            }
            return list;
        }

        private Guid LoadBudgetReceiptFile(string path, BungetType type)
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var modelId = Guid.NewGuid();
            if (path.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0)// 2007版本
            {
                this.workbook = new XSSFWorkbook(fs);
            }
            else if (path.IndexOf(".xls", StringComparison.OrdinalIgnoreCase) > 0)// 2003版本
            {
                this.workbook = new HSSFWorkbook(fs);
            }
            else
            {
                throw new UserFriendlyException("上传文件格式不正确");
            }

            var currentYear = this.sysDictionaryRepository.FirstOrDefault(r => r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
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
                            Type = type,
                            SheetName = sheet.SheetName,
                            Name = row.GetCell(0).ToStr(),
                            Unit = row.GetCell(1).ToStr(),
                            Amount = decimal.Parse(row.GetCell(2).ToStr()),
                            Price = decimal.Parse(row.GetCell(3).ToStr()),
                            Column1 = row.GetCell(6).ToStr().ToDecimal(),
                            Column2 = row.GetCell(7).ToStr().ToDecimal(),
                            Column3 = row.GetCell(8).ToStr().ToDecimal(),
                            FileId = modelId,
                            Year = currentYear.Value.ToInt()
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



