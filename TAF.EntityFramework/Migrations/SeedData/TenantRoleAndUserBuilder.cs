using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;

namespace SCBF.Migrations.SeedData
{
    using SCBF.Authorization;
    using SCBF.Authorization.Roles;
    using SCBF.EntityFramework;
    using SCBF.Users;

    public class TenantRoleAndUserBuilder : DefaultCreator
    {
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(TAFDbContext context, int tenantId) : base(context)
        {
            _tenantId = tenantId;
        }

        public override void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            //Admin role

            var adminRole = Context.Roles.FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Host.Admin);
            if (adminRole == null)
            {
                //系统管理员
                adminRole = Context.Roles.Add(new Role(_tenantId, StaticRoleNames.Host.Admin, StaticRoleNames.Host.Admin) { IsStatic = true });
                Context.SaveChanges();

                //Grant all permissions to admin role
                var permissions = PermissionFinder
                    .GetAllPermissions(new TAFAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant))
                    .ToList();

                foreach (var permission in permissions)
                {
                    Context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            TenantId = null,
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRole.Id
                        });
                }

                Context.SaveChanges();
            }

            //admin user

            var adminUser = Context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == User.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com", "123qwe");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;
                adminUser.Name = StaticRoleNames.Host.AdminName;
                Context.Users.Add(adminUser);
                Context.SaveChanges();

                //Assign Admin role to admin user
                Context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                Context.SaveChanges();
            }
        }
    }
}