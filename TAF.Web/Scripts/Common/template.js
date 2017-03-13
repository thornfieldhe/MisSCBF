//新增按钮
Vue.component('add-button', {
    props: ['title', 'item'],
    template: '#addButton',
    methods: {
        newItem: function (title) {
            this.$dispatch('onAddItem', title);
        }
    }
});

//行搜索按钮
Vue.component('search-command', {
    props: ['index', 'filter', 'model'],
    template: '#searchCommand',
    methods: {
        search: function () {
            this.$dispatch('onChange', 0);
        },
        resetSearch: function () {
            this.$dispatch('onResetSearch');
        }
    }
});

//行命令按钮
Vue.component('row-command', {
    props: ['id', 'title', 'name'],
    template: '#rowCommand',
    methods: {
        editItem: function (id, title) {
            this.$dispatch('onUpdateItem', title, id);
        },
        deleteItem: function (id, name) {
            this.$dispatch('onShowDeleteItem', name, id);
        }
    }
});

//编辑页
Vue.component('form-edit', {
    template: '#formEdit',
    props: ['id', 'title'],
    ready: function () {
        var $this = this;
        $('#addItemModal').on('hide.bs.modal', function () {
            $("#unknownError").show().find(".help-block").html("");
            $(this).removeData();
        });
    },
    data: function () {
        return { allowSubmit: false };
    },
    events: {
        'onAddItem': function (title) {
            this.title = title;
            console.log(12);
            this.$broadcast("onNewItem");
        },
        'onUpdateItem': function (title, id) {
            this.title = title;
            this.id = id;
            this.$broadcast("onGetItem", id);
        },
        'onValidate': function (allowValidate) {
            this.allowSubmit = allowValidate;
        }
    },
    methods: {
        saveItem: function () {
            this.$broadcast('onSaveItem');
        }
    }
});

//表脚
var foot = Vue.component('table-foot', {
    template: '#tableFoot',
    props: ['colspan'],
    methods: {
        query: function (index, jq) {
            console.trace();
            this.from = this.total === 0 ? 0 : this.pageSize * index + 1;
            this.to = this.pageSize * (index + 1) < this.total ? this.pageSize * (index + 1) : this.total;
            this.$dispatch('onChange', index);
        }
    },
    data: function () {
        return {
            total: 0,
            from: 0,
            to: 0,
            pageSize: taf.defatulPageSize,
            options: {
                num_edge_entries: 1, //边缘页数
                num_display_entries: 4, //主体页数
                items_per_page: taf.defatulPageSize, //每页显示1项  
                callback: this.query
            }
        }
    },
    events: {
        'onQuery': function (totalCount) {
            this.total = totalCount;
            this.from = this.total === 0 ? 0 : 1;
            this.to = this.pageSize < this.total ? this.pageSize : this.total;
            $("#container").pagination(totalCount, this.options);
        }
    }
});
//删除对话框
Vue.component('dialog-delete', {
    template: '#dialogDelete',
    props: ['id', 'name'],
    events: {
        'onShowDeleteItem': function (name, id) {
            $("#deleteItemDialog").modal("show");
            this.id = id;
            this.name = name;
        }
    },
    methods: {
        deleteItem: function () {
            this.$dispatch('onDeleteItem', this.id);
        }
    }
});
