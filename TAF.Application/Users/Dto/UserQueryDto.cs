// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserQueryDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   UserQueryDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Users.Dto
{
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 用户查询Dto
    /// </summary>
    public class UserQueryDto : PagedAndSortedResultRequestDto
    {
        public string UserName
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public int RoleId
        {
            get; set;
        }
    }
}