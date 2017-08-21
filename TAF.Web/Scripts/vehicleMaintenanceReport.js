var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchQuarter").select2().on("change", function (e) { main.queryEntity.quarter = $("#searchQuarter").val(); });
    },
    data: {
        queryEntity: {
            quarter:3
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.applyForVehicleMaintenance.getReport(main.queryEntity.quarter)
                .done(function (r) {
                    $this.list=r;
                });
        }
    }
});

main.query(0);



