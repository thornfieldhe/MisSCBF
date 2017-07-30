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

    using TAF.Utility;

    /// <summary>
    /// 实物油料加油审批单应用接口
    /// </summary>
    public interface IHisStoreStockAppService : IBaseEntityApplicationService
    {
        KeyValue<decimal, decimal> Get(int month, int category);

        void BackupData();
    }
}



