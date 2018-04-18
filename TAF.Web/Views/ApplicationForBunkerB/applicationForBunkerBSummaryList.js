var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#month").select2().on("change", function (e) { main.queryMonth = $("#month").val(); });
    },
    data: {
        queryMonth: ""
    },
    methods: {
        query: function () {
            var $this = this;
            if ($this.queryMonth === "") {
                taf.notify.danger("请选择凭证月份");
            } else {
                abp.services.app.applicationForBunkerB.getApplicationForBunkerBSummaryList($this.queryMonth)
                    .done(function (r) {
                        $this.list = r;
                        _.each($this.list,
                            function(value) {
                                value.amountTo2 = value.amountTo == -1 ?"-":value.amountTo.toString();
                            });
                    });
            }
        }
    }
});




