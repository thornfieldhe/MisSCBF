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
                            requiredPermissionName: PermissionNames.Default))
                    .AddItem(
                            new MenuItemDefinition(
                                "menuBaseInfos",
                                L("基础信息"),
                                url: "#baseInfos",
                                requiredPermissionName: PermissionNames.PagesAdmins)))
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
                                requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuAccount",
                                L("会计科目"),
                                url: "#account",
                                requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuBudgetReceipts",
                                L("年初预算收入"),
                                url: "#budgetReceipts",
                                requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuBudgetReceipts2",
                                L("预算调整收入"),
                                url: "#budgetReceipts2",
                                requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuBudgetReceipts3",
                                L("调整后增加收入"),
                                url: "#budgetReceipts3",
                                requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(new MenuItemDefinition(
                            "menuBudgetOutlays",
                            L("年初预算支出"),
                            url: "#budgetOutlays",
                            requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(new MenuItemDefinition(
                            "menuBudgetOutlays2",
                            L("年中调整支出"),
                            url: "#budgetOutlays2",
                            requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(new MenuItemDefinition(
                            "menuBudgetOutlays3",
                            L("预算调整后支出"),
                            url: "#budgetOutlays3",
                            requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(new MenuItemDefinition(
                            "menuBudgetSummary",
                            L("年度预算简表"),
                            url: "#budgetSummary",
                            requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(new MenuItemDefinition(
                            "menuActualOutlays",
                            L("实际支出"),
                            url: "#actualOutlays",
                            requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(new MenuItemDefinition(
                            "menuOutlays",
                            L("支出对比明细"),
                            url: "#outlays",
                            requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(new MenuItemDefinition(
                            "menuReceipts",
                            L("预算收入与实际收入统计"),
                            url: "#receipts",
                            requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(new MenuItemDefinition(
                            "menuBudgetperformance",
                            L("预算编制及预算执行情况"),
                            url: "#budgetperformance",
                            requiredPermissionName: PermissionNames.CwUser))
                        .AddItem(new MenuItemDefinition(
                            "menuVoucherAudits",
                            L("凭证审核归纳表"),
                            url: "#voucherAudits",
                            requiredPermissionName: PermissionNames.CwUser)))
                .AddItem(
                    new MenuItemDefinition(
                        "Storage",
                        L("物资器材管理"),
                        url: "#",
                        icon: "menu-icon fa  fa-tasks",
                        requiredPermissionName: PermissionNames.Default)
                        .AddItem(
                            new MenuItemDefinition(
                                "menuProductInfos",
                                L("基础信息"),
                                url: "#productInfos",
                                requiredPermissionName: PermissionNames.WzUser))
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
                        .AddItem(new MenuItemDefinition(
                            "menuHisStocks",
                            L("物资报表"),
                            url: "#hisStocks",
                            requiredPermissionName: PermissionNames.WzUser))
                        .AddItem(new MenuItemDefinition(
                            "menuHisStocks",
                            L("物资出入库查询"),
                            url: "#queryStocks",
                            requiredPermissionName: PermissionNames.WzUser))
                        .AddItem(new MenuItemDefinition(
                            "menuStockChange",
                            L("物资变动情况查询"),
                            url: "#queryStockChange",
                            requiredPermissionName: PermissionNames.WzUser))
                        .AddItem(new MenuItemDefinition(
                                     "menuStocks",
                                     L("库存清单"),
                                     url: "#stocks",
                                     requiredPermissionName: PermissionNames.WzUser))
                        .AddItem(new MenuItemDefinition(
                                     "menuCheckBills",
                                     L("物资盘点对比表"),
                                     url: "#checkBills",
                                     requiredPermissionName: PermissionNames.WzUser)))
                .AddItem(
                        new MenuItemDefinition(
                    "Purchase",
                    L("采购管理"),
                    url: "#",
                    icon: "menu-icon fa  fa-shopping-cart",
                    requiredPermissionName: PermissionNames.WzUser)
                    .AddItem(
                            new MenuItemDefinition(
                                "menuPurchaseInfos",
                                L("基础信息"),
                                url: "#purchaseInfos",
                                requiredPermissionName: PermissionNames.WzUser)))
                .AddItem(
                    new MenuItemDefinition(
                        "Car",
                        L("车辆管理"),
                        url: "#",
                        icon: "menu-icon fa  fa-truck",
                        requiredPermissionName: PermissionNames.Default)
                        .AddItem(
                            new MenuItemDefinition(
                                "menuCarBaseInfos",
                                L("基础信息"),
                                url: "#carBaseInfos",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuMaintenanceParts",
                                L("维修部位"),
                                url: "#maintenanceParts",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuDrivers",
                                L("驾驶员"),
                                url: "#drivers",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuCarInfos",
                                L("车辆信息"),
                                url: "#carInfos",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuOilCards",
                                L("油料卡资料"),
                                url: "#oilCards",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuRechargeRecords",
                                L("油料卡分配记录"),
                                url: "#rechargeRecords",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuApplicationForBunkerAs",
                                L("油料卡加油申请单"),
                                url: "#applicationForBunkerAs",
                                requiredPermissionName: PermissionNames.Default))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuApplicationForBunkerAs2",
                                L("油料卡加油补签单"),
                                url: "#applicationForBunkerAs2",
                                requiredPermissionName: PermissionNames.Default))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuApplicationForAuditA",
                                L("油料卡加油审批单"),
                                url: "#applicationForAuditA",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuApplicationForConfirmA",
                                L("油料卡加油确认单"),
                                url: "#applicationForConfirmA",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuUploadOilCarRoofRelationships",
                                L("加油卡消耗凭证单"),
                                url: "#uploadOilCarRoofRelationships",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuOctaneStores",
                                L("实物油料库"),
                                url: "#octaneStores",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuOilRecharge",
                                L("实物油料入库审批单"),
                                url: "#oilRecharge",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuApplicationForBunkerBs",
                                L("实物油料加油申请单"),
                                url: "#applicationForBunkerBs",
                                requiredPermissionName: PermissionNames.Default))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuApplicationForBunkerBs2",
                                L("实物油料加油补签单"),
                                url: "#applicationForBunkerBs2",
                                requiredPermissionName: PermissionNames.Default))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuApplicationForAuditB",
                                L("实物油料加油审批单"),
                                url: "#applicationForAuditB",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuCheckApplicationForBunker",
                                L("实物油料加油汇总核对表"),
                                url: "#checkApplicationForBunker",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuApplicationForBunkerBSummaryList",
                                L("实物油料消耗凭证汇总单"),
                                url: "#applicationForBunkerBSummaryList",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuTotalOilHisList",
                                L("季度油料消耗情况报表"),
                                url: "#totalOilHisList",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuCarOils",
                                L("车辆油料核算填报"),
                                url: "#carOils",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuCarOilHisList",
                                L("车辆油料核算报表"),
                                url: "#carOilHisList",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuApplyForVehicleMaintenances",
                                L("车辆送修申请单"),
                                url: "#applyForVehicleMaintenances",
                                requiredPermissionName: PermissionNames.Default))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuAuditingForVehicleMaintenances",
                                L("车辆送修审批单"),
                                url: "#auditingForVehicleMaintenances",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuAuditingForVehicleMaintenances2",
                                L("车辆维修审批单"),
                                url: "#auditingForVehicleMaintenances2",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuClearingForVehicleMaintenances",
                                L("车辆维修结算单"),
                                url: "#clearingForVehicleMaintenances",
                                requiredPermissionName: PermissionNames.ClUser))
                        .AddItem(
                            new MenuItemDefinition(
                                "menuVehicleMaintenanceReport",
                                L("车辆维修情况报告"),
                                url: "#vehicleMaintenanceReport",
                                requiredPermissionName: PermissionNames.ClUser)));
        }

        /// <summary>
        /// The l.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="ILocalizableString"/>.
        /// </returns>
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TAFConsts.LocalizationSourceName);
        }
    }
}