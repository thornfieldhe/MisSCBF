// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CostListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   造价清单管理列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 造价清单管理列表对象
    /// </summary>
    [AutoMap(typeof(CostList))]
    public class CostListDto
    {
        public Guid? Id { get; set; }

        public Guid BiddingManagementId { get; set; }

        public string Category { get; set; }

        public string Details { get; set; }

        public string Unit { get; set; }

        public decimal Amount { get; set; }

        public bool EditStatus { get; set; }
    }
}



