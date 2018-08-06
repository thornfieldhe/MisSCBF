// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OutlayEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   财务编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Abp.AutoMapper;

namespace SCBF.Finance.Dto
{
	/// <summary>
    /// 财务编辑对象
    /// </summary>
    [AutoMap(typeof(Outlay))]
    public class OutlaySummaryEditDto
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
        /// Year
        /// </summary>
        public int Year
        {
            get; set;
        }

        /// <summary>
        /// Total1
        /// </summary>
        public decimal Total1
        {
            get; set;
        }

        /// <summary>
        /// Total2
        /// </summary>
        public decimal Total2
        {
            get; set;
        }

        /// <summary>
        /// Total3
        /// </summary>
        public decimal Total3
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

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }
    }
}



