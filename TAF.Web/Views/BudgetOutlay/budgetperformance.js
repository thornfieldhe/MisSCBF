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
            taf.download("/BudgetOutlay/Download");
        }
    }
});

main.query();



