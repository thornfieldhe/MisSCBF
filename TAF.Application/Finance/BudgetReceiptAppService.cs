// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetReceiptAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   年度预算收入服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;
    using BaseInfo;
    using Dto;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using TAF.Utility;

    /// <summary>
    /// 年度预算收入服务
    /// </summary>
    [AbpAuthorize]
    public class BudgetReceiptAppService : TAFAppServiceBase, IBudgetReceiptAppService
    {
        private readonly IBudgetReceiptRepository _budgetReceiptRepository;
        private readonly IBudgetOutlayRepository  _budgetOutlayRepository;
        private readonly ILayerRepository         _layerRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;
        private readonly IReceiptRepository       _receiptRepository;
        private          IWorkbook                _workbook;

        public BudgetReceiptAppService(
            IBudgetReceiptRepository budgetReceiptRepository,
            ISysDictionaryRepository sysDictionaryRepository,
            IBudgetOutlayRepository  budgetOutlayRepository,
            ILayerRepository         layerRepository,
            IReceiptRepository       receiptRepository)
        {
            this._budgetReceiptRepository = budgetReceiptRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
            this._budgetOutlayRepository = budgetOutlayRepository;
            this._layerRepository         = layerRepository;
            this._receiptRepository       = receiptRepository;
        }

        public List<BudgetReceiptListDto> Get(int type,bool containsUse=false)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var result =
                this._budgetReceiptRepository.GetAllList(r => r.Year == year && (int) r.Type == type)
                    .OrderBy(r => r.Code).MapTo<List<BudgetReceiptListDto>>();
            var accounts =
                this._layerRepository.GetAllList(r => r.Category == DictionaryCategory.Budget_Account)
                    .Select(r => new KeyValue<string, string> {Key = r.LevelCode, Value = r.Name})
                    .ToList();
            result.ForEach(item =>
            {
                var account = accounts.FirstOrDefault(r => r.Key == item.Code);
                if (containsUse)
                {
                    var usedAmount = this._budgetOutlayRepository
                        .GetAllList(r => r.BudgetReceiptId == item.Id)
                        .Sum(r => r.Column1 + r.Column2 + r.Column3); // comment: 已使用额度
                    item.Total = item.Total - usedAmount;
                }

                if (account == null)
                {
                    throw new UserFriendlyException($"未知科目编码[{item.Code}]");
                }

                item.Name = account.Value;
            });


            return result;
        }


        public List<KeyValue<Guid, string, string, decimal>> GetSimple(int type)
        {
            return this.Get(type,true).OrderBy(r => r.Code).ToList().Select(r =>
                new KeyValue<Guid, string, string, decimal>()
                {
                    Key   = r.Id,
                    Value = r.Code,
                    Item3 = r.Name,
                    Item4 = r.Total
                }).ToList();
        }

        public List<ReceiptListDto> GetReceipts()
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var accounts = this._layerRepository.GetAllList(r => r.Category == DictionaryCategory.Budget_Account);


            var result = this._budgetReceiptRepository.GetAllList(r => r.Year.ToString() == currentYearItem.Value)
                .OrderBy(r => r.Code);
            var result1 = result.Where(r => r.Type == BungetType.Year).ToList();
            var result2 = result.Where(r => r.Type == BungetType.Adjust).ToList();
            var result3 = result.Where(r => r.Type == BungetType.Increase).ToList();

            var result4 = this._receiptRepository.GetAllList(r => r.Year.ToString() == currentYearItem.Value);
            var list    = new List<ReceiptListDto>();
            foreach (var item in result1)
            {
                var item1 = result2.FirstOrDefault(r => r.Code == item.Code);
                var item2 = result3.FirstOrDefault(r => r.Code == item.Code);
                var item3 = result4.FirstOrDefault(r => r.Code == item.Code);
                var receipt = new ReceiptListDto
                {
                    Id     = item.Id,
                    Code   = item.Code,
                    Name   = accounts.FirstOrDefault(r => r.LevelCode == item.Code)?.Name,
                    Total5 = item.Column1,
                    Total6 = item.Column21 + item.Column22,
                    Total7 = item.Column31 + item.Column32 + item.Column33 + item.Column34 + item.Column35 +
                             item.Column36 + item.Column37,
                    Total8 = item.Column41 + item.Column42 + item.Column43 + item.Column44 + item.Column45 +
                             item.Column46 + item.Column47,
                    Total9  = item.Column5,
                    Total12 = item1 == null ? 0 : item1.Column1,
                    Total13 = item1 == null ? 0 : item1.Column21 + item1.Column22,
                    Total14 = item1 == null
                        ? 0
                        : item1.Column31 + item1.Column32 + item1.Column33 + item1.Column34 + item1.Column35 +
                          item1.Column36 + item1.Column37,
                    Total15 = item1 == null
                        ? 0
                        : item1.Column41 + item1.Column42 + item1.Column43 + item1.Column44 + item1.Column45 +
                          item1.Column46 + item1.Column47,
                    Total16 = item1 == null ? 0 : item1.Column5,
                    Total18 = item2 == null ? 0 : item2.Column1,
                    Total19 = item2 == null ? 0 : item2.Column21 + item2.Column22,
                    Total26 = item3 == null ? 0 : item3.Amount
                };
                list.Add(receipt);
            }

            return list;
        }

        public ReceiptEditDto GetReceipt(string code)
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

            var receipt =
                this._receiptRepository.FirstOrDefault(
                    r => r.Code == code && r.Year.ToString() == currentYearItem.Value);
            if (receipt == null)
            {
                return new ReceiptEditDto
                {
                    Code   = code,
                    Name   = account.Name,
                    Amount = 0
                };
            }

            var result = receipt.MapTo<ReceiptEditDto>();
            result.Name = account.Name;
            return result;
        }

        public void SaveReceuotAmount(KeyValue<string, decimal> item)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var receipt =
                this._receiptRepository.FirstOrDefault(r =>
                    r.Code == item.Key && r.Year.ToString() == currentYearItem.Value);
            if (receipt == null)
            {
                receipt = new Receipt
                {
                    Code   = item.Key,
                    Year   = currentYearItem.Value.ToInt(),
                    Amount = item.Value
                };
                this._receiptRepository.Insert(receipt);
            }
            else
            {
                receipt.Amount = item.Value;
                this._receiptRepository.Update(receipt);
            }
        }

        #region 上传预算表

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

            var sheet = this._workbook.GetSheetAt(0);
            //最后一列的标号
            int rowCount = sheet.LastRowNum + 1;
            var list     = new List<BudgetReceipt>();
            var currentYear = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }

            for (var i = 2; i < rowCount; i++)
            {
                var row = sheet.GetRow(i);
                if (!string.IsNullOrEmpty(row.GetCell(0).ToStr()))
                {
                    var item = new BudgetReceipt()
                    {
                        Type     = type,
                        Code     = row.GetCell(0).ToStr(),
                        Column1  = row.GetCell(4).ToStr().ToDecimal(),
                        Note1    = row.GetCell(5).ToStr(),
                        Column21 = row.GetCell(6).ToStr().ToDecimal(),
                        Note21   = row.GetCell(7).ToStr(),
                        Column22 = row.GetCell(8).ToStr().ToDecimal(),
                        Note22   = row.GetCell(9).ToStr(),
                        Column31 = row.GetCell(11).ToStr().ToDecimal(),
                        Note31   = row.GetCell(12).ToStr(),
                        Column32 = row.GetCell(13).ToStr().ToDecimal(),
                        Note32   = row.GetCell(14).ToStr(),
                        Column33 = row.GetCell(15).ToStr().ToDecimal(),
                        Note33   = row.GetCell(16).ToStr(),
                        Column34 = row.GetCell(17).ToStr().ToDecimal(),
                        Note34   = row.GetCell(18).ToStr(),
                        Column35 = row.GetCell(19).ToStr().ToDecimal(),
                        Note35   = row.GetCell(20).ToStr(),
                        Column36 = row.GetCell(21).ToStr().ToDecimal(),
                        Note36   = row.GetCell(22).ToStr(),
                        Column37 = row.GetCell(23).ToStr().ToDecimal(),
                        Note37   = row.GetCell(24).ToStr(),
                        Column41 = row.GetCell(26).ToStr().ToDecimal(),
                        Note41   = row.GetCell(27).ToStr(),
                        Column42 = row.GetCell(28).ToStr().ToDecimal(),
                        Note42   = row.GetCell(29).ToStr(),
                        Column43 = row.GetCell(30).ToStr().ToDecimal(),
                        Note43   = row.GetCell(31).ToStr(),
                        Column44 = row.GetCell(32).ToStr().ToDecimal(),
                        Note44   = row.GetCell(33).ToStr(),
                        Column45 = row.GetCell(34).ToStr().ToDecimal(),
                        Note45   = row.GetCell(35).ToStr(),
                        Column46 = row.GetCell(36).ToStr().ToDecimal(),
                        Note46   = row.GetCell(37).ToStr(),
                        Column47 = row.GetCell(38).ToStr().ToDecimal(),
                        Note47   = row.GetCell(39).ToStr(),
                        Column5  = row.GetCell(40).ToStr().ToDecimal(),
                        Note5    = row.GetCell(41).ToStr(),
                        FileId   = modelId,
                        Year     = currentYear.Value.ToInt()
                    };
                    list.Add(item);
                }
            }

            this._budgetReceiptRepository.Delete(r => r.Year.ToString() == currentYear.Value && r.Type == type);
            this._budgetReceiptRepository.InsertRange(list);
            return modelId;
        }

        #endregion
    }
}
