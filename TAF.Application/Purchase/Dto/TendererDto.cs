// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TendererDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   投标人管理编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 投标人管理编辑对象
    /// </summary>
    [AutoMap(typeof(Tenderer))]
    public class TendererDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// BiddingManagementId
        /// </summary>
        public Guid BiddingManagementId
        {
            get; set;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// EditStatus
        /// </summary>
        public bool EditStatus
        {
            get; set;
        }
    }
}



