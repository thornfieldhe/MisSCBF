Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#entryBillFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditStorageId").select2()
            .on("change", function (e) {
                $this.item.storageId = $("#searchEditStorageId").val(); });            
    },
    data: function () {
        return {
            item: {
                id: "",            
                storageId: "",
                code: "",
                note: "",
                isSpecial: false
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.entryBill.saveAsync($this.item)
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
            abp.services.app.entryBill.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditStorageId").select2().val($this.item.storageId).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.storageId= "";
            $("#searchEditstorageId").select2().val("").trigger("change");
            this.item.code= "";
            this.item.note= "";
            this.item.isSpecial= false;
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchStorageId").select2().on("change", function (e) { main.queryEntity.storageId = $("#searchStorageId").val(); });
        $("#searchIsSpecial").select2().on("change", function (e) { main.queryEntity.isSpecial = $("#searchIsSpecial").val(); });
    },
    data: {
        queryEntity: {
            storageId:"", 
            code:"", 
            note:"", 
            isSpecial:false        
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.storageId="";
            this.queryEntity.code="";
            this.queryEntity.note="";
            this.queryEntity.isSpecial=false;      
            $("#searchStorageId").select2().val("").trigger("change");
            $("#searchIsSpecial").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.entryBill.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.entryBill.delete(id)
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



