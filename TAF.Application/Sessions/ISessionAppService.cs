using System.Threading.Tasks;
using Abp.Application.Services;

namespace SCBF.Sessions
{
    using SCBF.Sessions.Dto;

    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
