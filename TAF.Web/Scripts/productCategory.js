Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#productCategoryFormBody",
    ready: function () {
        var order = $("#spinboxOrder").spinbox("value", 0);
        order.options.max = 100;
        order.options.min = 0;
        $("body").bind("mousedown", function (event) {
            if (!(event.target.id === "menuBtn" || event.target.id === "menuContent" || $(event.target).parents("#menuContent").length > 0)) {
                $("#menuContent").hide();
            }
        });
    },
    data: function () {
        return {
            item: {
                category: "ProductCategory",
                name: "",
                pId: "",
                pName: "",
                id: "",
                order:0
            },tree:{}
        };
    },
    events: {
        'onSaveItem': function () {
            var $this = this;
            $this.item.order = $('#order').val();
            abp.services.app.layer.saveAsync($this.item)
            .done(function (m) {
                $this.done();
                main.loadTree();
                })
            .fail(function (m) {
                $this.fail(m);
            });
        },
        'onGetItem': function (id) {
            this.editModel = true;
            var $this = this;
            abp.services.app.layer.get(id)
                .done(function (m) {
                    console.log(m);
                    $this.item = m;
                    $this.item.pName =  $this.item.pId==="00000000-0000-0000-0000-000000000000"?"": _.find(main.list, function(o) {return o.id===$this.item.pId}).name;
                    $this.onAdd = false;
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.onAdd = true;
            this.item.order = 0;
            this.item.name = "";
            this.item.pId = "";
            this.item.pName = "";
            $('#spinboxOrder').spinbox('value', 0);
            this.onAdd = false;
            this.$resetValidation();
        },
        loadTree: function () {
            var $this = this;
            var datas;
            if (!$this.editModel) {
                datas =main.list;
            } else {
                console.log(11);
                datas =_.filter(main.list,function(o) {
                    return !_.startsWith(o.levelCode, main.selectNode.levelCode);
                });
            }

            $this.tree = $.fn.zTree.init($("#treeCatalog2"), {
                data: {
                    simpleData: {
                        enable: true
                    }
                },
                callback: {
                    onClick: function (event, treeId, treeNode, clickFlag) {
                        $this.item.pId = treeNode.id;

                        $this.item.pName = treeNode.name;
                        console.log($this.item.pName, treeNode.name);
                        $("[name='parentName']").val(treeNode.name);
                        $("#menuContent").hide();
                    }
                }
            }, datas);
            $this.tree.expandAll(true);
            $("#menuContent").slideDown("fast");
        }
    }
});

var main = new Vue({
    el: "#main",
    ready: function () {
        this.loadTree();
    },
    data: {
        queryEntity: {
            category: "ProductCategory"
        },
        selected: false
    },
    events: {},
    methods: {
        newItem: function() {
            $("#addItemModal").modal("show");
            this.$broadcast('onAddItem', "新增");
        },
        editItem: function () {
            $("#addItemModal").modal("show");
            this.$broadcast('onUpdateItem', this.selectNode.name, this.selectNode.id);
        },
        deleteItem: function () {
            this.$broadcast('onShowDeleteItem', this.selectNode.name, this.selectNode.id);
        },
        loadTree: function () {
            var $this = this;
            abp.services.app.layer.getAllByCategory($this.queryEntity.category)
                .done(function (m) {
                    $this.list = m;
                    $this.treeNodes = m;
                    $this.tree = $.fn.zTree.init($("#treeCatalog"), {
                        data: {
                            simpleData: {
                                enable: true
                            }
                        },
                        callback: {
                            onClick: function (event, treeId, treeNode, clickFlag) {
                                $this.selectNode = treeNode;
                                $this.selected = true;
                                $this.$broadcast('onAddItem',treeNode.name,treeNode.id);
                            }
                        }
                    }, m);
                    $this.tree.expandAll(true);
                });

        }
    }
});