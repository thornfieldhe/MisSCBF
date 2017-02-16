namespace SCBF.Migrations.SeedData
{
    using System.Linq;

    using Abp.Authorization;
    using Abp.Authorization.Roles;
    using Abp.Authorization.Users;
    using Abp.MultiTenancy;

    using Microsoft.AspNet.Identity;

    using SCBF.Authorization;
    using SCBF.Authorization.Roles;
    using SCBF.EntityFramework;
    using SCBF.Users;

    public class HostRoleAndUserCreator : DefaultCreator
    {
        public HostRoleAndUserCreator(TAFDbContext context)
            : base(context)
        {
        }

        public override void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            // Admin role for host
            var adminRoleForHost =
                Context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.Admin,
                            DisplayName = StaticRoleNames.Host.AdminName,
                            IsStatic = true
                        });

                Context.SaveChanges();

                // Grant all tenant permissions
                var permissions =
                    PermissionFinder.GetAllPermissions(new TAFAuthorizationProvider())
                        .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host))
                        .ToList();

                foreach (var permission in permissions)
                {
                    Context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRoleForHost.Id
                        });
                }

                Context.SaveChanges();
            }

            // Admin user for tenancy host
            var adminUserForHost =
                Context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == User.AdminUserName);
            if (adminUserForHost == null)
            {
                adminUserForHost =
                    Context.Users.Add(
                        new User
                        {
                            UserName = User.AdminUserName,
                            Name = "系统管理员",
                            Surname = "Administrator",
                            EmailAddress = "admin@aspnetboilerplate.com",
                            IsEmailConfirmed = true,
                            Password = new PasswordHasher().HashPassword(User.DefaultPassword)
                        });

                Context.SaveChanges();

                Context.UserRoles.Add(new UserRole(null, adminUserForHost.Id, adminRoleForHost.Id));

                Context.SaveChanges();
            }
        }
    }
}