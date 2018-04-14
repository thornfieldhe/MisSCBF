
Vue.component("form-body",
{
    template: "#budgetReceiptFormBody",
    data: function() {
        return {
            item: {}
        }
    },
    events: {
        'onShowDetails':function(item) {
            this.item = item;
            $("#showBudgetDetails1").modal("show");
        }
    }
});

var main = new Vue({
    mixins: [indexMixin],
    methods: {
        query: function () {
            var $this = this;
            abp.services.app.budgetReceipt.get(0)
                .done(function (r) {
                    $this.list = r;
                });
        },
        showDetails: function (item) {
            this.$broadcast('onShowDetails', item);
        }
    }
});

main.query();
$(".fileUpload").liteUploader({
    script: defaultUrl+"BudgetReceipt/Upload1"
})
    .on("lu:success", function (e, response) {
        main.query();
        taf.notify.success("年初预算收入导入成功");
    });

$(".fileUpload").change(function () {
    $(this).data("liteUploader").startUpload();
});



