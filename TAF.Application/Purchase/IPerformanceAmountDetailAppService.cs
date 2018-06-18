// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPerformanceAmountDetailAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   履约保证金管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 履约保证金管理应用接口
    /// </summary>
    public interface IPerformanceAmountDetailAppService : IBaseEntityApplicationService
    {
        List<PerformanceAmountDetailDto> GetAll(Guid id);

        PerformanceAmountDetailDto Get(Guid id);

        Task SaveAsync(PerformanceAmountDetailDto input);

        void Delete(Guid id);
        string ExportDoc1(Guid id);
    }
}



