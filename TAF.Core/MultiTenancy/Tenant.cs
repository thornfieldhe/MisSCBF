using Abp.MultiTenancy;

namespace SCBF.MultiTenancy
{
    using SCBF.Users;

    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {

        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}