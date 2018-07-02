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

        public DefaultRolesCreator(TAFDbContext context) : base(context)
        {

        }

        public override void Create()
        {
            CreateDefaultRoles();
        }

        private void CreateDefaultRoles()
        {
            var defaultUser = Context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Default);
            if (defaultUser == null)
            {
               defaultUser =
                Context.Roles.Add(
                    new Role
                    {
                        Name = StaticRoleNames.Host.Default,
                        DisplayName = StaticRoleNames.Host.DefaultName,
                        IsStatic = true
                    });

                var cwUser =
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

                var gcUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.GcUser,
                            DisplayName = StaticRoleNames.Host.GcUserName,
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

                var adminUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name = StaticRoleNames.Host.Admin,
                            DisplayName = StaticRoleNames.Host.AdminName,
                            IsStatic = true
                        });

                var zbUser =
                    Context.Roles.Add(
                        new Role
                        {
                            Name        = StaticRoleNames.Host.ZbUser,
                            DisplayName = StaticRoleNames.Host.ZbUserName,
                            IsStatic    = true
                        });


                Context.SaveChanges();
            }
        }
    }
}