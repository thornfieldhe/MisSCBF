var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        var dateFrom = $('#dateFrom').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            dateFrom.hide();
            main.queryEntity.dateFrom = $("#dateFrom").val();
        }).data('datepicker');
        var dateTo = $('#dateTo').datepicker({ format: 'yyyy-mm-dd' }).on('changeDate', function (ev) {
            dateTo.hide();
            main.queryEntity.dateTo = $("#dateTo").val();
        }).data('datepicker');
    },
    data: {
        queryEntity: {
            code: "",
            productCode: "",
            dateFrom: "",
            dateTo: "",
            name: ""
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.productCode = "";
            this.queryEntity.code = "";
            this.queryEntity.name = "";
            this.queryEntity.dateFrom = "";
            this.queryEntity.dateTo = "";
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.hisStock.getAll($this.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        }
    }
});

main.query(0);

