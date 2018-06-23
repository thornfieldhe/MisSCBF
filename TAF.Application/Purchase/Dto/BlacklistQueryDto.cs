// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlacklistQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   会质量评价体系查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 会质量评价体系查询对象
    /// </summary>
    public class BlacklistQueryDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name
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
    }
}



