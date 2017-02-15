using System.Threading.Tasks;
using Abp.Application.Services;

namespace SCBF.Roles
{
    using SCBF.Roles.Dto;

    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
