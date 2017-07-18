// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCarRoofRelationship.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   OilCarRoofRelationship
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;

    /// <summary>
    /// 加油凭证与申请关联表
    /// </summary>
    public class UploadOilCarRoofRelationship : TAFEntity
    {
        /// <summary>
        /// 凭证对象Id
        /// </summary>
        public Guid RId { get; set; }

        /// <summary>
        /// 审核Id
        /// </summary>
        public Guid OId { get; set; }

        /// <summary>
        /// 加油月份
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}