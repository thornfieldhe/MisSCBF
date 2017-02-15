using Abp.Authorization;

namespace SCBF.Authorization
{
    using SCBF.Authorization.Roles;
    using SCBF.MultiTenancy;
    using SCBF.Users;

    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
