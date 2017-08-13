// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHisStoreStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料加油审批单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using SCBF.Car.Dto;
    using System.Collections.Generic;
    using TAF.Utility;

    /// <summary>
    /// 实物油料/加油卡历史库存应用接口
    /// </summary>
    public interface IHisStoreStockAppService : IBaseEntityApplicationService
    {
        KeyValue<decimal, decimal> Get(int month, int category);

        List<HisOilStoreListDto> GetOilStoreHis(int quarter);

        List<HisOilCardListDto> GetOilCardHis(int quarter);

        decimal GetChangedAmount(int month, int category);

        void BackupData();
    }
}



