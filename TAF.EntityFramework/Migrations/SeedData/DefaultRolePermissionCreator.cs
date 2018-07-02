// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRolePermissionCreator.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   DefaultRolePermissionCreator
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
    public class DefaultRolePermissionCreator : DefaultCreator
    {

        public DefaultRolePermissionCreator(TAFDbContext context) : base(context)
        {
        }

        public override void Create()
        {
            var hasExcuted = this.Context.Permissions.Any(r => r.Name == PermissionNames.ZbUser && r.TenantId==null);
            if(!hasExcuted)
            {
                //基础
                var defaultUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.Default);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Default,
                        IsGranted = true,
                        RoleId = defaultUser.Id
                    });

                //财务
                var roleCwUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.CwUser);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.CwUser,
                        IsGranted = true,
                        RoleId = roleCwUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Default,
                        IsGranted = true,
                        RoleId = roleCwUser.Id
                    });

                //车辆
                var roleClUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.ClUser);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.ClUser,
                        IsGranted = true,
                        RoleId = roleClUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Default,
                        IsGranted = true,
                        RoleId = roleClUser.Id
                    });

                //餐厅
                var roleCtUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.CtUser);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.CtUser,
                        IsGranted = true,
                        RoleId = roleCtUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Default,
                        IsGranted = true,
                        RoleId = roleCtUser.Id
                    });

                //工程
                var roleGcUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.GcUser);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.GcUser,
                        IsGranted = true,
                        RoleId = roleGcUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Default,
                        IsGranted = true,
                        RoleId = roleGcUser.Id
                    });

                //装备
                var roleZbUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.ZbUser);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.ZbUser,
                        IsGranted = true,
                        RoleId = roleZbUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Default,
                        IsGranted = true,
                        RoleId = roleZbUser.Id
                    });

                //物资
                var roleWzUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.WzUser);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.WzUser,
                        IsGranted = true,
                        RoleId = roleWzUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Default,
                        IsGranted = true,
                        RoleId = roleWzUser.Id
                    });

                //采购
                var roleCgUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.CgUser);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.CgUser,
                        IsGranted = true,
                        RoleId = roleCgUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Default,
                        IsGranted = true,
                        RoleId = roleCgUser.Id
                    });

                //系统管理员

                var adminUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.Admin);

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.Default,
                        IsGranted = true,
                        RoleId = adminUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.PagesAdmins,
                        IsGranted = true,
                        RoleId = adminUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.CwUser,
                        IsGranted = true,
                        RoleId = adminUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.ClUser,
                        IsGranted = true,
                        RoleId = adminUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.CtUser,
                        IsGranted = true,
                        RoleId = adminUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.GcUser,
                        IsGranted = true,
                        RoleId = adminUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.WzUser,
                        IsGranted = true,
                        RoleId = adminUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name = PermissionNames.CgUser,
                        IsGranted = true,
                        RoleId = adminUser.Id
                    });

                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        Name      = PermissionNames.ZbUser,
                        IsGranted = true,
                        RoleId    = roleZbUser.Id
                    });

                this.Context.SaveChanges();
            }
        }
    }
}