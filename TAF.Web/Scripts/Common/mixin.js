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
                taf.notify.danger(r.validationErrors[0].message);
            } else if (r.details !== null) {
                taf.notify.danger(r.details);
            } else {
                taf.notify.danger(r.message);
            }
        },
        done: function (r) {
            this.$dispatch('onChange', 0);
            this.$resetValidation();
            $("#addItemModal").modal("hide");
        }
    },
    watch: {
        'item': {
            handler: function (val, oldVal) {
                if (this.onAdd) {
                    this.$resetValidation();
                } else {
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
            if (r.validationErrors !== null) {
                taf.notify.danger(r.validationErrors[0].message);
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



