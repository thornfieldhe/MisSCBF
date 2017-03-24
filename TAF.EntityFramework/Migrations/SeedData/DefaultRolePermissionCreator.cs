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
            var hasExcuted = this.Context.Permissions.Any(r => r.Name == PermissionNames.CgUser + "_Admin");
            if (!hasExcuted)
            {

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

                        Name = $"{PermissionNames.CwUser}_Pages",
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

                        Name = $"{PermissionNames.Pages}_Pages",
                        IsGranted = true,
                        RoleId = roleCwUser.Id
                    });

                //油料
                var roleYlUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.YlUser);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = PermissionNames.YlUser,
                        IsGranted = true,
                        RoleId = roleYlUser.Id
                    });
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.YlUser}_Pages",
                        IsGranted = true,
                        RoleId = roleCwUser.Id
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

                        Name = $"{PermissionNames.CtUser}_Pages",
                        IsGranted = true,
                        RoleId = roleCwUser.Id
                    });

                //营房
                var roleYfUser = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.YfUser);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = PermissionNames.YfUser,
                        IsGranted = true,
                        RoleId = roleYfUser.Id
                    });
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.YfUser}_Pages",
                        IsGranted = true,
                        RoleId = roleCwUser.Id
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

                        Name = $"{PermissionNames.WzUser}_Pages",
                        IsGranted = true,
                        RoleId = roleCwUser.Id
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

                        Name = $"{PermissionNames.CgUser}_Pages",
                        IsGranted = true,
                        RoleId = roleCwUser.Id
                    });

                //系统管理员
                var roleAdmin = this.Context.Roles.First(r => r.Name == StaticRoleNames.Host.Admin);
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.Pages}_Admin",
                        IsGranted = true,
                        RoleId = roleAdmin.Id
                    });
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.CwUser}_Admin",
                        IsGranted = true,
                        RoleId = roleAdmin.Id
                    });
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.ClUser}_Admin",
                        IsGranted = true,
                        RoleId = roleAdmin.Id
                    });
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.YlUser}_Admin",
                        IsGranted = true,
                        RoleId = roleAdmin.Id
                    });
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.CtUser}_Admin",
                        IsGranted = true,
                        RoleId = roleAdmin.Id
                    });
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.YfUser}_Admin",
                        IsGranted = true,
                        RoleId = roleAdmin.Id
                    });
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.WzUser}_Admin",
                        IsGranted = true,
                        RoleId = roleAdmin.Id
                    });
                this.Context.Permissions.Add(
                    new RolePermissionSetting
                    {

                        Name = $"{PermissionNames.CgUser}_Admin",
                        IsGranted = true,
                        RoleId = roleAdmin.Id
                    });

                Context.SaveChanges();
            }
        }
    }
}