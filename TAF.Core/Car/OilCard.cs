// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCard.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   OilCard
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 油料卡
    /// </summary>
    public class OilCard : TAFEntity
    {
        public string Code { get; set; }

        public decimal Amount { get; set; }

        public Guid CarInfoId { get; set; }

        public virtual CarInfo CarInfo { get; set; }

        public virtual List<RechargeRecord> RechargeRecords { get; set; }

        public virtual List<ApplicationForBunkerA> ApplicationForBunkerAs { get; set; }
    }
}