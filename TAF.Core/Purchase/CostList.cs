using System;

namespace SCBF.Purchase
{
    /// <summary>
    /// 造价清单
    /// </summary>
    public class CostList: TAFEntity
    {
        public Guid BiddingManagementId { get; set; }

        public string Category { get; set; }

        public string Details { get; set; }

        public string Unit { get; set; }

        public decimal Amount { get; set; }

    }
}