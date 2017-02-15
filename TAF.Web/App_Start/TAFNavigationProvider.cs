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
                        "BaseInfo",
                        L("工作管理"),
                        url: "#",
                        icon: "menu-icon fa  fa-calendar",
                        requiredPermissionName: PermissionNames.Pages).AddItem(
                            new MenuItemDefinition(
                                "menuProjects",
                                L("项目管理"),
                                url: "#projects",
                                requiredPermissionName: PermissionNames.PagesProjectManager))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuProjectTasks",
                                L("任务管理"),
                                url: "#projectTasks",
                                requiredPermissionName: PermissionNames.PagesProjectManager))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuDailyLogs ",
                                L("工作日志"),
                                url: "#dailylogs",
                                requiredPermissionName: PermissionNames.Pages))
                                .AddItem(
                            new MenuItemDefinition(
                                "menuShowDailyLogs ",
                                L("工作日志查询"),
                                url: "#showDdailylogs",
                                requiredPermissionName: PermissionNames.PagesProjectManager))
                                .AddItem(
                                new MenuItemDefinition(
                                "menuProjectStatistic ",
                                L("项目统计"),
                                url: "#projectStatistic",
                                requiredPermissionName: PermissionNames.PagesProjectManager)));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TAFConsts.LocalizationSourceName);
        }
    }
}