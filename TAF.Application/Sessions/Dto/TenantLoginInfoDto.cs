using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace SCBF.Sessions.Dto
{
    using SCBF.MultiTenancy;

    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
    }
}