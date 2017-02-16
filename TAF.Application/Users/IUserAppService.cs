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

    public interface IUserAppService : IBaseEntityApplicationService<UserListDto, UserEditDto, UserQueryDto, long>
    {
        Task<ListResultDto<UserListDto>> GetAllAsync(UserQueryDto request);

        void ChangePwd(PwdEditDto input);
    }
}