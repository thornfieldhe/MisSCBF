// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBudgetOutlayAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   支出预算应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using SCBF.Finance.Dto;
    using System;
    using System.Collections.Generic;
    using TAF.Utility;

    /// <summary>
    /// 支出预算应用接口
    /// </summary>
    public interface IBudgetOutlayAppService : IBaseEntityApplicationService
    {
        List<BudgetOutlayListDto> Get(string type);

        List<OutlayListDto> GetAll();

        List<BudgetOutlaySimpleListDto> GetSimple();

        Guid LoadBudgetReceiptFile(string path);

        List<KeyValue<string, string>> GetSheetNames();

        void Update(OutlayEditDto input);

        List<YearBudgetSummaryDto> GetSummary();
    }
}



