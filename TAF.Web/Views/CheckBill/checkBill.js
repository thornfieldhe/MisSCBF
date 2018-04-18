Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#checkFormBody",
    data: function () {
        return {
            item: {
                id: "",
                productName: "",
                productCode: "",
                specifications: "",
                unit: "",
                stockAmount: 0,
                amount: 0,
                changedAmount: 0,
                reason: "",
                price: 0
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
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
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.productId = "";
            $("#searchEditproductId").select2().val("").trigger("change");
            this.item.stockAmount = 0;
            $('#spinboxStockAmount').spinbox('value', 0);
            this.item.amount = 0;
            $('#spinboxAmount').spinbox('value', 0);
            this.item.reason = "";
            this.item.price = 0;
            $('#spinboxPrice').spinbox('value', 0);
            this.item.checkBillId = "";
            $("#searchEditcheckBillId").select2().val("").trigger("change");
        }
    }
});

var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchStorageId").select2().on("change", function (e) { main.queryEntity.storageId = $("#searchStorageId").val(); });
    },
    data: {
        queryEntity: {
            productCode:"", 
            productName:"", 
            code: "",
            storageId:"",
            billId:"",
        }
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.productCode=""; 
            this.queryEntity.productName="";
            this.queryEntity.code="";
            this.queryEntity.billId="";
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

$(".fileUpload").liteUploader({
    script: defaultUrl + "CheckBill/Upload?stockId=" + $("#searchStorageId").select2().val()
    })
    .on("lu:success", function (e, response) {
        main.queryEntity.billId = response;
        main.query(0);
        taf.notify.success("盘点报告导入成功");
    });

$(".fileUpload").change(function () {
    $(this).data("liteUploader").startUpload();
});


