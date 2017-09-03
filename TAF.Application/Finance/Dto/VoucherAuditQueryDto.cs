// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoucherAuditQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   凭证审核归纳表查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance.Dto
{

    using Abp.Application.Services.Dto;

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



