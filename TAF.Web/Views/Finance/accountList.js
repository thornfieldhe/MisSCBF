﻿Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#accountFormBody",
    ready: function () {
        $("body").bind("mousedown", function (event) {
            if (!(event.target.id === "menuBtn" || event.target.id === "menuContent" || $(event.target).parents("#menuContent").length > 0)) {
                $("#menuContent").hide();
            }
        });
    },
    data: function () {
        return {
            item: {
                category: "Budget_Account",
                name: "",
                pId: "00000000-0000-0000-0000-000000000000",
                pName: "",
                id: "",
                code: ""
            },tree:{}
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            if ($this.item.pName==="") {
                $this.item.pId = "00000000-0000-0000-0000-000000000000";
            }
            abp.services.app.layer.saveAccountAsync($this.item)
            .done(function (m) {
                $this.done(closeModal);
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
                    $this.item = m;
                    console.log($this.item,123);
                    $this.item.pName =  $this.item.pId==="00000000-0000-0000-0000-000000000000"?"": _.find(main.list, function(o) {return o.id===$this.item.pId}).name;
                    $this.onAdd = false;
                    $("[name='parentName']").val($this.item.pName);
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item.onAdd = true;
            this.item.name = "";
            this.item.code = "";
            this.item.id = "00000000-0000-0000-0000-000000000000";
            this.item.pId = "00000000-0000-0000-0000-000000000000";
            this.item.pName = "";
            $('#spinboxOrder').spinbox('value', 0);
            $("[name='parentName']").val("");
            this.onAdd = false;
            this.$resetValidation();
        },
        loadTree: function () {
            var $this = this;
            var datas;
            if (!$this.editModel) {
                datas =main.list;
            } else {
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
            category: "Budget_Account"
        },
        selected: false
    },
    events: {
        'onDeleteItem':function() {
            var $this = this;
            abp.services.app.layer.delete($this.selectNode.id)
                .done(function (m) {
                    $("#deleteItemDialog").modal("hide");
                    $this.loadTree();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        }
    },
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
        fail: function (r) {
            if (r.validationErrors !== null) {
                taf.notify.danger(r.validationErrors[0].message);
            } else if (r.details !== null) {
                taf.notify.danger(r.details);
            } else {
                taf.notify.danger(r.message);
            }
        },
        loadTree: function () {
            var $this = this;
            abp.services.app.layer.getAllByCategory($this.queryEntity.category)
                .done(function (m) {
                    _.forEach(m, function(value) {
                        value.name = value.name + "[" + value.levelCode + "]";
                    });
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