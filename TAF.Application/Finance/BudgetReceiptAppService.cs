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
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using Abp.UI;

    using AutoMapper;

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
        private IWorkbook workbook = null;

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
            result.ForEach(item => item.Name = accounts.First(r => r.Key == item.Code).Value);
            return result;
        }

        public Guid LoadBudgetReceiptFile(string path)
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
                if (row.GetCell(0) != null && !string.IsNullOrEmpty(row.GetCell(0).ToString()))
                {
                    var item = new BudgetReceipt()
                    {
                        Code = row.GetCell(0).ToString(),
                        Column1 = decimal.Parse(row.GetCell(4).ToString()),
                        Note1 = row.GetCell(5).ToString(),
                        Column21 = decimal.Parse(row.GetCell(6).ToString()),
                        Note21 = row.GetCell(7).ToString(),
                        Column22 = decimal.Parse(row.GetCell(8).ToString()),
                        Note22 = row.GetCell(9).ToString(),
                        Column31 = decimal.Parse(row.GetCell(11).ToString()),
                        Note31 = row.GetCell(12).ToString(),
                        Column32 = decimal.Parse(row.GetCell(13).ToString()),
                        Note32 = row.GetCell(14).ToString(),
                        Column33 = decimal.Parse(row.GetCell(15).ToString()),
                        Note33 = row.GetCell(16).ToString(),
                        Column34 = decimal.Parse(row.GetCell(17).ToString()),
                        Note34 = row.GetCell(18).ToString(),
                        Column35 = decimal.Parse(row.GetCell(19).ToString()),
                        Note35 = row.GetCell(20).ToString(),
                        Column36 = decimal.Parse(row.GetCell(21).ToString()),
                        Note36 = row.GetCell(22).ToString(),
                        Column37 = decimal.Parse(row.GetCell(23).ToString()),
                        Note37 = row.GetCell(24).ToString(),
                        Column41 = decimal.Parse(row.GetCell(26).ToString()),
                        Note41 = row.GetCell(27).ToString(),
                        Column42 = decimal.Parse(row.GetCell(28).ToString()),
                        Note42 = row.GetCell(29).ToString(),
                        Column43 = decimal.Parse(row.GetCell(30).ToString()),
                        Note43 = row.GetCell(31).ToString(),
                        Column44 = decimal.Parse(row.GetCell(32).ToString()),
                        Note44 = row.GetCell(33).ToString(),
                        Column45 = decimal.Parse(row.GetCell(34).ToString()),
                        Note45 = row.GetCell(35).ToString(),
                        Column46 = decimal.Parse(row.GetCell(36).ToString()),
                        Note46 = row.GetCell(37).ToString(),
                        Column47 = decimal.Parse(row.GetCell(38).ToString()),
                        Note47 = row.GetCell(39).ToString(),
                        Column5 = decimal.Parse(row.GetCell(40).ToString()),
                        Note5 = row.GetCell(41).ToString(),
                        FileId = modelId.ToString(),
                        Type = BungetType.Year,
                        Year = currentYear.Value.ToInt()
                    };
                    list.Add(item);
                }
            }

            this.budgetReceiptRepository.Delete(r => r.Year.ToString() == currentYear.Value);
            this.budgetReceiptRepository.InsertRange(list);
            return modelId;
        }
    }
}



