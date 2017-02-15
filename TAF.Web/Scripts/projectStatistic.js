var main = new Vue({
    mixins: [indexMixin],
    data: {
        queryEntity: {
            dateFrom: "",
            dateTo: ""
        }
    },
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
    methods: {
        search: function () {
            $("#statistics").load("/Project/LoadStatistic",this.queryEntity);
        }
    }
});