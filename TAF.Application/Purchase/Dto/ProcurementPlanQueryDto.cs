// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlanQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 采购计划查询对象
    /// </summary>
    public class ProcurementPlanQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// Mode
        /// </summary>
        public string Mode
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
        /// Name
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Year
        /// </summary>
        public int? Year
        {
            get; set;
        }

        /// <summary>
        /// Month
        /// </summary>
        public int? Month
        {
            get; set;
        }
    }
}



