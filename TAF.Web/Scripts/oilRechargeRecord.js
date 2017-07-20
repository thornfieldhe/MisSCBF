Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#oilRechargeRecordFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditOctanceId").select2()
            .on("change", function (e) {
                $this.item.octanceId = $("#searchEditOctanceId").val(); });            
        $("#searchEditStoreId").select2()
            .on("change", function (e) {
                $this.item.storeId = $("#searchEditStoreId").val(); });            
    },
    data: function () {
        return {
            item: {
                id: "",            
                octanceId: "",
                amount: 0,
                note: "",
                storeId:"",
                attachmentId: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.oilRechargeRecord.saveAsync($this.item)
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
            abp.services.app.oilRechargeRecord.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditOctanceId").select2().val($this.item.octanceId).trigger("change");
                    $("#searchEditStoreId").select2().val($this.item.storeId).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.octanceId= "";
            $("#searchEditoctanceId").select2().val("").trigger("change");
            this.item.amount= 0;
            this.item.storeId= "";
            $("#searchEditStoreId").select2().val("").trigger("change");
            this.item.note= "";
            this.item.attachmentId= "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchOctanceId").select2().on("change", function (e) { main.queryEntity.octanceId = $("#searchOctanceId").val(); });
        $("#searchStoreId").select2().on("change", function (e) { main.queryEntity.storeId = $("#searchStoreId").val(); });
    },
    data: {
        queryEntity: {
            octanceId:"", 
            storeId:"", 
            note:"", 
            attachmentId:"" 
        },
        list:{}
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.octanceId="";
            this.queryEntity.storeId="";
            this.queryEntity.note="";
            this.queryEntity.attachmentId="";
            $("#searchOctanceId").select2().val("").trigger("change");
            $("#searchStoreId").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.oilRechargeRecord.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.oilRechargeRecord.delete(id)
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



