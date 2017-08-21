// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplyForVehicleMaintenanceAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using SCBF.Car.Dto;
    using System;
    using System.Threading.Tasks;
    using TAF.Utility;

    /// <summary>
    /// 车辆送修申请单应用接口
    /// </summary>
    public interface IApplyForVehicleMaintenanceAppService : IBaseEntityApplicationService
    {
        ListResultDto<ApplyForVehicleMaintenanceListDto> GetAll(ApplyForVehicleMaintenanceQueryDto request);

        PagedResultDto<ApplyForVehicleMaintenanceListDto> GetAuditedItems(ApplyForVehicleMaintenanceQueryDto request);

        ApplyForVehicleMaintenanceEditDto Get(Guid id);

        Task SaveAsync(ApplyForVehicleMaintenanceEditDto input);

        void Auding(KeyValue<Guid, int, string> input);

        void SaveNote3(KeyValue<Guid, string, string> input);

        void Update(ApplyForVehicleMaintenanceUpdateDto input);

        void Update2(ApplyForVehicleMaintenanceUpdateDto input);

        ApplyForVehicleMaintenanceUpdateDto GetClosingItem(Guid id);

        /// <summary>
        /// 获取年度/季度维修情况报告
        /// </summary>
        /// <param name="quarter"></param>
        List<VehicleMaintenanceReportDto> GetReport(int quarter);

        void Delete(Guid id);
    }
}



