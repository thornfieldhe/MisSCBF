// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserAppService.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IUserAppService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Users
{
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;

    using SCBF.Users.Dto;

    public interface IUserAppService : IBaseEntityApplicationService
    {
        ListResultDto<UserListDto> GetAll(UserQueryDto request);

        UserEditDto Get(long id);

        Task SaveAsync(UserEditDto input);

        void Delete(long id);

        Task<ListResultDto<UserListDto>> GetAllAsync(UserQueryDto request);

        void ChangePwd(PwdEditDto input);
    }
}