// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryBillQueryDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.Application.Services.Dto;

namespace SCBF.Storage.Dto
{
    /// <summary>
    /// Summary
    /// </summary>
    public class DeliveryBillQueryDto : PagedAndSortedResultRequestDto
    {
        public string Code { get; set; }

    }
}