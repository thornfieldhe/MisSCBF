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

    /// <summary>
    /// 油料卡充值记录
    /// </summary>
    public class RechargeRecord : TAFEntity
    {
        public Guid OilCardId { get; set; }

        public virtual OilCard OilCard { get; set; }

        public decimal Amount { get; set; }

        public decimal HisAmount { get; set; }

        public DateTime Date { get; set; }

    }
}