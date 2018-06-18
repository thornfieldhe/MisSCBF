// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPerformanceManageAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   履约保证金管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;

    using SCBF.Purchase.Dto;

    /// <summary>
    /// 履约保证金管理应用接口
    /// </summary>
    public interface IPerformanceManageAppService : IBaseEntityApplicationService
    {

        PerformanceManageEditDto Get(Guid planId);

        Task SaveAsync(PerformanceManageEditDto input);

    }
}



