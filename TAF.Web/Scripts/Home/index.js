
function loadPage(url, parentTitle, title, document, isHomePage) {
    $.get(url, function (data) {
        $(".page-body").html(data);
        if (!isHomePage) {
            $(".breadcrumb").html("<li><i class='fa fa-home'></i><a href='#index' >主页</a></li><li >" + parentTitle + "</li><li >" + title + "</li>");
        } else {
            $(".breadcrumb").html("<li><i class='fa fa-home'></i><a href='#index' >主页</a></li>");
        }
        $("#bodyTitle").html(parentTitle);
    });
}

var menu = new Vue({
    el: "#menu",
    data: {
        list: abp.nav.menus.MainMenu.items
    },
    ready: function () {
        InitiateSideMenu();
    }
});

var defaultUrl = "/";

Path.map("#userList").to(function () { loadPage("/Account/UserList", "系统管理", "用户管理", "#menuUsers", false); });
Path.map("#changePwd").to(function () { loadPage("/Account/ChangePwd", "系统管理", "修改密码", "#menuChangePass", false); });
Path.map("#baseInfos").to(function () { loadPage("/SysDictionary/SysDictionaryList", "系统管理", "基础信息", "#menuBaseInfos", false); });

Path.map("#financeInfos").to(function () { loadPage("/Finance/InfoList", "预算管理", "基础信息", "#menuFinanceInfos", false); });
Path.map("#account").to(function () { loadPage("/Finance/AccountList", "预算管理", "会计科目", "#menuAccount", false); });
Path.map("#budgetReceipts").to(function () { loadPage("/BudgetReceipt/BudgetReceiptList", "预算管理", "年初预算收入", "#menuBudgetReceipts", false); });
Path.map("#budgetReceipts2").to(function () { loadPage("/BudgetReceipt/BudgetReceiptList2", "预算管理", "预算调整收入", "#menuBudgetReceipts2", false); });
Path.map("#budgetReceipts3").to(function () { loadPage("/BudgetReceipt/BudgetReceiptList3", "预算管理", "调整后增加收入", "#menuBudgetReceipts3", false); });
Path.map("#budgetOutlays").to(function () { loadPage("/BudgetOutlay/BudgetOutlayList", "预算管理", "年初预算支出", "#menuBudgetOutlays", false); });
Path.map("#budgetOutlays2").to(function () { loadPage("/BudgetOutlay/BudgetOutlayList2", "预算管理", "年中调整支出", "#menuBudgetOutlays2", false); });
Path.map("#budgetOutlays3").to(function () { loadPage("/BudgetOutlay/BudgetOutlayList3", "预算管理", "预算调整后支出", "#menuBudgetOutlays3", false); });
Path.map("#budgetSummary").to(function () { loadPage("/BudgetOutlay/BudgetSummary", "预算管理", "年初预算简表", "#menuBudgetSummary", false); });
Path.map("#actualOutlays").to(function () { loadPage("/ActualOutlay/ActualOutlayList", "预算管理", "实际支出", "#menuActualOutlays", false); });
Path.map("#outlays").to(function () { loadPage("/ActualOutlay/OutlayList", "预算管理", "支出对比明细", "#menuOutlays", false); });
Path.map("#receipts").to(function () { loadPage("/BudgetReceipt/ReceiptList", "预算管理", "预算收入与实际收入统计", "#menuReceipts", false); });
Path.map("#budgetperformance").to(function () { loadPage("/BudgetOutlay/BudgetPerformance", "预算管理", "预算编制及预算执行情况", "#menuBudgetperformance", false); });
Path.map("#invoices").to(function () { loadPage("/InvoiceCheck/InvoiceCheckList", "预算管理", "发票管理", "#menuInvoices", false); });
Path.map("#voucherAudits").to(function () { loadPage("/VoucherAudit/VoucherAuditList", "预算管理", "凭证审核归纳表", "#menuVoucherAudits", false); });

Path.map("#productInfos").to(function () { loadPage("/Product/InfoList", "物资器材管理", "基础信息", "#menuProductInfos", false); });
Path.map("#productCategories").to(function () { loadPage("/Storage/ProductCategoryList", "物资器材管理", "商品分类", "#menuProductCategories", false); });
Path.map("#products").to(function () { loadPage("/Product/ProductList", "物资器材管理", "商品", "#menuProducts", false); });
Path.map("#entryBills").to(function () { loadPage("/EntryBill/EntryBillList", "物资器材管理", "入库单", "#menuEntryBills", false); });
Path.map("#deliveryBills").to(function () { loadPage("/DeliveryBill/DeliveryBillList", "物资器材管理", "出库单", "#menuEeliveryBills", false); });
Path.map("#hisStocks").to(function () { loadPage("/HisStock/HisStockList", "物资器材管理", "物资报表", "#menuHisStocks", false); });
Path.map("#queryStocks").to(function () { loadPage("/HisStock/QueryStockList", "物资器材管理", "物资出入库查询", "#menuHisStocks", false); });
Path.map("#queryStockChange").to(function () { loadPage("/HisStock/QuerytockChange", "物资器材管理", "物资变动情况查询", "#menuStockChange", false); });
Path.map("#stocks").to(function () { loadPage("/Stock/StockList", "物资器材管理", "物资清单", "#menuStocks", false); });
Path.map("#checkBills").to(function () { loadPage("/CheckBill/CheckBillList", "物资器材管理", "盘点", "#menuCheckBills", false); });

Path.map("#purchaseInfos").to(function () { loadPage("/Purchase/InfoList", "采购管理", "基础信息", "#menuProductInfos", false); });
Path.map("#procurementPlans").to(function () { loadPage("/ProcurementPlan/ProcurementPlanList", "采购管理", "采购计划", "#menuProcurementPlans", false); });
Path.map("#procurementPlans1").to(function () { loadPage("/ProcurementPlan/ProcurementPlanList1", "采购管理", "采购计划调整", "#menuProcurementPlans1", false); });
Path.map("#procurementPlans2").to(function () { loadPage("/ProcurementPlan/ProcurementPlanList2", "采购管理", "追加采购计划", "#menuProcurementPlans2", false); });
Path.map("#procurementPlanSummary").to(function () { loadPage("/ProcurementPlan/ProcurementPlanListSummary", "采购管理", "年度采购计划", "#menuProcurementPlanSummary", false); });
Path.map("#poolConfig").to(function () { loadPage("/Purchase/PoolConfig", "采购管理", "抽取范围管理", "#menuPoolConfig", false); });
Path.map("#designManage").to(function () { loadPage("/ProcessManagement/DesignManage", "采购管理", "设计招标管理", "#menuDesignManage", false); });
Path.map("#costManage").to(function () { loadPage("/ProcessManagement/CostManage", "采购管理", "造价管理", "#menuCostManage", false); });
Path.map("#supervisionManage").to(function () { loadPage("/ProcessManagement/SupervisionManage", "采购管理", "监理管理", "#menuSupervisionManage", false); });
Path.map("#agentManage").to(function () { loadPage("/ProcessManagement/AgentManageManage", "采购管理", "招标代理机构管理", "#menuAgentManage", false); });
Path.map("#representativesManage").to(function () { loadPage("/ProcessManagement/RepresentativesManage", "采购管理", "甲方代表管理", "#menuRepresentativesManage", false); });
Path.map("#biddingManagements").to(function () { loadPage("/BiddingManagement/BiddingManagementList", "采购管理", "招标文件管理", "#menuBiddingManagements", false); });
Path.map("#bidOpeningManagements").to(function () { loadPage("/BidOpeningManagement/BidOpeningManagementList", "采购管理", "开标管理", "#menuBidOpeningManagements", false); });
Path.map("#projectManagements").to(function() {loadPage("/ProjectManagement/ProjectManagementList", "采购管理", "采购过程管理", "#menuProjectManagements", false);});
Path.map("#eqManagers").to(function () { loadPage("/EqManager/EqManagerList", "采购管理", "质量评价体系", "#menuEqManagers", false); });
Path.map("#blacklists").to(function () { loadPage("/Blacklist/BlacklistList", "采购管理", "黑名单管理", "#menuBlacklists", false);});
Path.map("#downloadFiles").to(function () { loadPage("/Purchase/DownloadFiles", "采购管理", "项目资料下载", "#menuDownloadFiles", false);});

Path.map("#carBaseInfos").to(function () { loadPage("/Car/InfoList", "车辆管理", "基础信息", "#menuCarInfos", false); });
Path.map("#maintenanceParts").to(function () { loadPage("/Car/MaintenancePartsList", "车辆管理", "维修部位", "#menuMaintenanceParts", false); });
Path.map("#drivers").to(function () { loadPage("/Driver/DriverList", "车辆管理", "驾驶员信息", "#menuDrivers", false); });
Path.map("#carInfos").to(function () { loadPage("/CarInfo/CarInfoList", "车辆管理", "车辆信息", "#menuCarInfos", false); });
Path.map("#oilCards").to(function () { loadPage("/OilCard/OilCardList", "车辆管理", "油料卡资料", "#menuOilCards", false); });
Path.map("#rechargeRecords").to(function () { loadPage("/RechargeRecord/RechargeRecordList", "车辆管理", "油料卡分配记录", "#menuRechargeRecords", false); });
Path.map("#applicationForBunkerAs").to(function () { loadPage("/ApplicationForBunkerA/ApplicationForBunkerAList", "车辆管理", "油料卡加油申请单", "#menuApplicationForBunkerAs", false); });
Path.map("#applicationForBunkerAs2").to(function () { loadPage("/ApplicationForBunkerA/ApplicationForBunkerAList2", "车辆管理", "油料卡加油申请单", "#menuApplicationForBunkerAs2", false); });
Path.map("#applicationForAuditA").to(function () { loadPage("/ApplicationForBunkerA/ApplicationForAuditAList", "车辆管理", "油料卡加油审批单", "#menuApplicationForAuditA", false); });
Path.map("#applicationForConfirmA").to(function () { loadPage("/ApplicationForBunkerA/ApplicationForConfirmAList", "车辆管理", "油料卡加油确认单", "#menuApplicationForAuditA", false); });
Path.map("#uploadOilCarRoofRelationships").to(function () { loadPage("/UploadOilCarRoofRelationship/UploadOilCarRoofRelationshipList", "车辆管理", "加油卡消耗凭证单", "#menuUploadOilCarRoofRelationships", false); });
Path.map("#octaneStores").to(function () { loadPage("/OctaneStore/OctaneStoreList", "车辆管理", "实物油料库", "#menuOctaneStores", false); });
Path.map("#oilRecharge").to(function () { loadPage("/OilRechargeRecord/OilRechargeRecordList", "车辆管理", "实物油料入库单", "#menuOilRecharge", false); });
Path.map("#applicationForBunkerBs").to(function () { loadPage("/ApplicationForBunkerB/ApplicationForBunkerBList", "车辆管理", "实物油料加油申请单", "#menuApplicationForBunkerBs", false); });
Path.map("#applicationForBunkerBs2").to(function () { loadPage("/ApplicationForBunkerB/ApplicationForBunkerBList2", "车辆管理", "实物油料加油申请单", "#menuApplicationForBunkerBs2", false); });
Path.map("#applicationForAuditB").to(function () { loadPage("/ApplicationForBunkerB/ApplicationForAuditBList", "车辆管理", "实物油料加油审批单", "#menuApplicationForAuditB", false); });
Path.map("#checkApplicationForBunker").to(function () { loadPage("/ApplicationForBunkerB/CheckApplicationForBunkerList", "车辆管理", "实物油料加油汇总核对表", "#menuCheckApplicationForBunker", false); });
Path.map("#applicationForBunkerBSummaryList").to(function () { loadPage("/ApplicationForBunkerB/ApplicationForBunkerBSummaryList", "车辆管理", "实物油料消耗凭证汇总单", "#menuApplicationForBunkerBSummaryList", false); });
Path.map("#totalOilHisList").to(function () { loadPage("/HisOilStock/TotalOilHisList", "车辆管理", "季度/年度油料消耗情况报表", "#menuTotalOilHisList", false); });
Path.map("#carOils").to(function () { loadPage("/CarOil/CarOilList", "车辆管理", "车辆油料核算填报", "#menuCarOils", false); });
Path.map("#carOilHisList").to(function () { loadPage("/CarOil/TotalOilHisList", "车辆管理", "车辆油料核算报表", "#menuCarOilHisList", false); });
Path.map("#applyForVehicleMaintenances").to(function () { loadPage("/ApplyForVehicleMaintenance/ApplyForVehicleMaintenanceList", "车辆管理", "车辆送修申请单", "#menuApplyForVehicleMaintenances", false); });
Path.map("#auditingForVehicleMaintenances").to(function () { loadPage("/ApplyForVehicleMaintenance/AudingForVehicleMaintenanceList", "车辆管理", "车辆送修审批单", "#menuAuditingForVehicleMaintenances", false); });
Path.map("#auditingForVehicleMaintenances2").to(function () { loadPage("/ApplyForVehicleMaintenance/AudingForVehicleMaintenanceList2", "车辆管理", "车辆维修审批单", "#menuAuditingForVehicleMaintenances", false); });
Path.map("#clearingForVehicleMaintenances").to(function () { loadPage("/ApplyForVehicleMaintenance/AudingForVehicleMaintenanceList3", "车辆管理", "车辆维修结算单", "#menuClearingForVehicleMaintenances", false); });
Path.map("#vehicleMaintenanceReport").to(function () { loadPage("/ApplyForVehicleMaintenance/VehicleMaintenanceReport", "车辆管理", "车辆维修情况报告", "#menuVehicleMaintenanceReport", false); });
Path.map("#carRepairTimes").to(function () { loadPage("/CarRepairTime/CarRepairTimeList", "车辆管理", "维修厂考评", "#menuCarRepairTimes", false); });


Path.map("#index").to(function () { loadPage("/Home/Dashboard", "主页", "主页", "#menuHome", true); });
Path.root("#index");
Path.listen();