
var main = new Vue({
    mixins: [indexMixin],
    methods: {
        query: function () {
            var $this = this;
            abp.services.app.budgetOutlay.getSummary()
                .done(function (r) {
                    $this.list = r;
                });
        }
    }
});

main.query();



