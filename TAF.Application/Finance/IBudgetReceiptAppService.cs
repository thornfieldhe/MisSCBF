﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBudgetReceiptAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   年度预算收入应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using SCBF.Finance.Dto;
    using System;
    using System.Collections.Generic;
    using TAF.Utility;

    /// <summary>
    /// 年度预算收入应用接口
    /// </summary>
    public interface IBudgetReceiptAppService : IBaseEntityApplicationService
    {
        List<BudgetReceiptListDto> Get(int type);

        List<ReceiptListDto> GetReceipts();

        void SaveReceuotAmount(KeyValue<string, decimal> item);

        ReceiptEditDto GetReceipt(string code);

        List<KeyValue<Guid, string, string, decimal>> GetSimple(int type);

        Guid LoadBudgetReceiptFile1(string path, object param);

        Guid LoadBudgetReceiptFile2(string path, object param);

        Guid LoadBudgetReceiptFile3(string path, object param);
    }
}



