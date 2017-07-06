Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#oilRechargeRecordFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditOctanceId").select2()
            .on("change", function (e) {
                $this.item.octanceId = $("#searchEditOctanceId").val(); });            
        $("#searchEditAmount").select2()
            .on("change", function (e) {
                $this.item.amount = $("#searchEditAmount").val(); });            
    },
    data: function () {
        return {
            item: {
                id: "",            
                octanceId: "",
                amount: "",
                note: "",
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
                    $("#searchEditAmount").select2().val($this.item.amount).trigger("change");
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
            this.item.amount= "";
            $("#searchEditamount").select2().val("").trigger("change");
            this.item.note= "";
            this.item.attachmentId= "";
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchOctanceId").select2().on("change", function (e) { main.queryEntity.octanceId = $("#searchOctanceId").val(); });
        $("#searchAmount").select2().on("change", function (e) { main.queryEntity.amount = $("#searchAmount").val(); });
    },
    data: {
        queryEntity: {
            octanceId:"", 
            amount:"", 
            note:"", 
            attachmentId:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.octanceId="";
            this.queryEntity.amount="";
            this.queryEntity.note="";
            this.queryEntity.attachmentId="";
            $("#searchOctanceId").select2().val("").trigger("change");
            $("#searchAmount").select2().val("").trigger("change");
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



