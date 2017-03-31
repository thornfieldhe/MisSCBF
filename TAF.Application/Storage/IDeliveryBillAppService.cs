// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeliveryBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System.Threading.Tasks;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 出库单应用接口
    /// </summary>
    public interface IDeliveryBillAppService : IBaseEntityApplicationService
    {
        Task SaveAsync(StockBillEditDto input);

        StockBillEditDto New();
    }
}



