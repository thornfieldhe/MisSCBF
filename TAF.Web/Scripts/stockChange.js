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
            dateFrom: "",
            dateTo: ""
        }
    },
    methods: {
        excuteQuery: function ($this) {
            if ($this.queryEntity.dateFrom === '' || $this.queryEntity.dateTo === '') {
                taf.notify.danger("起止时间不能为空");
            } else {
                abp.services.app.hisStock.getStockChange($this.queryEntity)
                    .done(function (r) {
                        $this.bindItems($this, r);
                    });
            }
        }
    }
});


