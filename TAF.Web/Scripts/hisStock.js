var main = new Vue({
    mixins: [indexMixin],
    data: {
        list: {},
        quarter:0
    },
    ready: function () {
        $("#searchQuarter").select2().on("change", function (e) { main.quarter = $("#searchQuarter").val(); });
    },
    methods: {
        query: function () {
            var $this = this;
            abp.services.app.hisStock.getHistory($this.quarter)
                .done(function (r) {
                    console.log(r);
                    $this.list= r;
                });
        }
    }
});



