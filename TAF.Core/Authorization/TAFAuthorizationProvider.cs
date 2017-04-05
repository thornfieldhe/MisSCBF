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



            var admins = context.GetPermissionOrNull(PermissionNames.PagesAdmins);
            if (admins == null)
            {
                admins = context.CreatePermission(PermissionNames.PagesAdmins, L("系统管理员"));
                var wz = context.CreatePermission(PermissionNames.WzUser, L("物资管理"));
                var cw = context.CreatePermission(PermissionNames.CwUser, L("预算管理"));
                var user = context.CreatePermission(PermissionNames.Default, L("普通用户"));
            }




        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TAFConsts.LocalizationSourceName);
        }
    }
}
