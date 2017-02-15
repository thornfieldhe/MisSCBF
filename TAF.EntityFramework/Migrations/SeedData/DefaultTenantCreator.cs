namespace SCBF.Migrations.SeedData
{
    using System.Linq;

    using SCBF.EntityFramework;
    using SCBF.MultiTenancy;

    public class DefaultTenantCreator : DefaultCreator
    {
        public DefaultTenantCreator(TAFDbContext context)
            : base(context)
        {
        }

        public override void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            // Default tenant
            var defaultTenant = Context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                Context.Tenants.Add(
                    new Tenant { TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName });
                Context.SaveChanges();
            }
        }
    }
}