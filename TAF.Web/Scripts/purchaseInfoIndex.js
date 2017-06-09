Vue.component("form-body", {
    mixins: [itemMixin],
    template: "#budgetUnitFormBody",
    data: function () {
        return {
            item: {
                id: "",            
                category: "",
                value: "",
                title:""
            }
        };
    },
    events: {
        'onSaveItem': function (closeModal) {
            var $this = this;
            abp.services.app.sysDictionary.saveAsync($this.item)
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
            abp.services.app.sysDictionary.get(id)
                .done(function (m) {
                    $this.item = m;
                    $this.item.title= main.title;
                })
            .fail(function (m) {
                $this.fail(m);
            });
        }
    },
    methods: {
        clearItem: function () {
            this.item = {category:main.category,title:main.title};
            this.$resetValidation();
        }
    }
});


var main = new Vue({
    mixins: [indexMixin],
    ready: function () {
        var $this = this;
        $this.title = "单位";
        $this.category = "Material_ProductUnit";
        $this.queryEntity.category = $this.category;
        $("#myTab").on("shown.bs.tab", function(e) {
            var id = $(e.target).attr("id");
            if (id === "punit") {
                $this.title = "单位";
                $this.category = "Material_ProductUnit";
            }else if (id === "pstorage") {
                $this.title = "仓库";
                $this.category = "Material_Storage";
            } else if (id === "pyear") {
                $this.title = "会计年度";
                $this.category = "Material_Year";
            }
            $this.queryEntity.category = $this.category;
            $this.query(0);
        });
    },
    data: {
        queryEntity: {
            category:"", 
            value:""
        },
        category: '',
        title:''
    },
    events: {
        
    },
    methods: {
        search:function(category) {
            this.queryEntity.category = category;
            this.query(0);
        },
        excuteQuery: function ($this) {
            abp.services.app.sysDictionary.getAll(main.queryEntity)
                .done(function (r) {
                    $this.bindItems($this, r);
                });
        },
        resetSearch: function () {
            this.queryEntity.value="";
            this.queryEntity.value2="";
            this.queryEntity.note="";
        },
        delete: function (id) {
            var $this = this;
            abp.services.app.sysDictionary.delete(id)
                .done(function (m) {
                    $this.done();
                })
                .fail(function (m) {
                    $this.fail(m);
                });
        },
        newItem: function (title, category) {
            this.title = title;
            this.category = category;
            $("#addItemModal").modal("show");
            this.$broadcast('onAddItem', title);
        }
    }
});


main.query(0);



