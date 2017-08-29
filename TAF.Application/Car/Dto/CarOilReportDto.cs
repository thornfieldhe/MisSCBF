// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarOilAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
// 车辆油料核算表服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    /// <summary>
    /// 车辆油料报告
    /// </summary>
    public class CarOilReportDto
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string Cph { get; set; }

        /// <summary>
        /// Gets 预计油耗
        /// </summary>
        public decimal ExpectOilWear { get; set; }

        /// <summary>
        /// 实际油耗
        /// </summary>
        public decimal ActualOilWear { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        public string YearMonth { get; set; }

        /// <summary>
        /// 是否超标
        /// </summary>
        public string Warm => ActualOilWear > ExpectOilWear ? "超标" : "";

    }
}



