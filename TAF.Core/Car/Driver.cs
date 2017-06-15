// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Driver.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Driver
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using SCBF.BaseInfo;
    using System;

    /// <summary>
    /// 驾驶员
    /// </summary>
    public class Driver : TAFEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 士兵证号
        /// </summary>
        public string SoldierId { get; set; }

        /// <summary>
        /// 驾驶证有效期
        /// </summary>
        public DateTime ValidDrivingLicense { get; set; }

        /// <summary>
        /// 行驶证号
        /// </summary>
        public string DrivingLicense { get; set; }

        /// <summary>
        /// 驾驶等级Id
        /// </summary>
        public Guid LevelId { get; set; }

        /// <summary>
        /// 驾驶等级
        /// </summary>
        public virtual SysDictionary Level { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}