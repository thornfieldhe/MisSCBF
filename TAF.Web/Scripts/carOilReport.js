var main = new Vue({
    el: "#main",
    mixins: [allMixin],
    ready: function () {
        var $this = this;
        $("#searchMonth").select2()
            .on("change", function (e) {
                $this.queryEntity.month = $("#searchMonth").val();
            });
    },
    data: {
        queryEntity: {
            year : "",
            month : ""
        },
        items:[]
    },
    methods: {
        query: function () {
            var $this = this;
            console.log($this.queryEntity.year, $this.queryEntity.month);
            if ($this.queryEntity.year === "" || $this.queryEntity.month==="") {
                taf.notify.danger("年月不能为空");
            } else {
                abp.services.app.carOil.getReport({ key: $this.queryEntity.year, value: $this.queryEntity.month })
                    .done(function (r) {
                        $this.items = r;
                    });
            }
        }
    }
});



