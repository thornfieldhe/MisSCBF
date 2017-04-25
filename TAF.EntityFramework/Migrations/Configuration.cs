using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using EntityFramework.DynamicFilters;

namespace SCBF.Migrations
{
    using SCBF.EntityFramework;
    using SCBF.Migrations.SeedData;

    public sealed class Configuration : DbMigrationsConfiguration<TAFDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant
        {
            get; set;
        }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SCBF";
        }

        protected override void Seed(TAFDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                //                new DefaultTenantCreator(context).Create();
                //                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }

    }
}
