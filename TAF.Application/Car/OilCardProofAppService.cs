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
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IApplicationForBunkerARepository applicationForBunkerARepository;
        private readonly IUploadOilCardRoofRepository uploadOilCardRoofRepository;
        private readonly IUploadOilCarRoofRelationshipRepository uploadOilCarRoofRelationshipRepository;
        private IWorkbook workbook = null;

        public OilCardProofAppService(
            ISysDictionaryRepository sysDictionaryRepository,
            IApplicationForBunkerARepository applicationForBunkerARepository,
            IUploadOilCarRoofRelationshipRepository uploadOilCarRoofRelationshipRepository,
            IUploadOilCardRoofRepository uploadOilCardRoofRepository)
        {
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.applicationForBunkerARepository = applicationForBunkerARepository;
            this.uploadOilCardRoofRepository = uploadOilCardRoofRepository;
            this.uploadOilCarRoofRelationshipRepository = uploadOilCarRoofRelationshipRepository;
        }

        public List<OilCardProofListDto> GetAll(string month)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var monthInt = int.Parse(month);
            var yearmonth = $"{currentYearItem.Value}{month}";
            var result = from r in this.uploadOilCarRoofRelationshipRepository.GetAllList(r => r.Month == yearmonth)
                         join a in this.applicationForBunkerARepository.GetAllList(r => r.Date.Year.ToString() == currentYearItem.Value && r.Date.Month == monthInt) on r.OId equals a.Id
                         join o in this.uploadOilCardRoofRepository.GetAllList(r => r.Month == yearmonth) on r.RId equals o.Id
                         join d in this.sysDictionaryRepository.GetAll() on a.OilCard.CarInfo.OctaneRatingId equals d.Id
                         select new OilCardProofListDto()
                         {
                             Date = o.Date.ToString("yyyy-MM-dd"),
                             Month = r.Month,
                             Id = r.Id,
                             CarCode = a.OilCard.Code,
                             Note = r.Note,
                             BunkerACode = a.Code,
                             Jsy = a.Driver.Name,
                             Clxh = a.OilCard.CarInfo.Clxh,
                             Jyje = a.ConfirmAmount,
                             Jysh = o.Amount,
                             Msjg = decimal.Round(a.ConfirmAmount / o.Amount, 2, MidpointRounding.AwayFromZero),
                             Syje = a.TotalAmount - a.ConfirmAmount,
                             Ylbh = d.Value,
                             Yyje = a.TotalAmount,
                             Sy = a.Note
                         };
            return result.ToList();
        }

        public List<ApplicationForBunkerAListDto> GetApplicationForBunkerAList(string month)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var yearmonth = $"{currentYearItem.Value}{month}";
            var intMonth = int.Parse(month);
            var roofList = this.uploadOilCarRoofRelationshipRepository.GetAllList(r => r.Month == yearmonth).Select(r => r.OId).ToList();
            var result = this.applicationForBunkerARepository.GetAllList(r => r.Date.Year.ToString() == currentYearItem.Value && r.Date.Month == intMonth && !roofList.Contains(r.Id));
            return result.MapTo<List<ApplicationForBunkerAListDto>>();
        }

        public List<UploadOilCarRoofListDto> GetUploadOilCarRoof(string month)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var yearmonth = $"{currentYearItem.Value}{month}";
            var intMonth = int.Parse(month);
            var roofList = this.uploadOilCarRoofRelationshipRepository.GetAllList(r => r.Month == yearmonth).Select(r => r.RId).ToList();
            var result = this.uploadOilCardRoofRepository.GetAllList(r => r.Date.Year.ToString() == currentYearItem.Value && r.Date.Month == intMonth && !roofList.Contains(r.Id));
            return result.MapTo<List<UploadOilCarRoofListDto>>();
        }

        public void Link(KeyValue<Guid, Guid, string> item)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var yearmonth = $"{currentYearItem.Value}{item.Item3}";
            var o = this.applicationForBunkerARepository.FirstOrDefault(r => r.Id == item.Key);
            if (o == null)
            {
                throw new UserFriendlyException("加油卡申请单不存在");
            }

            var u = this.uploadOilCardRoofRepository.FirstOrDefault(r => r.Id == item.Value);
            if (u == null)
            {
                throw new UserFriendlyException("加油凭证不存在");
            }

            var i = new UploadOilCarRoofRelationship
            {
                Month = yearmonth,
                RId = item.Value,
                OId = item.Key
            };

            this.uploadOilCarRoofRelationshipRepository.Insert(i);
        }

        public string GetNote(Guid id)
        {
            var output = this.uploadOilCarRoofRelationshipRepository.Get(id);
            if (output == null)
            {
                throw new UserFriendlyException("加油卡消耗凭证不存在");
            }
            return output.Note;

        }

        public async Task SaveNote(KeyValuePair<Guid, string> input)
        {
            var item = this.uploadOilCarRoofRelationshipRepository.Get(input.Key);
            if (item == null)
            {
                throw new UserFriendlyException($"加油卡消耗凭证不存在[{input.Key}],内部错误详见:98434FAA-54DF-4C1B-82D5-3CA390ED0CB8");
            }
            item.Note = input.Value;
            await this.uploadOilCarRoofRelationshipRepository.UpdateAsync(item);
        }

        public Guid LoadProofFile(string path, object monthPar)
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var month = (monthPar as string[])[0];
            var modeId = Guid.NewGuid();
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

            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var yearmonth = $"{currentYear.Value}{month}";

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
                            AmountOfMoney = row.GetCell(5).ToStr().ToDecimal(),
                            Month = yearmonth,
                            FileId = modeId
                        };
                        list.Add(item);
                    }
                }
            }

            this.uploadOilCardRoofRepository.Delete(r => r.Month == yearmonth); // 删除当月凭证单
            this.uploadOilCardRoofRepository.InsertRange(list); // 重新插入凭证数据

            var list1 = list.Select(r => new KeyValue<string, Guid, decimal>() { Key = r.CarCode + r.Date.ToString("yyyyMM"), Value = r.Id, Item3 = r.AmountOfMoney }).ToList(); // 消耗凭证表

            var monthInt = int.Parse(month);
            var bunker = this.applicationForBunkerARepository.Get(r => r.Date.Year.ToString() == currentYear.Value && r.Date.Month == monthInt).ToList();
            var list2 = bunker.Select(r => new KeyValue<string, Guid, decimal>() { Key = r.OilCard.Code + r.Date.ToString("yyyyMM"), Value = r.Id, Item3 = r.ConfirmAmount }).ToList(); //加油审批表


            var list10 = (from l1 in list1
                          join l2 in list2 on l1.Key equals l2.Key
                          where l1.Item3 == l2.Item3
                          select new UploadOilCarRoofRelationship
                          {
                              Month = yearmonth,
                              RId = l1.Value,
                              OId = l2.Value
                          }).ToList();

            this.uploadOilCarRoofRelationshipRepository.InsertRange(list10);
            return modeId;
        }
    }
}



