
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
Path.map("#baseInfos").to(function () { loadPage("/Storage/BaseInfos", "仓库管理", "基础信息", "#menuBaseInfos", false); });
Path.map("#productCategories").to(function () { loadPage("/Storage/ProductCategoryList", "仓库管理", "商品分类", "#productCategories", false); });


Path.map("#index").to(function () { loadPage("/Home/Dashboard", "主页", "主页", "#menuHome", true); });
Path.root("#index");
Path.listen();