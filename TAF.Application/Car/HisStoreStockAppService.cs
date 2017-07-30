// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStoreStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料加油审批单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Authorization;
    using Abp.UI;
    using SCBF.BaseInfo;
    using SCBF.Car.Dto;
    using System;
    using System.Linq;

    using TAF.Utility;

    /// <summary>
    /// 实物油料加油审批单服务
    /// </summary>
    [AbpAuthorize]
    public class HisStoreStockAppService : TAFAppServiceBase, IHisStoreStockAppService
    {
        private readonly IHisOctaneStoreStockRepository hisOctaneStoreStockRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IOilCardRepository oilCardRepository;
        private readonly IOctaneStoreRepository octaneStoreRepository;
        private readonly IApplicationForBunkerBRepository applicationForBunkerBRepository;
        private readonly IApplicationForBunkerARepository applicationForBunkerARepository;

        public HisStoreStockAppService(
            IHisOctaneStoreStockRepository hisOctaneStoreStockRepository,
            ISysDictionaryRepository sysDictionaryRepository,
            IOilCardRepository oilCardRepository,
            IOctaneStoreRepository octaneStoreRepository,
            IApplicationForBunkerBRepository applicationForBunkerBRepository,
            IApplicationForBunkerARepository applicationForBunkerARepository)
        {
            this.hisOctaneStoreStockRepository = hisOctaneStoreStockRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.oilCardRepository = oilCardRepository;
            this.octaneStoreRepository = octaneStoreRepository;
            this.applicationForBunkerBRepository = applicationForBunkerBRepository;
            this.applicationForBunkerARepository = applicationForBunkerARepository;
        }


        public KeyValue<decimal, decimal> Get(int month, int category)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);
            var yearMonth = new DateTime(int.Parse(currentYearItem.Value), month, 1);
            var yearMonthTo = yearMonth.ToString("yyyyMM");
            var yearMonthFrom = yearMonth.AddMonths(-1).ToString("yyyyMM");
            var item = this.hisOctaneStoreStockRepository.FirstOrDefault(
                r => r.YearMonth == yearMonthFrom && r.Category == category);

            var item2 = this.hisOctaneStoreStockRepository.FirstOrDefault(
                r => r.YearMonth == yearMonthTo && r.Category == category);

            decimal amount1 = item == null ? 0 : item.Amount;
            decimal amount2 = 0;
            if (item2 == null)
            {
                switch (category)
                {
                    case 0:
                        amount2 = this.applicationForBunkerARepository
                            .GetAllList(
                                r => r.Date.Year == year && r.Date.Month == month && r.Status == ApplicationForBunkerAStatus.Confirm)
                            .Sum(r => r.Amount);
                        break;
                    case 1:
                        amount2 = this.applicationForBunkerBRepository
                            .GetAllList(
                                r => r.Date.Year == year && r.Date.Month == month && r.Status == ApplicationForBunkerAStatus.Checked)
                            .Sum(r => r.Amount);
                        break;
                }

            }

            var result = new KeyValue<decimal, decimal>
            {
                Key = amount1,
                Value = item2 == null ? amount1 - amount2 : amount2
            };


            return result;
        }

        /// <summary>
        /// 每月定时备份库存量
        /// </summary>
        [AbpAllowAnonymous]
        public void BackupData()
        {
            var stores = this.octaneStoreRepository.GetAll();

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

            var cards = this.oilCardRepository.GetAll();

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
            var item = this.hisOctaneStoreStockRepository.FirstOrDefault(
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
                this.hisOctaneStoreStockRepository.Insert(item);
            }
            else
            {
                item.Amount = input.Amount;
                this.hisOctaneStoreStockRepository.Update(item);
            }
        }
    }
}



