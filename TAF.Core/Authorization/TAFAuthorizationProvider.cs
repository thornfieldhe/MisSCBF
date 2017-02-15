using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace SCBF.Authorization
{
    public class TAFAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions



            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("普通用户"));
            }

            var users = pages.CreateChildPermission(PermissionNames.PagesProjectManager, L("项目经理"));

            //Host permissions
            var admins = pages.CreateChildPermission(PermissionNames.PagesAdmins, L("系统管理员"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TAFConsts.LocalizationSourceName);
        }
    }
}
