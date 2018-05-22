// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualOutlayListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实际支出列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 实际支出列表对象
    /// </summary>
    [AutoMap(typeof(ActualOutlay))]
    public class ActualOutlayListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// VoucherNo
        /// </summary>
        public string VoucherNo
        {
            get; set;
        }

        /// <summary>
        /// Date
        /// </summary>
        public string Date
        {
            get; set;
        }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }
    }
}



