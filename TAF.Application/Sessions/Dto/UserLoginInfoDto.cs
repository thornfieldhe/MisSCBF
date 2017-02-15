using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace SCBF.Sessions.Dto
{
    using SCBF.Users;

    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name
        {
            get; set;
        }

        public string Surname
        {
            get; set;
        }

        public string UserName
        {
            get; set;
        }

        public string EmailAddress
        {
            get; set;
        }
    }
}
