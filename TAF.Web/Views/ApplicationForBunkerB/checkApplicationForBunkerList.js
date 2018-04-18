var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#month").select2().on("change", function (e) { main.queryMonth = $("#month").val(); });
    },
    data: {
        queryMonth: "",
        selectIds:[]
    },
    methods: {
        query: function () {
            var $this = this;
            if ($this.queryMonth === "") {
                taf.notify.danger("请选择凭证月份");
            } else {
                abp.services.app.applicationForBunkerB.checkApplicationForBunkerBList($this.queryMonth)
                    .done(function (r) {
                        $this.list=r;
                    });
            }
        },
        delete: function () {
            var $this = this;
            abp.services.app.applicationForBunkerB.delete($this.selectIds)
                .done(function (m) {
                    $this.done();
                    $("#deleteCheckApplicationForBuckerBDialog").modal("hide");
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        link:function() {
            var $this = this;
            abp.services.app.applicationForBunkerB.check($this.selectIds)
                .done(function (m) {
                    $this.query();
                    taf.notify.success("实物油料对账成功");
                });
        },
        showDelete:function() {
            $("#deleteCheckApplicationForBuckerBDialog").modal("show");
        }
    }
});




