namespace SCBF.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Authorization.Users;
    using Abp.AutoMapper;
    using Abp.Collections.Extensions;
    using Abp.Domain.Repositories;
    using Abp.UI;

    using Microsoft.AspNet.Identity;

    using SCBF.Authorization;
    using SCBF.Authorization.Roles;
    using SCBF.Users.Dto;

    using QueryableExtensions = Abp.Linq.Extensions.QueryableExtensions;

    /* THIS IS JUST A SAMPLE. */
    [AbpAuthorize(PermissionNames.Pages)]
    public class UserAppService : TAFAppServiceBase, IUserAppService
    {
        private readonly IPermissionManager _permissionManager;

        private readonly RoleManager _roleManager;

        private readonly IRepository<User, long> _userRepository;

        public UserAppService(
            IRepository<User, long> userRepository,
            RoleManager roleManager,
            IPermissionManager permissionManager)
        {
            _userRepository = userRepository;
            _permissionManager = permissionManager;
            _roleManager = roleManager;
        }


        [AbpAuthorize(PermissionNames.PagesAdmins)]
        public async Task<ListResultDto<UserListDto>> GetAllAsync(UserQueryDto request)
        {
            var query =
                _userRepository.GetAll()
                    .WhereIf(!string.IsNullOrWhiteSpace(request.UserName), r => r.UserName.Contains(request.UserName))
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Name), r => r.Name.Contains(request.Name))
                    .WhereIf(request.RoleId != 0, r => r.Roles.Any(m => m.RoleId == request.RoleId));

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Name);
            var count = query.Count();
            var list = QueryableExtensions.PageBy(query.AsQueryable(), request).ToList();

            var userDtos = list.MapTo<List<UserListDto>>();
            foreach (var item in userDtos)
            {
                var roles = await this.UserManager.GetRolesAsync(item.Id);
                var roleNames = this._roleManager.Roles.Where(r => roles.Contains(r.Name)).Select(r => r.DisplayName);
                item.Roles = string.Join(",", roleNames.ToArray());
            }

            return new PagedResultDto<UserListDto>(count, userDtos);
        }

        public ListResultDto<UserListDto> GetAll(UserQueryDto request)
        {
            throw new System.NotImplementedException();
        }


        [AbpAuthorize(PermissionNames.PagesAdmins)]
        public UserEditDto Get(long id)
        {
            var user = this._userRepository.Get(id);
            var output = user.MapTo<UserEditDto>();
            var roles = this._roleManager.Roles;
            var userRoles = user.Roles.Select(r => r.RoleId).ToList();
            output.Roles = roles.Where(r => userRoles.Contains(r.Id)).Select(r => r.Name).ToList();
            return output;
        }

        [AbpAuthorize(PermissionNames.PagesAdmins)]
        public void Delete(long id)
        {
            _userRepository.Delete(id);
        }

        [AbpAuthorize(PermissionNames.PagesAdmins)]
        public async Task SaveAsync(UserEditDto input)
        {
            var user = await UserManager.FindByNameAsync(input.UserName);
            if (user == null)
            {
                user = input.MapTo<User>();
                user.TenantId = AbpSession.TenantId;
                user = _userRepository.Insert(user);
                input.Id = this._userRepository.InsertAndGetId(user);
            }
            else if (input.Id == 0)
            {
                throw new UserFriendlyException("用户已存在！");
            }

            user.Name = input.Name;
            await _userRepository.UpdateAsync(user);
            var roles = this._roleManager.Roles;
            var newRoles = roles.Where(r => input.Roles.Contains(r.Name)).ToList();
            if (user.Roles != null)
            {
                foreach (var newRole in newRoles)
                {
                    if (user.Roles.All(r => r.RoleId != newRole.Id))
                    {
                        await UserManager.AddToRoleAsync(user.Id, newRole.Name);
                    }
                }

                foreach (var oldRoleId in user.Roles.Select(r => r.RoleId).ToList())
                {
                    if (newRoles.All(r => r.Id != oldRoleId))
                    {
                        var oldRole = roles.Single(r => r.Id == oldRoleId);
                        await UserManager.RemoveFromRoleAsync(user.Id, oldRole.Name);
                    }
                }
            }
            else
            {
                user.Roles = new List<UserRole>();
                foreach (var role in input.Roles)
                {
                    await UserManager.AddToRoleAsync(user.Id, role);
                }
            }
        }

        public void ChangePwd(PwdEditDto input)
        {
            CheckErrors(this.UserManager.ChangePassword(input.UserId, input.OldPwd, input.NewPwd));
        }
    }
}