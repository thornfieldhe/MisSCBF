
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



Path.map("#userList").to(function () { loadPage("/Account/UserList", "系统管理", "用户管理", "#menuUsers", false); });
Path.map("#changePwd").to(function () { loadPage("/Account/ChangePwd", "系统管理", "修改密码", "#menuChangePass", false); });
Path.map("#baseInfos").to(function () { loadPage("/SysDictionary/SysDictionaryList", "仓库管理", "基础信息", "#menuBaseInfos", false); });

Path.map("#financeInfos").to(function () { loadPage("/Finance/InfoList", "预算管理", "基础信息", "#menuFinanceInfos", false); });
Path.map("#account").to(function () { loadPage("/Finance/AccountList", "预算管理", "会计科目", "#menuAccount", false); });
Path.map("#budgetReceipts").to(function () { loadPage("/BudgetReceipt/BudgetReceiptList", "预算管理", "年度预算收入", "#menuBudgetReceipts", false); });

Path.map("#productCategories").to(function () { loadPage("/Storage/ProductCategoryList", "仓库管理", "商品分类", "#menuProductCategories", false); });
Path.map("#products").to(function () { loadPage("/Product/ProductList", "商品", "products", "#menuProducts", false); });
Path.map("#entryBills").to(function () { loadPage("/EntryBill/EntryBillList", "入库单", "entryBills", "#menuEntryBills", false); });
Path.map("#deliveryBills").to(function () { loadPage("/DeliveryBill/DeliveryBillList", "出库单", "entryBills", "#menuEeliveryBills", false); });

Path.map("#index").to(function () { loadPage("/Home/Dashboard", "主页", "主页", "#menuHome", true); });
Path.root("#index");
Path.listen();