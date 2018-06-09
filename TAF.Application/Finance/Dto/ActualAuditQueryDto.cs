// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoucherAuditQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实际支出查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace SCBF.Finance.Dto
{

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 实际支出查询对象
    /// </summary>
    public class ActualAuditQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// Text
        /// </summary>
        public string Text
        {
            get; set;
        }

        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get; set;
        }

        /// <summary>
        /// 关联对象Id
        /// </summary>
        public Guid? PrincipalKey
        {
            get; set;
        }
    }
}



