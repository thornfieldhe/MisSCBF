//taf基础工具
var taf = {
    //订阅器
    subscriber: {
        //新增订阅
        addSubscriber: function (id, callBack) {
            erp.subscriber.subscribers[id] = callBack;
        },
        //注销订阅
        unSubscriber: function (id) {
            delete erp.subscriber.subscribers[id];
        },
        //发布订阅
        publish: function (id, data) {
            var item = erp.subscriber.subscribers[id];
            if (item === null || item === 'undefined') return;
            item(data);
        }
    },
    //通知
    notify: {
        danger: function (text) {
            Notify(text, 'top-right', '5000', 'danger', 'fa-times', true);
        },
        success: function (text) {
            Notify(text, 'top-right', '5000', 'success', 'fa-times', true);
        }
    },
    defatulPageSize: 10,
    //级联更新下拉列表时重新绑定次级下拉列表
    successiveBindSelect: function (el, list) {
        var txt = '<option value="">请选择...</option>';
        _.forEach(list,
            function (n, key) {
                txt += '<option value="' + n.value + '">' + n.key + '</option>';
            });
        el.empty().append(txt);

    },
    // 生成随机数
    random: function (range) {
        var num = Math.random();//Math.random()：得到一个0到1之间的随机数
        return Math.ceil(num * range);//num*80的取值范围在0~10000之间,使用向上取整就可以得到一个1~10000的随机数
    },
    //时间选择器初始化属性
    timepickerOptions: {
        showMeridian: false,
        maxHours: 24
    },
    //日期选择器初始化属性
    datepickerOptions: {
        format: 'yyyy-mm-dd'
    },
    download: function(url) {
        //定义一个form表单,通过form表单来发送请求
        var form=$("<form>");

        //设置表单状态为不显示
        form.attr("style","display:none");

        //method属性设置请求类型为get
        form.attr("method","get");

        //action属性设置请求路径,(如有需要,可直接在路径后面跟参数)
        //例如:htpp://127.0.0.1/test?id=123
        form.attr("action",url);

        //将表单放置在页面(body)中
        $("body").append(form);

        //表单提交
        form.submit();
    },
    hTMLEnCode:function(str)   
    {   
        var    s    =    "";   
        if    (str.length    ==    0)    return    "";   
        s    =    str.replace(/&/g,    "&gt;");   
        s    =    s.replace(/</g,        "&lt;");   
        s    =    s.replace(/>/g,        "&gt;");   
        s    =    s.replace(/    /g,        "&nbsp;");   
        s    =    s.replace(/\'/g,      "'");   
        s    =    s.replace(/\"/g,      "&quot;");   
        s    =    s.replace(/\n/g,      "<br>");   
        return    s;   
    }, 
    hTMLDeCode:function(str)   
    {   
        var    s    =    "";   
        if    (str.length    ==    0)    return    "";   
        s    =    str.replace(/&gt;/g,    "&");   
        s    =    s.replace(/&lt;/g,        "<");   
        s    =    s.replace(/&gt;/g,        ">");   
        s    =    s.replace(/&nbsp;/g,        "    ");   
        s    =    s.replace(/'/g,      "\'");   
        s    =    s.replace(/&quot;/g,      "\"");   
        s    =    s.replace(/<br>/g,      "\n");   
        return    s;   
    }
}

Vue.validator('int',
    function (val) {
        return /^\d+$/.test(val);
    });
Vue.validator('float',
    function (val) {
        return /^\d+(\.\d+)?$/.test(val);
    });
Vue.validator('dateTime', function (val) {
    return /^\d{4}-\d{2}-\d{2}$/.test(val);
});



//订阅器集合
taf.subscriber.subscribers = new Array();