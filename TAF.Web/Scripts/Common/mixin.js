//编辑mixin对象
var itemMixin = {
    props: ['id'],
    ready: function () {
    },
    data: function () {
        return {
            editModel: false,
            onAdd: false
        }
    },
    events: {
        'onNewItem': function () {
            this.onAdd = true;
            this.editModel = false;
            this.clearItem();
            this.$resetValidation();
            this.onAdd = false;
        }
    },
    methods: {
        fail: function (r) {
            if (r.validationErrors !== null) {
                taf.notify.danger(r.validationErrors[0].members[0]+"验证未通过");
            } else if (r.details !== null) {
                taf.notify.danger(r.details);
            } else {
                taf.notify.danger(r.message);
            }
        },
        done: function (closeModal) {
            this.$dispatch('onChange', 0);
            this.$resetValidation();
            this.clearItem();
            if (closeModal) {
                $("#addItemModal").modal("hide");
                $("#auditItemModal").modal("hide");
            }  
        }
    },
    watch: {
        'item': {
            handler: function (val, oldVal) {
                if (!this.onAdd) {
                    this.$validate();
                }
                this.$dispatch("onValidate", this.$v.valid);
            },
            deep: true
        }
    }
}

//列表mixin对象
var indexMixin = {
    el: "#main",
    data: {
        queryEntity: {
            maxResultCount: taf.defatulPageSize,
            skipCount: 0,
            sorting: ''
        },
        list: {},
        totalCount: 0,
        isSecondExcute: false
    },
    events: {
        'onAddItem': function (title) {
            $("#addItemModal").modal("show");
            this.$broadcast("onAddItem", title);
        },
        'onUpdateItem': function (title, id) {
            $("#addItemModal").modal("show");
            $("#auditItemModal").modal("show");
            this.$broadcast("onUpdateItem", title, id);
        },
        'onShowDeleteItem': function (name, id) {
            this.$broadcast("onShowDeleteItem", name, id);
        },
        'onDeleteItem': function (id) {
            this.delete(id);
        },
        'onChange': function (index) {
            this.query(index);
        }
    },
    methods: {
        query: function (index) {
            this.queryEntity.skipCount = this.queryEntity.maxResultCount * index;
            var $this = this;
            this.excuteQuery($this);
        },
        delete: function (id) { },
        bindItems: function ($this, r) {
            $this.list = r.items;
            $this.totalCount = r.totalCount;
        },
        fail: function (r) {
            if (r.validationErrors!== null) {
                taf.notify.danger(r.validationErrors[0].members[0]+"验证未通过");
            } else if (r.details !== null) {
                taf.notify.danger(r.details);
            } else {
                taf.notify.danger(r.message);
            }
        },
        done: function (r) {
            this.query(0);
            $("#deleteItemDialog").modal("hide");
        },
        excuteQuery: function ($this) { }
    },
    watch: {
        'totalCount': function (newVal, oldVal) {
            this.$broadcast("onQuery", newVal);
        }
    }
}

//列表\编辑混合对象
var allMixin = {
    el: "#main",
    data: {
        queryEntity: {
            maxResultCount: taf.defatulPageSize,//每页条数
            skipCount: 0,//过滤条数
            sorting: ''
        },
        list: {         //列表选项
            total: 0,
            from: 0,
            to: 0,
            index:0,
            pageSize: taf.defatulPageSize,
            items: {},

        },
        deleteEntity: {     //删除对象
            id: "00000000-0000-0000-0000-000000000000",
            name: ""
        },
        modifyEntity: {
            modifyTitle: "",
            id: "",
            editModel: false
        },
        item: {}
    },
    methods: {
        fail: function (r) {
            fail(function (r) {
                if (r.validationErrors !== null) {
                    taf.notify.danger(r.validationErrors[0].members[0] + "验证未通过");
                } else if (r.details !== null) {
                    taf.notify.danger(r.details);
                } else {
                    taf.notify.danger(r.message);
                }
            })
        }
    },
    watch: {
        'item': {
            handler: function (val, oldVal) {
                if (!this.onAdd) {
                    //this.$validate();
                }
            },
            deep: true
        }
    }
}

