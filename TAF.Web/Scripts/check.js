Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#checkFormBody",
    ready: function () {
        var $this = this;
        $("#searchEditProductId").select2()
            .on("change", function (e) {
                $this.item.productId = $("#searchEditProductId").val(); });            
        var spinboxStockAmount = $('#spinboxStockAmount').spinbox('value', 0);
        spinboxStockAmount.options.max = 100;
        spinboxStockAmount.options.min= 0;
        var spinboxAmount = $('#spinboxAmount').spinbox('value', 0);
        spinboxAmount.options.max = 100;
        spinboxAmount.options.min= 0;
        var spinboxChangedAmount = $('#spinboxChangedAmount').spinbox('value', 0);
        spinboxChangedAmount.options.max = 100;
        spinboxChangedAmount.options.min= 0;
        var spinboxPrice = $('#spinboxPrice').spinbox('value', 0);
        spinboxPrice.options.max = 100;
        spinboxPrice.options.min= 0;
        $("#searchEditStorageId").select2()
            .on("change", function (e) {
                $this.item.storageId = $("#searchEditStorageId").val(); });            
    },
    data: function () {
        return {
            item: {
                id: "",            
                productId: "",
                stockAmount: 0,
                amount: 0,
                changedAmount: 0,
                reason: "",
                price: 0,
                storageId: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            $this.item.stockAmount = $('#stockAmount').val();
            $this.item.amount = $('#amount').val();
            $this.item.changedAmount = $('#changedAmount').val();
            $this.item.price = $('#price').val();
            abp.services.app.check.saveAsync($this.item)
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
            abp.services.app.check.get(id)
                .done(function (m) {
                    $this.item = m;
                    $("#searchEditProductId").select2().val($this.item.productId).trigger("change");
                    $('#spinboxStockAmount').spinbox('value',$this.item.stockAmount);
                    $('#spinboxAmount').spinbox('value',$this.item.amount);
                    $('#spinboxChangedAmount').spinbox('value',$this.item.changedAmount);
                    $('#spinboxPrice').spinbox('value',$this.item.price);
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
            this.item.stockAmount= 0;
            $('#spinboxStockAmount').spinbox('value', 0);
            this.item.amount= 0;
            $('#spinboxAmount').spinbox('value', 0);
            this.item.changedAmount= 0;
            $('#spinboxChangedAmount').spinbox('value', 0);
            this.item.reason= "";
            this.item.price= 0;
            $('#spinboxPrice').spinbox('value', 0);
            this.item.storageId= "";
            $("#searchEditstorageId").select2().val("").trigger("change");
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchProductId").select2().on("change", function (e) { main.queryEntity.productId = $("#searchProductId").val(); });
        $("#searchStorageId").select2().on("change", function (e) { main.queryEntity.storageId = $("#searchStorageId").val(); });
    },
    data: {
        queryEntity: {
            productId:"", 
            reason:"", 
            storageId:"" 
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.productId="";
            this.queryEntity.reason="";
            this.queryEntity.storageId="";
            $("#searchProductId").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.check.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.check.delete(id)
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



