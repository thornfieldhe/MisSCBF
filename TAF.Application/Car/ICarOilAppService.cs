// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICarOilAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆油料核算表应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using SCBF.Car.Dto;

    using TAF.Utility;

    /// <inheritdoc />
    /// <summary>
    /// 车辆油料核算表应用接口
    /// </summary>
    public interface ICarOilAppService : IBaseEntityApplicationService
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ListResultDto"/>.
        /// </returns>
        ListResultDto<CarOilListDto> GetAll(CarOilQueryDto request);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="CarOilEditDto"/>.
        /// </returns>
        CarOilEditDto Get(Guid id);

        /// <summary>
        /// The save async.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SaveAsync(CarOilEditDto input);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(Guid id);

        /// <summary>
        /// The get report.
        /// </summary>
        /// <param name="ym">
        /// The year.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<CarOilReportDto> GetReport(KeyValue<int, int> ym);
    }
}



