// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoucherAuditQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   凭证审核归纳表查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.Application.Services.Dto;

namespace SCBF.Finance.Dto
{
	/// <summary>
    /// 凭证审核归纳表查询对象
    /// </summary>
    public class VoucherAuditQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }
    }
}



