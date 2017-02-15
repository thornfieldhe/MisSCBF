using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace SCBF.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserListDto : EntityDto<long>
    {
        public string UserName
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Roles
        {
            get; set;
        }
    }
}