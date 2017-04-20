// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBudgetReceiptAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   年度预算收入应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;

    using SCBF.Finance.Dto;

    using TAF.Utility;

    /// <summary>
    /// 年度预算收入应用接口
    /// </summary>
    public interface IBudgetReceiptAppService : IBaseEntityApplicationService
    {
        List<BudgetReceiptListDto> Get(int type);
        List<KeyValue<Guid, string, string, decimal>> GetSimple(int type);

        Guid LoadBudgetReceiptFile1(string path);
        Guid LoadBudgetReceiptFile2(string path);
        Guid LoadBudgetReceiptFile3(string path);
    }
}



