Vue.component("form-body",
    {
        template: "#actualOutlayFormBody",
        data: function () {
            return {
                list2: {}
            }
        },
        events: {
            'onShowDetails': function (list) {
                this.list2 = list;
                console.log("list2:", list);
                $("#showOutlayModal").modal("show");
            }
        }
    });

var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        var $this = this;
        $this.query();
    },
    data: {
        list: {}
    },
    methods: {
        query: function () {
            var $this = this;
            abp.services.app.budgetOutlay.getAll()
                .done(function (r) {
                    $this.list = r;
                });
        },
        showDetails: function (id) {
            var $this = this;
            abp.services.app.actualOutlay.getByOutlayId(id)
                .done(function (r) {
                    $this.$broadcast('onShowDetails', r);
                });
        }
    }
});




