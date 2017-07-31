var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#quarter").select2().on("change", function (e) { main.quarter = $("#quarter").val(); });
    },
    data: {
        quarter: "",
        list1:{},
        list2:{}
    },
    methods: {
        query: function () {
            var $this = this;
            if ($this.quarter === "") {
                taf.notify.danger("请选择季度");
            } else {
               this.query1();
                this.query2();
            }
        },
        query1: function () {
            var $this = this;
            abp.services.app.hisStoreStock.getOilStoreHis($this.quarter)
                .done(function (r) {
                    $this.list1 = r;
                });
        },
        query2: function () {
            var $this = this;
            abp.services.app.hisStoreStock.getOilCardHis($this.quarter)
                .done(function (r) {
                    $this.list2 = r;
                });
        }
    }
});




