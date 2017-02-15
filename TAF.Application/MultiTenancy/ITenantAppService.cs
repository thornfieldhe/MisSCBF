using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace SCBF.MultiTenancy
{
    using SCBF.MultiTenancy.Dto;

    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
