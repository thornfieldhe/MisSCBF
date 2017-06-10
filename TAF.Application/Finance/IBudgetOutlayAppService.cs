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
        List<BudgetOutlayListDto> Get(string sheetName, int type);

        List<OutlayListDto> GetAll();

        List<BudgetOutlaySimpleListDto> GetSimple();

        Guid LoadBudgetReceiptFile1(string path);

        Guid LoadBudgetReceiptFile2(string path);

        Guid LoadBudgetReceiptFile3(string path);

        List<KeyValue<string, string>> GetSheetNames(int type);

        List<BudgetPerformanceListDto> GetBudgetPerformances();

        void Update(OutlayEditDto input);

        List<YearBudgetSummaryDto> GetSummary();

        void SaveOutlaySummary(OutlaySummaryEditDto item);

        OutlaySummaryEditDto GetOutlaySummary(string code);
    }
}



