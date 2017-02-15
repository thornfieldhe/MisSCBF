
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
Path.map("#projects").to(function () { loadPage("/Project/ProjectList", "项目管理", "项目管理", "#menuProjects", false); });
Path.map("#projectTasks").to(function () { loadPage("/ProjectTask/ProjectTaskList", "项目管理", "任务管理", "#menuProjectTasks", false); });
Path.map("#dailylogs").to(function () { loadPage("/DailyLog/DailyLogList", "项目管理", "工作日志", "#menuDailyLogs", false); });
Path.map("#showDdailylogs").to(function () { loadPage("/DailyLog/DailyLogSummary", "项目管理", "工作日志查询", "#showDdailylogs", false); });
Path.map("#projectStatistic").to(function () { loadPage("/Project/ProjectStatistic", "项目管理", "项目统计", "#projectStatistic", false); });

Path.map("#index").to(function () { loadPage("/Home/Dashboard", "主页", "主页", "#menuHome", true); });
Path.root("#index");
Path.listen();