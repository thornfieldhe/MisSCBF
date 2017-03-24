// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   库存应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using SCBF.Storage.Dto;

    /// <summary>
    /// 库存应用接口
    /// </summary>
    public interface IStockAppService : IDefaultEntityApplicationService
    {
        ListResultDto<StockListDto> GetAll(StockQueryDto request);

        StockEditDto Get(Guid id);

        Task SaveAsync(StockEditDto input);

        void Delete(Guid id);
    }
}



