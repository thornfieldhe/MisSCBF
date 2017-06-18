// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   油料卡查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 油料卡查询对象
    /// </summary>
    public class OilCardQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// CarInfoName
        /// </summary>
        public string CarInfoName
        {
            get; set;
        }
    }
}



