// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepairCostAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修审批单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using SCBF.Car.Dto;
    using System.Threading.Tasks;

    /// <summary>
    /// 车辆维修审批单应用接口
    /// </summary>
    public interface IRepairCostAppService : IBaseEntityApplicationService
    {
        decimal GetBalance(string category);

        Task SaveAsync(RepairCostEditDto input);
    }
}



