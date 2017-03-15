namespace SCBF.Web
{
    using Abp.Application.Navigation;
    using Abp.Localization;

    using SCBF.Authorization;

    /// <summary>
    ///     This class defines menus for the application.
    ///     It uses ABP's menu system.
    ///     When you add menu items here, they are automatically appear in angular application.
    ///     See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class TAFNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu.AddItem(
                new MenuItemDefinition(
                    "UserManager",
                    L("系统管理"),
                    url: "#",
                    icon: "menu-icon fa fa-user",
                    requiredPermissionName: PermissionNames.Pages).AddItem(
                        new MenuItemDefinition(
                            "menuUsers",
                            L("用户管理"),
                            url: "#userList",
                            requiredPermissionName: PermissionNames.PagesAdmins))
                    .AddItem(
                        new MenuItemDefinition(
                            "menuChangePass",
                            L("修改密码"),
                            url: "#changePwd",
                            requiredPermissionName: PermissionNames.Pages)))
                .AddItem(
                    new MenuItemDefinition(
                        "Storage",
                        L("仓库管理"),
                        url: "#",
                        icon: "menu-icon fa  fa-calendar",
                        requiredPermissionName: PermissionNames.Pages)
                        .AddItem(
                            new MenuItemDefinition(
                                "menuBaseInfos",
                                L("基础信息"),
                                url: "#storageInfos",
                                requiredPermissionName: PermissionNames.PagesAdmins))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuProductCategories",
                                L("商品分类"),
                                url: "#productCategories",
                                requiredPermissionName: PermissionNames.PagesAdmins))
                        .AddItem(new MenuItemDefinition(
                            "menuProducts",
                            L("商品管理"),
                            url: "#products",
                            requiredPermissionName: PermissionNames.Pages))
                       );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TAFConsts.LocalizationSourceName);
        }
    }
}