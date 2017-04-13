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

    /// <summary>
    /// 年度预算收入应用接口
    /// </summary>
    public interface IBudgetReceiptAppService : IBaseEntityApplicationService
    {
        List<BudgetReceiptListDto> Get(int type);

        Guid LoadBudgetReceiptFile(string path);

        void ImportFromXls();
    }
}



