Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#oilCardFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditCarInfoId").select2()
            .on("change", function (e) {
                $this.item.carInfoId = $("#searchEditCarInfoId").val(); });            
    },
    data: function () {
        return {
            item: {
                id: "",            
                code: "",
                amount: 0,
                carInfoId: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.oilCard.saveAsync($this.item)
            .done(function (m) {
                $this.done(closeModal);
            })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            abp.services.app.oilCard.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditCarInfoId").select2().val($this.item.carInfoId).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.code= "";
            this.item.amount= 0;
            this.item.carInfoId= "";
            $("#searchEditcarInfoId").select2().val("").trigger("change");
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchCarInfoId").select2().on("change", function (e) { main.queryEntity.carInfoId = $("#searchCarInfoId").val(); });
    },
    data: {
        queryEntity: {
            code:"", 
            carInfoId:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.code="";
            this.queryEntity.carInfoId="";
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.oilCard.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.oilCard.delete(id)
                .done(function (m) {
                    $this.done();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    }
});

main.query(0);



