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
                    requiredPermissionName: PermissionNames.Default).AddItem(
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
                            requiredPermissionName: PermissionNames.Default)))
                            .AddItem(
                    new MenuItemDefinition(
                        "Storage",
                        L("预算管理"),
                        url: "#",
                        icon: "menu-icon fa  fa-rmb",
                        requiredPermissionName: PermissionNames.Default)
                        .AddItem(
                            new MenuItemDefinition(
                                "menuFinanceInfos",
                                L("基础信息"),
                                url: "#financeInfos",
                                requiredPermissionName: PermissionNames.PagesAdmins))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuAccount",
                                L("会计科目"),
                                url: "#account",
                                requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuBudgetReceipts", 
                                L("年度预算收入"), 
                                url: "#budgetReceipts", 
                                requiredPermissionName: PermissionNames.CwUser))
                       )
                .AddItem(
                    new MenuItemDefinition(
                        "Storage",
                        L("物资器材管理"),
                        url: "#",
                        icon: "menu-icon fa  fa-truck",
                        requiredPermissionName: PermissionNames.Default)
                        .AddItem(
                            new MenuItemDefinition(
                                "menuStorageInfos",
                                L("基础信息"),
                                url: "#storageInfos",
                                requiredPermissionName: PermissionNames.PagesAdmins))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuProductCategories",
                                L("商品分类"),
                                url: "#productCategories",
                                requiredPermissionName: PermissionNames.WzUser))
                        .AddItem(new MenuItemDefinition(
                            "menuProducts",
                            L("商品管理"),
                            url: "#products",
                            requiredPermissionName: PermissionNames.WzUser))
                        .AddItem(new MenuItemDefinition(
                            "menuEntryBills",
                            L("入库管理"),
                            url: "#entryBills",
                            requiredPermissionName: PermissionNames.WzUser))
                        .AddItem(new MenuItemDefinition(
                            "menuDeliveryBills",
                            L("出库管理"),
                            url: "#deliveryBills",
                            requiredPermissionName: PermissionNames.WzUser))
                       );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TAFConsts.LocalizationSourceName);
        }
    }
}