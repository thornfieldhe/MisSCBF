// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStoreStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   历史油料/加油卡库存服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Authorization;
    using Abp.UI;
    using SCBF.BaseInfo;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TAF.Utility;

    /// <summary>
    /// 历史油料/加油卡库存服务
    /// </summary>
    [AbpAuthorize]
    public class HisStoreStockAppService : TAFAppServiceBase, IHisStoreStockAppService
    {
        private readonly IHisOctaneStoreStockRepository _hisOctaneStoreStockRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;
        private readonly IOilCardRepository _oilCardRepository;
        private readonly IOctaneStoreRepository _octaneStoreRepository;
        private readonly IApplicationForBunkerBRepository _applicationForBunkerBRepository;
        private readonly IApplicationForBunkerARepository _applicationForBunkerARepository;
        private readonly IOilRechargeRecordRepository _oilRechargeRecordRepository;

        public HisStoreStockAppService(
            IHisOctaneStoreStockRepository hisOctaneStoreStockRepository,
            ISysDictionaryRepository sysDictionaryRepository,
            IOilCardRepository oilCardRepository,
            IOctaneStoreRepository octaneStoreRepository,
            IApplicationForBunkerBRepository applicationForBunkerBRepository,
            IApplicationForBunkerARepository applicationForBunkerARepository, 
            IOilRechargeRecordRepository oilRechargeRecordRepository)
        {
            this._hisOctaneStoreStockRepository = hisOctaneStoreStockRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
            this._oilCardRepository = oilCardRepository;
            this._octaneStoreRepository = octaneStoreRepository;
            this._applicationForBunkerBRepository = applicationForBunkerBRepository;
            this._applicationForBunkerARepository = applicationForBunkerARepository;
            this._oilRechargeRecordRepository = oilRechargeRecordRepository;
        }


        public KeyValue<decimal, decimal> Get(int month, int category)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);
            var yearMonth = new DateTime(int.Parse(currentYearItem.Value), month, 1);
            var yearMonthTo = yearMonth.ToString("yyyyMM");
            var yearMonthFrom = yearMonth.AddMonths(-1).ToString("yyyyMM");
            var item = this._hisOctaneStoreStockRepository.FirstOrDefault(
                r => r.YearMonth == yearMonthFrom && r.Category == category);

            var item2 = this._hisOctaneStoreStockRepository.FirstOrDefault(
                r => r.YearMonth == yearMonthTo && r.Category == category);

            decimal amount1 = item == null ? 0 : item.Amount;
            decimal amount2 = 0;
            if (item2 == null)
            {
                switch (category)
                {
                    case 0:
                        amount2 = amount1 - this._applicationForBunkerARepository
                            .GetAllList(
                                r => r.Date.Year == year && r.Date.Month == month && r.Status == ApplicationForBunkerAStatus.Confirm).Sum(r => r.Amount)+
                                  this._oilCardRepository.GetAllList(r => r.CreationTime.Year == year && r.CreationTime.Month == month).Sum(r => r.Amount);
                        break;
                    case 1:
                        amount2 = amount1 - this._applicationForBunkerBRepository
                            .GetAllList(
                                r => r.Date.Year == year && r.Date.Month == month && r.Status == ApplicationForBunkerAStatus.Checked).Sum(r => r.AuditingAmount) +
                        this._oilRechargeRecordRepository.GetAllList(r => r.CreationTime.Year == year && r.CreationTime.Month == month).Sum(r=>r.Amount);

                        break;
                }
            }
            else
            {
                amount2 = item2.Amount;
            }

            return new KeyValue<decimal, decimal>
            {
                Key = amount1,
                Value = amount2
            };
        }

        /// <summary>
        /// 累计加油量/加油卡金额
        /// </summary>
        /// <param name="month"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public  decimal GetChangedAmount(int month, int category)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);
            var yearMonth = new DateTime(int.Parse(currentYearItem.Value), month, 1);
            var yearMonthTo = yearMonth.ToString("yyyyMM");

            var item = this._hisOctaneStoreStockRepository.FirstOrDefault(
                r => r.YearMonth == yearMonthTo && r.Category == category);

            decimal amount = 0;
            if (item == null)
            {
                switch (category)
                {
                    case 0:
                        amount = this._applicationForBunkerARepository
                            .GetAllList(
                                r => r.Date.Year == year && r.Date.Month == month && r.Status == ApplicationForBunkerAStatus.Confirm).Sum(r => r.ConfirmAmount);
                        break;
                    case 1:
                        amount = this._applicationForBunkerBRepository
                            .GetAllList(
                                r => r.Date.Year == year && r.Date.Month == month && r.Status == ApplicationForBunkerAStatus.Checked).Sum(r => r.AuditingAmount) ;
                        break;
                }
            }
            else
            {
                amount = item.Amount;
            }

            return amount;
        }

        public List<HisOilStoreListDto> GetOilStoreHis(int quarter)
        {
            var list = this._octaneStoreRepository.GetAllList();
            var result = new List<HisOilStoreListDto>();
            foreach (var i in list)
            {
                var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
                if (currentYearItem == null)
                {
                    throw new UserFriendlyException("预算年度不存在");
                }
                var year = int.Parse(currentYearItem.Value);
                var monthTo = 1;
                switch (quarter)
                {
                    case 0:
                        monthTo = 3;
                        break;
                    case 1:
                        monthTo = 6;
                        break;
                    case 2:
                        monthTo = 9;
                        break;
                    case 3:
                        monthTo = 12;
                        break;
                }

                var yearMonth = new DateTime(int.Parse(currentYearItem.Value), monthTo, 1);
                var yearMonthTo = yearMonth.ToString("yyyyMM");
                var yearMonthFrom = yearMonth.AddMonths(-2).ToString("yyyyMM");
                var item = this._hisOctaneStoreStockRepository.FirstOrDefault(
                    r => r.YearMonth == yearMonthFrom && r.Category == 1 && r.OctaneStoreId == i.Id);

                var item2 = this._hisOctaneStoreStockRepository.FirstOrDefault(
                    r => r.YearMonth == yearMonthTo && r.Category == 1 && r.OctaneStoreId == i.Id);

                decimal amount1 = item == null ? 0 : item.Amount;
                decimal amount2 = 0;
                if (item2 == null)
                {

                    amount2 = amount1 - this._applicationForBunkerBRepository
                                  .GetAllList(
                                      r => r.Date.Year == year && r.Date.Month <= monthTo && r.Status == ApplicationForBunkerAStatus.Checked && r.OctaneStoreId == i.Id)
                                  .Sum(r => r.Amount);
                }
                else
                {
                    amount2 = item2.Amount;
                }


                var octaneRating = this._sysDictionaryRepository.Get(i.OctaneRatingId);
                if (octaneRating == null)
                {
                    throw new UserFriendlyException("油料标号不存在");
                }

                var store = this._sysDictionaryRepository.Get(i.StoreId);
                if (store == null)
                {
                    throw new UserFriendlyException("代管单位不存在");
                }

                result.Add(new HisOilStoreListDto()
                {
                    Id = i.Id,
                    FromAmount = amount1,
                    ToAmount = amount2,
                    Name = $"{store.Value}-{octaneRating.Value}",
                    FromAmountAsT = string.IsNullOrWhiteSpace(octaneRating.Value2) ? amount1 : Math.Floor(amount1 / decimal.Parse(octaneRating.Value2)),
                    ToAmountAsT = string.IsNullOrWhiteSpace(octaneRating.Value2) ? amount2 : Math.Floor(amount2 / decimal.Parse(octaneRating.Value2))
                });

            }

            return result;
        }

        public List<HisOilCardListDto> GetOilCardHis(int quarter)
        {
            var list = this._oilCardRepository.GetAllList();
            var result = new List<HisOilCardListDto>();
            foreach (var i in list)
            {
                var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(
                    r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
                if (currentYearItem == null)
                {
                    throw new UserFriendlyException("预算年度不存在");
                }
                var year = int.Parse(currentYearItem.Value);
                var monthTo = 1;
                switch (quarter)
                {
                    case 0:
                        monthTo = 3;
                        break;
                    case 1:
                        monthTo = 6;
                        break;
                    case 2:
                        monthTo = 9;
                        break;
                    case 3:
                        monthTo = 12;
                        break;
                }

                var yearMonth = new DateTime(int.Parse(currentYearItem.Value), monthTo, 1);
                var yearMonthTo = yearMonth.ToString("yyyyMM");
                var yearMonthFrom = yearMonth.AddMonths(-3).ToString("yyyyMM");
                var item = this._hisOctaneStoreStockRepository.FirstOrDefault(
                    r => r.YearMonth == yearMonthFrom && r.Category == 0 && r.OctaneStoreId == i.Id);

                var item2 = this._hisOctaneStoreStockRepository.FirstOrDefault(
                    r => r.YearMonth == yearMonthTo && r.Category == 0);

                decimal amount1 = item == null ? 0 : item.Amount;
                decimal amount2 = 0;
                if (item2 == null)
                {

                    amount2 = this._applicationForBunkerARepository
                        .GetAllList(
                            r => r.Date.Year == year
                                 && r.Date.Month <= monthTo && r.Status == ApplicationForBunkerAStatus.Confirm
                                 && r.OilCardId == i.Id).Sum(r => r.Amount);
                }
                else
                {
                    amount2 = item2.Amount;
                }


                result.Add(
                    new HisOilCardListDto() { Id = i.Id, FromAmount = amount1, ToAmount = amount2, Code = i.Code });
            }

            return result;
        }

        /// <summary>
        /// 每月定时备份库存量
        /// </summary>
        [AbpAllowAnonymous]
        public void BackupData()
        {
            var stores = this._octaneStoreRepository.GetAll();

            foreach (var store in stores)
            {
                var input = new HisStockDto()
                {
                    Amount = store.Amount,
                    YearMonth = store.CreationTime.ToString("yyyyMM"),
                    Category = 1,
                    Id = store.Id
                };
                Add(input);
            }

            var cards = this._oilCardRepository.GetAll();

            foreach (var card in cards)
            {
                var input = new HisStockDto()
                {
                    Amount = card.Amount,
                    YearMonth = card.CreationTime.ToString("yyyyMM"),
                    Category = 1,
                    Id = card.Id
                };
                Add(input);
            }
        }


        private void Add(HisStockDto input)
        {
            var item = this._hisOctaneStoreStockRepository.FirstOrDefault(
                r => r.YearMonth == input.YearMonth && r.Category == input.Category);
            if (item == null)
            {
                item = new HisCarStoreStock()
                {
                    YearMonth = input.YearMonth,
                    Category = input.Category,
                    OctaneStoreId = input.Id,
                    Amount = input.Amount
                };
                this._hisOctaneStoreStockRepository.Insert(item);
            }
            else
            {
                item.Amount = input.Amount;
                this._hisOctaneStoreStockRepository.Update(item);
            }
        }
    }
}



