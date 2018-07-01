// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarRepairTimeListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    /// <summary>
    /// 车辆返修率对象
    /// </summary>
    public class CarRepairTimeListDto
    {
        /// <summary>
        /// 返修率
        /// </summary>
        public string Value1
        {
            get; set;
        }

        /// <summary>
        /// 维修效率
        /// </summary>
        public string Value2
        {
            get; set;
        }

        /// <summary>
        /// 维修厂
        /// </summary>
        public string ServiceDepot
        {
            get; set;
        }
    }  
    
    
}



