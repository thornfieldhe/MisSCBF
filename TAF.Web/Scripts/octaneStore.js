Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#octaneStoreFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditStoreId")
            .select2()
            .on("change", function (e) {
                $this.item.storeId = $("#searchEditStoreId").val();
            });            
        $("#searchEditOctaneRatingId")
            .select2()
            .on("change", function (e) {
                $this.item.octaneRatingId = $("#searchEditOctaneRatingId").val();
            });            
    },
    data: function () {
        return {
            item: {
                id: "",            
                storeId: "",
                octaneRatingId: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.octaneStore.saveAsync($this.item)
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
            abp.services.app.octaneStore.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditStoreId").select2().val($this.item.storeId).trigger("change");
                    $("#searchEditOctaneRatingId").select2().val($this.item.octaneRatingId).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            console.log(1111);
            this.item.id = "";
            this.item.storeId = "";
            this.item.octaneRatingId = "";
            $("#searchEditstoreId").select2().val("").trigger("change");
            $("#searchEditoctaneRatingId").select2().val("").trigger("change");
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchStoreId").select2().on("change", function (e) { main.queryEntity.storeId = $("#searchStoreId").val(); });
    },
    data: {
        queryEntity: {
            storeId:"", 
            octaneRatingId: "",
            amount: 0
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.storeId="";
            this.queryEntity.octaneRatingId="";
            $("#searchStoreId").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.octaneStore.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.octaneStore.delete(id)
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



