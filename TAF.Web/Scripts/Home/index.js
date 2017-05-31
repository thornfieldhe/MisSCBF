
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
Path.map("#budgetReceipts").to(function () { loadPage("/BudgetReceipt/BudgetReceiptList", "预算管理", "年度预算收入", "#menuBudgetReceipts", false); });
Path.map("#budgetReceipts2").to(function () { loadPage("/BudgetReceipt/BudgetReceiptList2", "预算管理", "预算调整收入", "#menuBudgetReceipts2", false); });
Path.map("#budgetReceipts3").to(function () { loadPage("/BudgetReceipt/BudgetReceiptList3", "预算管理", "调整后增加收入", "#menuBudgetReceipts3", false); });
Path.map("#budgetOutlays").to(function () { loadPage("/BudgetOutlay/BudgetOutlayList", "预算管理", "年度预算支出", "#menuBudgetOutlays", false); });
Path.map("#budgetSummary").to(function () { loadPage("/BudgetOutlay/BudgetSummary", "预算管理", "年度预算简表", "#menuBudgetSummary", false); });
Path.map("#actualOutlays").to(function () { loadPage("/ActualOutlay/ActualOutlayList", "预算管理", "实际支出", "#menuActualOutlays", false); });
Path.map("#outlays").to(function () { loadPage("/ActualOutlay/OutlayList", "预算管理", "支出对比明细", "#menuOutlays", false); });
Path.map("#receipts").to(function () { loadPage("/BudgetReceipt/ReceiptList", "预算管理", "预算收入与实际收入统计", "#menuReceipts", false); });

Path.map("#productInfos").to(function () { loadPage("/Product/InfoList", "物资器材管理", "基础信息", "#menuProductInfos", false); });
Path.map("#productCategories").to(function () { loadPage("/Storage/ProductCategoryList", "物资器材管理", "商品分类", "#menuProductCategories", false); });
Path.map("#products").to(function () { loadPage("/Product/ProductList", "物资器材管理", "商品", "#menuProducts", false); });
Path.map("#entryBills").to(function () { loadPage("/EntryBill/EntryBillList", "物资器材管理", "入库单", "#menuEntryBills", false); });
Path.map("#deliveryBills").to(function () { loadPage("/DeliveryBill/DeliveryBillList", "物资器材管理", "出库单", "#menuEeliveryBills", false); });
Path.map("#hisStocks").to(function () { loadPage("/HisStock/HisStockList", "物资器材管理", "物资报表", "#menuHisStocks", false); });
Path.map("#queryStocks").to(function () { loadPage("/HisStock/QueryStockList", "物资器材管理", "物资出入库查询", "#menuHisStocks", false); });
Path.map("#queryStockChange").to(function () { loadPage("/HisStock/QuerytockChange", "物资器材管理", "物资变动情况查询", "#menuStockChange", false); });

Path.map("#index").to(function () { loadPage("/Home/Dashboard", "主页", "主页", "#menuHome", true); });
Path.root("#index");
Path.listen();