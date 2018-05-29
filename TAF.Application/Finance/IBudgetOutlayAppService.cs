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
    using System;
    using System.Collections.Generic;
    using SCBF.Finance.Dto;
    using TAF.Utility;

    /// <summary>
    /// 支出预算应用接口
    /// </summary>
    public interface IBudgetOutlayAppService : IBaseEntityApplicationService
    {
        List<BudgetOutlayListDto> Get(string sheetName, int type);

        List<OutlayListDto> GetAll();

        List<BudgetOutlaySimpleListDto> GetSimple();

        Guid LoadBudgetReceiptFile1(string path, object param);

        Guid LoadBudgetReceiptFile2(string path, object param);

        Guid LoadBudgetReceiptFile3(string path, object param);

        List<KeyValue<string, string>> GetSheetNames(int type);

        List<BudgetPerformanceListDto> GetBudgetPerformances();

        void Update(OutlayEditDto input);

        List<YearBudgetSummaryDto> GetSummary();

        void SaveOutlaySummary(OutlaySummaryEditDto item);

        OutlaySummaryEditDto GetOutlaySummary(string code);

        string Export();
    }
}



