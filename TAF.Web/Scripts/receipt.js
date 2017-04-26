Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#receiptFormBody",
    data: function () {
        return {
            item: {
                id: "",            
                year: 0,
                amount: 0,
                code: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.budgetReceipt.saveReceuotAmount({key:$this.item.code,value:$this.item.amount})
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
            abp.services.app.budgetReceipt.getReceipt(id)
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
            this.item.amount= 0;
            this.item.code= "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    methods: {
        query: function () {
            var $this = this;
            abp.services.app.budgetReceipt.getReceipts()
                .done(function (r) {
                    $this.list=r;
                });
        },
        editItem:function(id,title) {
            this.$dispatch('onUpdateItem', title, id);
        }
    }
});

main.query();



