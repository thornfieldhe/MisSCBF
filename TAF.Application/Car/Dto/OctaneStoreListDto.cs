// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctaneStoreListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料库列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 实物油料库列表对象
    /// </summary>
    [AutoMap(typeof(OctaneStore))]
    public class OctaneStoreListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// StoreName
        /// </summary>
        public string StoreName
        {
            get; set;
        }

        /// <summary>
        /// OctaneRatingName
        /// </summary>
        public string OctaneRatingName
        {
            get; set;
        }

        /// <summary>
        /// 库存量
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name => $"{StoreName}-{OctaneRatingName}";
    }
}



