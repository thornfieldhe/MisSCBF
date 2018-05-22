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