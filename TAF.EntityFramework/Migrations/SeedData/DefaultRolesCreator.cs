// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRolesCreator.cs" company="" author="何翔华">
// </copyright>
// <summary>
//   DefaultRolesCreator
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SCBF.Migrations.SeedData
{
    using System.Linq;

    using Abp.Authorization.Roles;

    using SCBF.Authorization;
    using SCBF.Authorization.Roles;
    using SCBF.EntityFramework;

    /// <summary>
    /// </summary>
    public class DefaultRolesCreator : DefaultCreator
    {
        public DefaultRolesCreator(TAFDbContext context)
            : base(context)
        {
        }

        public override void Create()
        {
            CreateDefaultRoles();
        }

        private void CreateDefaultRoles()
        {
            var projectManager = Context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.ProjectManager);
            if (projectManager == null)
            {
                projectManager = Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.ProjectManager,
                            DisplayName = StaticRoleNames.Host.ProjectManagerName,
                            IsStatic = true
                        });

                var user = Context.Roles.Add(
                 new Role
                 {
                     Name = StaticRoleNames.Host.User,
                     DisplayName = StaticRoleNames.Host.UserName,
                     IsStatic = true
                 });

                Context.SaveChanges();

                this.Context.Permissions.Add(
                                            new RolePermissionSetting
                                            {
                                                Name = PermissionNames.Pages,
                                                IsGranted = true,
                                                RoleId = projectManager.Id
                                            });

                this.Context.Permissions.Add(
                            new RolePermissionSetting
                            {
                                Name = PermissionNames.PagesProjectManager,
                                IsGranted = true,
                                RoleId = projectManager.Id
                            });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Pages,
                        IsGranted = true,
                        RoleId = user.Id
                    });

                //                cwUser =
                //                    Context.Roles.Add(
                //                        new Role
                //                        {
                //                            Name = StaticRoleNames.Host.CwUser,
                //                            DisplayName = StaticRoleNames.Host.CwUserName,
                //                            IsStatic = true
                //                        });
                //
                //                var clUser =
                //                    Context.Roles.Add(
                //                        new Role
                //                        {
                //                            Name = StaticRoleNames.Host.ClUser,
                //                            DisplayName = StaticRoleNames.Host.ClUserName,
                //                            IsStatic = true
                //                        });
                //
                //                var ylUser =
                //                    Context.Roles.Add(
                //                        new Role
                //                        {
                //                            Name = StaticRoleNames.Host.YlUser,
                //                            DisplayName = StaticRoleNames.Host.YlUserName,
                //                            IsStatic = true
                //                        });
                //
                //                var ctUser =
                //                    Context.Roles.Add(
                //                        new Role
                //                        {
                //                            Name = StaticRoleNames.Host.CtUser,
                //                            DisplayName = StaticRoleNames.Host.CtUserName,
                //                            IsStatic = true
                //                        });
                //
                //                var wzUser =
                //                    Context.Roles.Add(
                //                        new Role
                //                        {
                //                            Name = StaticRoleNames.Host.WzUser,
                //                            DisplayName = StaticRoleNames.Host.WzUserName,
                //                            IsStatic = true
                //                        });
                //
                //                var yfUser =
                //                    Context.Roles.Add(
                //                        new Role
                //                        {
                //                            Name = StaticRoleNames.Host.YfUser,
                //                            DisplayName = StaticRoleNames.Host.YfUserName,
                //                            IsStatic = true
                //                        });
                //
                //                var cgUser =
                //                    Context.Roles.Add(
                //                        new Role
                //                        {
                //                            Name = StaticRoleNames.Host.CgUser,
                //                            DisplayName = StaticRoleNames.Host.CgUserName,
                //                            IsStatic = true
                //                        });

                Context.SaveChanges();
            }
        }
    }
}