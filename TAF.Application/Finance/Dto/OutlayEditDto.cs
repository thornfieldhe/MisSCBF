// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetOutlayListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   支出预算列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SCBF.Finance.Dto
{
	/// <summary>
    /// 支出编辑对象
    /// </summary>
    public class OutlayEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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

        /// <summary>
        /// 支出预算列表
        /// </summary>
        public List<Guid> OutlayIds
        {
            get; set;
        }
    }
}



