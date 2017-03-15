Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#productFormBody",
    ready: function () {
        var $this = this;
        var spinboxUnitConversion = $('#spinboxUnitConversion').spinbox('value', 0);
        var spinboxOrder = $('#spinboxOrder').spinbox('value', 0);
        spinboxUnitConversion.options.min= 0;
        spinboxOrder.options.min = 0;
        $("#searchBrandItem").select2().on("change", function (e) { $this.item.brand = $("#searchBrandItem").val(); });
        $("#searchColorItem").select2().on("change", function (e) { $this.item.color = $("#searchColorItem").val(); });
    },
    data: function () {
        return {
            item: {
                id: "",            
                name: "",
                specifications: "",
                unit: "",
                unit2: "",
                unitConversion: 0,
                color: "",
                note1: "",
                code: "",
                note2: "",
                order: 0,
                categoryId: ""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            $this.item.unitConversion = $('#unitConversion').val();
            $this.item.order = $('#spinboxOrder').val();
            abp.services.app.product.saveAsync($this.item)
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
            abp.services.app.product.get(id)
                .done(function (m) {
                    $this.item = m;
                    $this.item.categoryId = main.queryEntity.categoryId;
                    $('#spinboxUnitConversion').spinbox('value',$this.item.unitConversion);
                    $('#spinboxOrder').spinbox('value', $this.item.order);
                    $("#searchColorItem").select2().val($this.item.color).trigger("change");
                    $("#searchBrandItem").select2().val($this.item.brand).trigger("change");
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.id = "";
            this.item.name= "";
            this.item.code= "";
            this.item.specifications= "";
            this.item.pYCode= "";
            this.item.unit= "";
            this.item.unit2= "";
            this.item.unitConversion= 0;
            $('#spinboxUnitConversion').spinbox('value', 0);
            $('#spinboxOrder').spinbox('value', 0);
            this.item.color= "";
            this.item.note1= "";
            this.item.note2= "";
            this.item.order = 0;
            this.item.categoryId = main.queryEntity.categoryId;
            $("#searchColorItem").select2().val("").trigger("change");
            $("#searchBrandItem").select2().val("").trigger("change");
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        $("#searchColor").select2().on("change", function (e) { main.queryEntity.color = $("#searchColor").val(); });
        $("#searchBrand").select2().on("change", function (e) { main.queryEntity.brand = $("#searchBrand").val(); });
        this.loadTree();
    },
    data: {
        queryEntity: {
            name:"", 
            specifications:"", 
            color:"", 
            brand: "",
            code: "",
            categoryId:""
        },
        showProducts:false
    },
    events: {
        'onResetSearch': function () {
            this.queryEntity.name="";
            this.queryEntity.specifications = "";
            this.queryEntity.code = "";
            $("#searchColor").select2().val("").trigger("change");
            $("#searchBrand").select2().val("").trigger("change");
        }
    },
    methods: {
        excuteQuery: function ($this) {
            abp.services.app.product.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.product.delete(id)
                .done(function (m) {
                    $this.done();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        loadTree: function () {
            var $this = this;
            abp.services.app.layer.getAllByCategory("ProductCategory")
                .done(function (m) {
                    $this.tree = $.fn.zTree.init($("#treeCatalog"), {
                        data: {
                            simpleData: {
                                enable: true
                            }
                        },
                        callback: {
                            onClick: function (event, treeId, treeNode, clickFlag) {
                                $this.queryEntity.categoryId = treeNode.id;
                                $this.showProducts = true;
                                $this.query(0);
                            }
                        }
                    }, m);
                    $this.tree.expandAll(true);
                });
        }
    }
});





