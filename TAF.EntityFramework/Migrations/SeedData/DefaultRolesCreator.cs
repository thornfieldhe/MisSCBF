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
            var cwUser = Context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.CwUser);
            if (cwUser == null)
            {
                cwUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.CwUser,
                            DisplayName = StaticRoleNames.Host.CwUserName,
                            IsStatic = true
                        });

                var clUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.ClUser,
                            DisplayName = StaticRoleNames.Host.ClUserName,
                            IsStatic = true
                        });

                var ylUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.YlUser,
                            DisplayName = StaticRoleNames.Host.YlUserName,
                            IsStatic = true
                        });

                var ctUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.CtUser,
                            DisplayName = StaticRoleNames.Host.CtUserName,
                            IsStatic = true
                        });

                var wzUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.WzUser,
                            DisplayName = StaticRoleNames.Host.WzUserName,
                            IsStatic = true
                        });

                var yfUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.YfUser,
                            DisplayName = StaticRoleNames.Host.YfUserName,
                            IsStatic = true
                        });

                var cgUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.CgUser,
                            DisplayName = StaticRoleNames.Host.CgUserName,
                            IsStatic = true
                        });

                Context.SaveChanges();
            }
        }
    }
}