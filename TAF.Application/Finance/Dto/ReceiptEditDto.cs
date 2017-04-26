// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReceiptEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   预算编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;

    /// <summary>
    /// 预算编辑对象
    /// </summary>
    [AutoMap(typeof(Receipt))]
    public class ReceiptEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }
    }
}



