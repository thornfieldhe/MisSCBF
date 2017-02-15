using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Microsoft.AspNet.Identity;

namespace SCBF
{
    using SCBF.MultiTenancy;
    using SCBF.Users;

    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class TAFAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager
        {
            get; set;
        }

        public UserManager UserManager
        {
            get; set;
        }

        protected TAFAppServiceBase()
        {
            LocalizationSourceName = TAFConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}