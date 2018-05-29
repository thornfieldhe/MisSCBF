Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#budgetperformanceFormBody",
    data: function () {
        return {
            item: {
                id: "",
                year: 0,
                total1: 0,
                total2: 0,
                total3: 0,
                note: 0,
                code: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.budgetOutlay.saveOutlaySummary($this.item)
                .done(function (m) {
                    $this.done(closeModal);
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            console.log(id);
            abp.services.app.budgetOutlay.getOutlaySummary(id)
                .done(function (m) {
                    $this.item = m;

                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.total1 = 0;
            this.item.total2 = 0;
            this.item.total3 = 0;
            this.item.code = "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    methods: {
        query: function () {
            var $this = this;
            abp.services.app.budgetOutlay.getBudgetPerformances()
                .done(function (r) {
                    $this.list = r;
                });
        },
        editItem: function (id, title) {
            this.$dispatch('onUpdateItem', title, id);
        },
        export: function() {
            //定义一个form表单,通过form表单来发送请求
            var form=$("<form>");

            //设置表单状态为不显示
            form.attr("style","display:none");

            //method属性设置请求类型为get
            form.attr("method","get");

            //action属性设置请求路径,(如有需要,可直接在路径后面跟参数)
            //例如:htpp://127.0.0.1/test?id=123
            form.attr("action","/BudgetOutlay/Download");

            //将表单放置在页面(body)中
            $("body").append(form);

            //表单提交
            form.submit();
        
        }
    }
});

main.query();



