// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   盘点服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using Abp.Authorization;
    using Abp.UI;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using SCBF.BaseInfo;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using TAF.Utility;

    /// <summary>
    /// 盘点服务
    /// </summary>
    [AbpAuthorize]
    public class CheckBillAppService : TAFAppServiceBase, ICheckBillAppService
    {
        private readonly ICheckBillRepository checkBillRepository;
        private readonly IProductRepository productRepository;
        private readonly IStockRepository stockRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IEntryRepository entryRepository;
        private IWorkbook workbook;

        public CheckBillAppService(
            ICheckBillRepository checkBillRepository,
            IProductRepository productRepository,
            IEntryRepository entryRepository,
            IStockRepository stockRepository,
                                   ISysDictionaryRepository sysDictionaryRepository
            )
        {
            this.checkBillRepository = checkBillRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.productRepository = productRepository;
            this.stockRepository = stockRepository;
            this.entryRepository = entryRepository;
        }

        public Guid LoadCheckFile(string path, object param)
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
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
            var sheet = this.workbook.GetSheetAt(0);

            //最后一列的标号
            var rowCount = sheet.LastRowNum + 1;
            var currentYear = this.sysDictionaryRepository.FirstOrDefault(r => r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }

            var stockId = param as Guid?;

            if (!stockId.HasValue)
            {
                throw new UserFriendlyException("请选择仓库");
            }

            var bill = new CheckBill()
            {
                Code = this.GetMaxCode(),
                Date = DateTime.Now,
                Year = currentYear.Value.ToInt(),
                StorageId = stockId.Value,
                Id = Guid.NewGuid(),
                Checks = new List<Check>()
            };


            for (var i = 1; i < rowCount; i++)
            {
                var row = sheet.GetRow(i);
                var code = row.GetCell(0).ToStr();
                var amount = row.GetCell(2).ToStr().ToDecimal();
                var pre = $"RK{DateTime.Now.Year}";
                if (!string.IsNullOrEmpty(code))
                {
                    var product = productRepository.FirstOrDefault(r => r.Code == code);
                    if (product == null)
                    {
                        throw new UserFriendlyException($"商品编码[{code}]不存在");
                    }

                    var stockAmount = this.stockRepository.GetAllList(r => r.ProductId == product.Id && r.StorageId == stockId.Value).Sum(r => r.Amount);
                    var changeAmount = amount - stockAmount;
                    decimal price;
                    if (changeAmount < 0)
                    {
                        var entry = this.entryRepository.FirstOrDefault(r => r.ProductId == product.Id && r.EntryBill.Code.StartsWith(pre));
                        if (entry == null)
                        {
                            price = 0;
                        }
                        else
                        {
                            price = entry.Price * changeAmount;
                        }
                    }
                    else
                    {
                        var entry = this.entryRepository.Get(r => r.ProductId == product.Id && r.EntryBill.Code.StartsWith(pre))
                            .OrderByDescending(r => r.CreationTime).FirstOrDefault();
                        if (entry == null)
                        {
                            price = 0;
                        }
                        else
                        {
                            price = entry.Price * changeAmount;
                        }
                    }

                    var item = new Check()
                    {
                        ProductId = product.Id,
                        Amount = amount,
                        StockAmount = stockAmount,
                        Price = price
                    };

                    bill.Checks.Add(item);
                }
            }

            this.checkBillRepository.Insert(bill);
            return bill.Id;
        }

        private string GetMaxCode()
        {
            var preCode = DateTime.Today.ToString("yyyyMMdd");
            var maxCode =
                this.checkBillRepository.Get(r => r.Code.StartsWith("PD" + preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"PD{preCode}001";
            }
            else
            {
                return $"PD{long.Parse(maxCode.Substring(2)) + 1}";
            }
        }
    }
}



