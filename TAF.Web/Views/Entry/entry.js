Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#entryFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditProductId").select2()
            .on("change", function (e) {
                $this.item.productId = $("#searchEditProductId").val(); });            
        var spinboxAmount = $('#spinboxAmount').spinbox('value', 0);
        spinboxAmount.options.max = 100;
        spinboxAmount.options.min= 0;
        $("#searchEditStorageId").select2()
            .on("change", function (e) {
                $this.item.storageId = $("#searchEditStorageId").val(); });            
    },
    data: function () {
        return {
            item: {
                id: "",            
                productId: "",
                amount: 0,
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
            $this.item.amount = $('#amount').val();
            abp.services.app.entry.saveAsync($this.item)
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
            abp.services.app.entry.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditProductId").select2().val($this.item.productId).trigger("change");
                    $('#spinboxAmount').spinbox('value',$this.item.amount);
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
            this.item.productId= "";
            $("#searchEditproductId").select2().val("").trigger("change");
            this.item.amount= 0;
            $('#spinboxAmount').spinbox('value', 0);
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
        $("#searchProductId").select2().on("change", function (e) { main.queryEntity.productId = $("#searchProductId").val(); });
        $("#searchStorageId").select2().on("change", function (e) { main.queryEntity.storageId = $("#searchStorageId").val(); });
        $("#searchIsSpecial").select2().on("change", function (e) { main.queryEntity.isSpecial = $("#searchIsSpecial").val(); });
    },
    data: {
        queryEntity: {
            productId:"", 
            storageId:"", 
            code:"", 
            note:"", 
            isSpecial:false        
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.productId="";
            this.queryEntity.storageId="";
            this.queryEntity.code="";
            this.queryEntity.note="";
            this.queryEntity.isSpecial=false;      
            $("#searchProductId").select2().val("").trigger("change");
            $("#searchCode").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.entry.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.entry.delete(id)
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



