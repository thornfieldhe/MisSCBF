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
    using System.Threading.Tasks;

    using SCBF.Finance.Dto;

    using Abp.Application.Services.Dto;

    using TAF.Utility;

    /// <summary>
    /// 支出预算应用接口
    /// </summary>
    public interface IBudgetOutlayAppService : IBaseEntityApplicationService
    {
        List<BudgetOutlayListDto> Get(string type);

        Guid LoadBudgetReceiptFile(string path);

        List<KeyValue<string, string>> GetSheetNames();

        void Update(BudgetOutlayEditDto input);
    }
}



