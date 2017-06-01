var main = new Vue({
    mixins: [indexMixin],
    data: {
        queryEntity: {
            code:"", 
            productName:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.code="";
            this.queryEntity.productName="";
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.stock.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        }
    }
});

main.query(0);



