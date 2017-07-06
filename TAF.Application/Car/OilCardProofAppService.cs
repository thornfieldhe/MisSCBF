// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardProofAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡消耗凭证单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using SCBF.BaseInfo;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;
    using TAF.Utility;

    /// <summary>
    /// 加油卡消耗凭证单服务
    /// </summary>
    [AbpAuthorize]
    public class OilCardProofAppService : TAFAppServiceBase, IOilCardProofAppService
    {
        private readonly IOilCardProofRepository oilCardProofRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IApplicationForBunkerARepository applicationForBunkerARepository;
        private IWorkbook workbook = null;

        public OilCardProofAppService(IOilCardProofRepository oilCardProofRepository, ISysDictionaryRepository sysDictionaryRepository, IApplicationForBunkerARepository applicationForBunkerARepository)
        {
            this.oilCardProofRepository = oilCardProofRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.applicationForBunkerARepository = applicationForBunkerARepository;
        }

        public List<OilCardProofListDto> GetAll(string month)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var result =
                this.oilCardProofRepository.GetAllList(r => r.Month == currentYearItem.Value + month)
                    .OrderBy(r => r.Date).ToList().MapTo<List<OilCardProofListDto>>();
            return result;
        }

        public string GetNote(Guid id)
        {
            var output = this.oilCardProofRepository.Get(id);
            if (output == null)
            {
                throw new UserFriendlyException("加油卡消耗凭证不存在");
            }
            return output.Note;

        }

        public async Task SaveNote(KeyValuePair<Guid, string> input)
        {
            var item = this.oilCardProofRepository.Get(input.Key);
            if (item == null)
            {
                throw new UserFriendlyException($"加油卡消耗凭证不存在[{input.Key}],内部错误详见:98434FAA-54DF-4C1B-82D5-3CA390ED0CB8");
            }
            item.Note = input.Value;
            await this.oilCardProofRepository.UpdateAsync(item);
        }

        public void LoadProofFile(string path, string month)
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

            var list = new List<UploadOilCardRoof>();
            for (var j = 0; j < this.workbook.NumberOfSheets; j++)
            {
                var sheet = this.workbook.GetSheetAt(j);

                //最后一列的标号
                var rowCount = sheet.LastRowNum + 1;


                for (var i = 1; i < rowCount; i++)
                {
                    var row = sheet.GetRow(i);
                    if (!string.IsNullOrEmpty(row.GetCell(0).ToStr()))
                    {
                        var item = new UploadOilCardRoof()
                        {
                            Amount = row.GetCell(13).ToStr().ToDecimal(),
                            Date = row.GetCell(9).ToStr().ToDate(),
                            CarCode = row.GetCell(1).ToStr(),
                            AmountOfMoney = row.GetCell(5).ToStr().ToDecimal()
                        };
                        list.Add(item);
                    }
                }
            }
            var list1 = list.Select(r => r.CarCode + r.Date.ToString("yyyyMM")).ToList(); // 消耗凭证单

            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var yearmonth = $"{currentYear.Value}{month}";
            this.oilCardProofRepository.Delete(r => r.Month == yearmonth);

            var bunker = this.applicationForBunkerARepository.Get(r => r.Date.Year.ToString() == currentYear.Value && r.Date.Month.ToString() == month).ToList();
            var list2 = bunker.Select(r => r.OilCard.Code + r.Date.ToString("yyyyMM")).ToList(); //加油审批表

            var list3 = list1.Intersect(list2);
            var list4 = list1.Except(list2);
            var list5 = list2.Except(list1);

            var dataList = new List<OilCardProof>();

            foreach (var item in bunker)
            {
                var dt = item.OilCard.Code + item.Date.ToString("yyyyMM");
                var fileRow = list.SingleOrDefault(r => r.CarCode == item.OilCard.Code && r.AmountOfMoney == item.ConfirmAmount && r.Date.Month == item.Date.Month && r.Date.Day == item.Date.Day);
                var row = new OilCardProof()
                {
                    Date = fileRow?.Date.ToString() ?? string.Empty,
                    Cph = item.OilCard.CarInfo.Cph,
                    Month = item.Date.ToString("yyyyMM"),
                    BunkerACode = item.Code,
                    CardNo = item.OilCard.Code,
                    Clxh = item.OilCard.CarInfo.Clxh,
                    Jsy = item.Driver.Name,
                    Jyje = item.ConfirmAmount,
                    Msjg = fileRow != null ? decimal.Round(item.ConfirmAmount / fileRow.Amount, 2, MidpointRounding.AwayFromZero) : 0,
                    Ss = fileRow?.Amount ?? 0,
                    Sy = item.Note,
                    Syje = item.TotalAmount - item.ConfirmAmount,
                    Ylbh = sysDictionaryRepository.FirstOrDefault(r => r.Id == item.OilCard.CarInfo.OctaneRatingId)
                        .Value,
                    Yyje = item.ConfirmAmount
                };
                dataList.Add(row);
            }

            foreach (var item in list5)
            {

            }

        }
    }
}



