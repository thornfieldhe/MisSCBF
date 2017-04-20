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

    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;

    using SCBF.BaseInfo;
    using SCBF.Finance.Dto;

    using TAF.Utility;

    /// <summary>
    /// 年度预算收入服务
    /// </summary>
    [AbpAuthorize]
    public class BudgetReceiptAppService : TAFAppServiceBase, IBudgetReceiptAppService
    {
        private readonly IBudgetReceiptRepository budgetReceiptRepository;
        private readonly ILayerRepository layerRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private IWorkbook workbook;

        public BudgetReceiptAppService(IBudgetReceiptRepository budgetReceiptRepository
            , ISysDictionaryRepository sysDictionaryRepository
            , ILayerRepository layerRepository)
        {
            this.budgetReceiptRepository = budgetReceiptRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.layerRepository = layerRepository;
        }

        public List<BudgetReceiptListDto> Get(int type)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);
            var result =
                this.budgetReceiptRepository.GetAllList(r => r.Year == year && (int)r.Type == type).MapTo<List<BudgetReceiptListDto>>();
            var accounts =
                this.layerRepository.GetAllList(r => r.Category == DictionaryCategory.Budget_Account)
                    .Select(r => new KeyValue<string, string> { Key = r.LevelCode, Value = r.Name })
                    .ToList();
            result.ForEach(item =>
                               {
                                   var account = accounts.FirstOrDefault(r => r.Key == item.Code);
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
            return this.Get(type).Select(r => new KeyValue<Guid, string, string, decimal>() { Key = r.Id, Value = r.Code, Item3 = r.Name, Item4 = r.Total }).ToList();
        }

        #region 上传预算表

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
            var sheet = this.workbook.GetSheetAt(0);
            //最后一列的标号
            int rowCount = sheet.LastRowNum;
            var list = new List<BudgetReceipt>();
            var currentYear = this.sysDictionaryRepository.FirstOrDefault(r => r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }
            for (var i = 2; i < rowCount; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0) != null && !string.IsNullOrEmpty(row.GetCell(0).ToStr()))
                {
                    var item = new BudgetReceipt()
                    {
                        Type = type,
                        Code = row.GetCell(0).ToStr(),
                        Column1 = row.GetCell(4).ToStr().ToDecimal(),
                        Note1 = row.GetCell(5).ToStr(),
                        Column21 = row.GetCell(6).ToStr().ToDecimal(),
                        Note21 = row.GetCell(7).ToStr(),
                        Column22 = row.GetCell(8).ToStr().ToDecimal(),
                        Note22 = row.GetCell(9).ToStr(),
                        Column31 = row.GetCell(11).ToStr().ToDecimal(),
                        Note31 = row.GetCell(12).ToStr(),
                        Column32 = row.GetCell(13).ToStr().ToDecimal(),
                        Note32 = row.GetCell(14).ToStr(),
                        Column33 = row.GetCell(15).ToStr().ToDecimal(),
                        Note33 = row.GetCell(16).ToStr(),
                        Column34 = row.GetCell(17).ToStr().ToDecimal(),
                        Note34 = row.GetCell(18).ToStr(),
                        Column35 = row.GetCell(19).ToStr().ToDecimal(),
                        Note35 = row.GetCell(20).ToStr(),
                        Column36 = row.GetCell(21).ToStr().ToDecimal(),
                        Note36 = row.GetCell(22).ToStr(),
                        Column37 = row.GetCell(23).ToStr().ToDecimal(),
                        Note37 = row.GetCell(24).ToStr(),
                        Column41 = row.GetCell(26).ToStr().ToDecimal(),
                        Note41 = row.GetCell(27).ToStr(),
                        Column42 = row.GetCell(28).ToStr().ToDecimal(),
                        Note42 = row.GetCell(29).ToStr(),
                        Column43 = row.GetCell(30).ToStr().ToDecimal(),
                        Note43 = row.GetCell(31).ToStr(),
                        Column44 = row.GetCell(32).ToStr().ToDecimal(),
                        Note44 = row.GetCell(33).ToStr(),
                        Column45 = row.GetCell(34).ToStr().ToDecimal(),
                        Note45 = row.GetCell(35).ToStr(),
                        Column46 = row.GetCell(36).ToStr().ToDecimal(),
                        Note46 = row.GetCell(37).ToStr(),
                        Column47 = row.GetCell(38).ToStr().ToDecimal(),
                        Note47 = row.GetCell(39).ToStr(),
                        Column5 = row.GetCell(40).ToStr().ToDecimal(),
                        Note5 = row.GetCell(41).ToStr(),
                        FileId = modelId.ToString(),
                        Year = currentYear.Value.ToInt()
                    };
                    list.Add(item);
                }
            }

            this.budgetReceiptRepository.Delete(r => r.Year.ToString() == currentYear.Value && r.Type == type);
            this.budgetReceiptRepository.InsertRange(list);
            return modelId;
        }

        #endregion
    }
}



