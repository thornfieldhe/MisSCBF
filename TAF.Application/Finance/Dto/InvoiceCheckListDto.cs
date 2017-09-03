// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceCheckListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   发票录入列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 发票录入列表对象
    /// </summary>
    [AutoMap(typeof(InvoiceCheck))]
    public class InvoiceCheckListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// From
        /// </summary>
        public long From
        {
            get; set;
        }

        /// <summary>
        /// To
        /// </summary>
        public long To
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
    }
}



