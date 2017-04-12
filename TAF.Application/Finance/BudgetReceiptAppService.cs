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
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using Abp.UI;

    using AutoMapper;

    using SCBF.BaseInfo;
    using SCBF.Finance.Dto;

    /// <summary>
    /// 年度预算收入服务
    /// </summary>
    [AbpAuthorize]
    public class BudgetReceiptAppService : TAFAppServiceBase, IBudgetReceiptAppService
    {
        private readonly IBudgetReceiptRepository budgetReceiptRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;

        public BudgetReceiptAppService(IBudgetReceiptRepository budgetReceiptRepository, ISysDictionaryRepository sysDictionaryRepository)
        {
            this.budgetReceiptRepository = budgetReceiptRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
        }

        public ListResultDto<BudgetReceiptListDto> Get(BundgetType type)
        {
            var currentYear = this.sysDictionaryRepository.FirstOrDefault(r=>r.Value4==true.ToString() && r.Category==DictionaryCategory.Budget_Year);
            if(currentYear==null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var result =
                this.budgetReceiptRepository.GetAllList(r => r.Year == int.Parse(currentYear.Value) && r.Type == type);
            return null;
        }

        public BudgetReceiptEditDto Get(Guid id) { throw new NotImplementedException(); }

        public void ImportFromXls() { throw new NotImplementedException(); }
    }
}



